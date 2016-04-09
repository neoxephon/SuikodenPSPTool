using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace SuikodenPSPTool
{
    public partial class FileManagerWindow : Form
    {
        public FileManagerWindow()
        {
            InitializeComponent();
        }

        private string outFile = string.Empty;

        private string FindExtension (string id)
        {
            string extension = string.Empty;

            if (id == "RIFF") extension = ".wav";
            else if (id == "xt.") extension = ".tx";
            else if (id == "ax.") extension = ".xa";
            else if (id == "mx.") extension = ".xm";
            else if (id == "STGP") extension = ".pgt";
            else if (id == "MIG.") extension = ".gim";
            else if (id == "OMG.") extension = ".gmo";
            else extension = ".bin";

            return extension;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<int> offsets = new List<int>();
            List<int> sizes = new List<int>();

            string filename = (string)e.Argument;
            string directory = Path.GetDirectoryName(filename);
            Directory.CreateDirectory(directory + @"/data/");           

            using (BinaryReader br = new BinaryReader(File.OpenRead(filename)))
            {
                int curPos = 0;
                int pointer = br.ReadInt32();
                int pointerTblSize = pointer - 200;
                int fileCount = pointerTblSize / 8;

                br.BaseStream.Position = 0;

                for (int i = 0; i < fileCount; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }

                    pointer = br.ReadInt32();
                    int filesize = br.ReadInt32();
                    curPos = (int)(br.BaseStream.Position);

                    
                    br.BaseStream.Position = pointer;

                    string id = Encoding.GetEncoding(932).GetString(br.ReadBytes(4)).Replace("\0", string.Empty);

                    string extension = FindExtension(id);

                    outFile = directory + @"/data/" + i.ToString("D5") + extension;

                    br.BaseStream.Position = pointer + 0x40;

                    int gzipCheck = br.ReadInt32();

                    br.BaseStream.Position = pointer;

                    using (BinaryWriter bw = new BinaryWriter(File.Create(outFile))) bw.Write(br.ReadBytes(filesize));
                    (sender as BackgroundWorker).ReportProgress(i);

                    if (gzipCheck == 0x00088B1F)
                    {
                        using (BinaryReader br2 = new BinaryReader(File.OpenRead(outFile)))
                        {
                            List<int> gzipOffsets = new List<int>();
                            string outGZipDir = Path.GetDirectoryName(outFile) + @"/" + Path.GetFileNameWithoutExtension(outFile);
                            Directory.CreateDirectory(outGZipDir);

                            int pointerTbl = br2.ReadInt32();
                            br2.BaseStream.Position = pointerTbl;

                            int numFiles = br2.ReadInt32();

                            for (int x = 0; x < numFiles; x++)
                            {
                                gzipOffsets.Add(br2.ReadInt32());
                                int unknown = br2.ReadInt32();
                            }

                            for (int x = 0; x < numFiles; x++)
                            {
                                string outGZip = outGZipDir + @"/" + x.ToString("D2") + ".gz";
                                int gzipSize = 0;

                                if (x != numFiles - 1)
                                {
                                    gzipSize = gzipOffsets[x + 1] - gzipOffsets[x];
                                }
                                else gzipSize = pointerTbl - gzipOffsets[x];

                                br2.BaseStream.Position = gzipOffsets[x];

                                using (BinaryWriter bw = new BinaryWriter(File.Create(outGZip)))
                                {
                                    bw.Write(br2.ReadBytes(gzipSize));
                                }

                                string dcmpFile = Path.GetDirectoryName(outGZip) + @"/" + Path.GetFileNameWithoutExtension(outGZip);

                                using (FileStream cmpFs = new FileStream(outGZip, FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    using (FileStream dcmpFs = new FileStream(dcmpFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                                    {
                                        using (GZipStream dcmpGZip = new GZipStream(cmpFs, CompressionMode.Decompress))
                                        {
                                            dcmpGZip.CopyTo(dcmpFs);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    br.BaseStream.Position = curPos;
                }
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (worker.CancellationPending == false)
            {
                fmProgressBar.Value = e.ProgressPercentage;
                int percentComplete = (int)Math.Round((double)(100 * e.ProgressPercentage) / 13030);

                this.Text = "File Manager - " + percentComplete + @"% complete";
                string newFileTrimmed = Path.GetFileName(outFile);
                fmProgressBox.AppendText(@"Extracting: " + newFileTrimmed + Environment.NewLine);
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                fmProgressBox.AppendText(@"Canceled.");
                fmProgressBar.Value = 0;
            }
            else
            {
                fmProgressBox.AppendText(@"Completed Successfully!");
            }
            
            this.Text = "File Manager";
        }

        private void fmExtractButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {               
                string filename = ofd.FileName;
                fmProgressBox.Clear();
                fmProgressBar.Value = 0;
                fmProgressBar.Maximum = 13030;

                worker.RunWorkerAsync(filename);
            }
        }

        private void fmCancelButton_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }

        private void FileManagerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                DialogResult result = MessageBox.Show("Please wait for the current job to finish or click the Cancel button.", "Busy", MessageBoxButtons.OK);

                e.Cancel = true;
            }
            else e.Cancel = false;
        }
    }
}
