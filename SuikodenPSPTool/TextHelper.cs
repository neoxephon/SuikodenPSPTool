using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using System.Xml;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SuikodenPSPTool
{
    public class TextHelper
    {
        public List<string> textStrings;
        public List<Tuple<int, int, int, int>> textBlockEnd;
        public List<int> pointers;
        public List<int> donePointers;

        public void EbootText(string filename)
        {
            textStrings = new List<string>();

            List<int> pointerTables = new List<int>() { 0x2585D0, 0x25C7FC, 0x2368FC, 0x249308 };
            textBlockEnd = new List<Tuple<int, int, int, int>>();
            pointers = new List<int>();
            List<int> pointerOffsets = new List<int>();

            string appDir = Path.GetDirectoryName(Application.ExecutablePath);
            string txtOutput = Path.Combine(appDir, "eboot-pointers.txt");

            using (var br = new BinaryReader(File.OpenRead(filename)))
            {
                using (var sw = new StreamWriter(txtOutput))
                {
                    int blockOneEnd = 0;
                    int blockTwoEnd = 0;
                    int blockThreeEnd = 0;
                    int blockFourEnd = 0;

                    for (int i = 0; i < pointerTables.Count; i++)
                    {
                        int count = 0;
                        br.BaseStream.Position = pointerTables[i];

                        if (i == 2)
                        {
                            while (br.ReadInt32() != 0x01000505)
                            {
                                br.BaseStream.Position -= 4;

                                for (int n = 0; n < 3; n++)
                                {
                                    int pointer = br.ReadInt32() + 0xC0;
                                    if (!pointers.Contains(pointer)) count++;
                                    pointers.Add(pointer);
                                    pointerOffsets.Add((int)(br.BaseStream.Position) - 4);
                                }

                                br.BaseStream.Position += 4;
                            }

                            blockThreeEnd = blockTwoEnd + count;
                        }
                        else
                        {
                            while (br.ReadInt32() != 0)
                            {
                                br.BaseStream.Position -= 4;

                                int pointer = br.ReadInt32() + 0xC0;
                                if (!pointers.Contains(pointer)) count++;
                                pointers.Add(pointer);
                                pointerOffsets.Add((int)(br.BaseStream.Position) - 4);
                            }
                            if (i == 0) blockOneEnd = count;
                            else if (i == 1) blockTwoEnd = blockOneEnd + count;
                            else blockFourEnd = blockThreeEnd + count;
                        }
                    }

                    textBlockEnd.Add(new Tuple<int, int, int, int>(blockOneEnd, blockTwoEnd, blockThreeEnd, blockFourEnd));

                    donePointers = new List<int>();

                    for (int i = 0; i < pointers.Count; i++)
                    {
                        if (!donePointers.Contains(pointers[i]))
                        {
                            br.BaseStream.Position = pointers[i];
                            int length = 0;
                            while (br.ReadByte() != 0) length++;
                            br.BaseStream.Position = pointers[i];

                            string textString = Encoding.GetEncoding(932).GetString(br.ReadBytes(length)).Replace("\x0A", @"\n");
                            if (textString == string.Empty) textString = "null";
                            textStrings.Add(textString);

                            int x = 0;
                            string offsets = string.Empty;
                            foreach (var value in pointers)
                            {
                                if (value == pointers[i])
                                {
                                    offsets += (pointerOffsets[x].ToString("X") + ",");
                                }
                                x++;
                            }

                            sw.WriteLine(offsets);

                            donePointers.Add(pointers[i]);
                        }
                    }
                }
            }
        }

        public void EbootImport (string filename, List<string> newTextStrings)
        {
            List<int> pointerTables = new List<int>() { 0x2585D0, 0x25C7FC, 0x2368FC, 0x249308 };
            List<int> newPointers = new List<int>();
            List<Tuple<int, int, int>> textBlocks = new List<Tuple<int, int, int>>();

            textBlocks.Add(new Tuple<int, int, int>(0x17ED23, 0x19D07F, 0x19D07F - 0x17ED23));
            textBlocks.Add(new Tuple<int, int, int>(0x2326E0, 0x232950, 0x232950 - 0x2326E0));
            textBlocks.Add(new Tuple<int, int, int>(0x235010, 0x2368F6, 0x2368F6 - 0x235010));
            textBlocks.Add(new Tuple<int, int, int>(0x248A30, 0x249306, 0x249306 - 0x248A30));

            string appDir = Path.GetDirectoryName(Application.ExecutablePath);
            string txtOutput = Path.Combine(appDir, "eboot-pointers.txt");

            using (var bw = new BinaryWriter(File.OpenWrite(filename)))
            {
                using (var sr = new StreamReader(txtOutput))
                {
                    int index = 0;
                    int freeSpace = 0x2494F0;

                    for (int i = 0; i < textBlocks.Count; i++)
                    {
                        int currentBlock = 0;

                        if (i == 0) currentBlock = textBlockEnd[0].Item1;
                        else if (i == 1) currentBlock = textBlockEnd[0].Item2;
                        else if (i == 2) currentBlock = textBlockEnd[0].Item3;
                        else currentBlock = textBlockEnd[0].Item4;

                        bw.BaseStream.Position = textBlocks[i].Item1;

                        for (int x = index; x < currentBlock; x++)
                        {
                            bw.BaseStream.Position = donePointers[x];

                            if (bw.BaseStream.Position + newTextStrings[x].Length < textBlocks[i].Item2)
                            {
                                List<string> offsets;
                                string tmpString = sr.ReadLine();
                                offsets = tmpString.Split(',').ToList();
                                offsets = offsets.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                                string textString = newTextStrings[x];

                                if (textString != textStrings[x])
                                {
                                    if ((textString.Length + 1) + donePointers[x] < donePointers[x + 1])
                                    {
                                        bw.BaseStream.Position = donePointers[x];
                                        if (textString == "null") textString = string.Empty;
                                        bw.Write(Encoding.GetEncoding(932).GetBytes(textString.Replace("\x0A", "\n")));
                                        bw.Write((byte)0);
                                    }
                                    else
                                    {
                                        bw.BaseStream.Position = freeSpace;
                                        int pointer = (int)bw.BaseStream.Position - 0xC0;

                                        if (textString == "null") textString = string.Empty;
                                        bw.Write(Encoding.GetEncoding(932).GetBytes(textString.Replace("\x0A", "\n")));
                                        bw.Write((byte)0);

                                        freeSpace = (int)bw.BaseStream.Position;

                                        for (int j = 0; j < offsets.Count; j++)
                                        {
                                            int offset = Int32.Parse(offsets[j], System.Globalization.NumberStyles.HexNumber);
                                            bw.BaseStream.Position = offset;
                                            bw.Write(pointer);
                                        }
                                    }
                                }
                            }
                            index++;
                        }
                    }
                }
            }
        }
    }
}
