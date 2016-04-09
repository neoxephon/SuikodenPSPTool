using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NPOI.XSSF.UserModel;
using System.Text;

namespace SuikodenPSPTool
{
    public partial class MainWindow : Form
    {
        private string filename = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mwMenuStripFm_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.OfType<FileManagerWindow>().FirstOrDefault();

            if (frm == null) (new FileManagerWindow()).Show();
            else frm.Activate();
        }

        private void mwMenuStripOpenFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TextHelper txtHelper = new TextHelper();

                filename = ofd.FileName;
                txtHelper.EbootText(filename);

                for (int i = 0; i < txtHelper.textStrings.Count; i++)
                {
                    string numString = (i + 1).ToString();
                    textStringsListView.Items.Add(numString).SubItems.Add(txtHelper.textStrings[i]);                   
                }

                mwStatusLabel.Text = "Total # of Strings: " + txtHelper.textStrings.Count.ToString();
            }
        }

        private void mwMenuStripExport_Click(object sender, EventArgs e)
        {
            List<string> textStrings = new List<string>();

            var sfd = new SaveFileDialog();
            sfd.Filter = "Text file (*.txt)|*.txt";
            sfd.FileName = Path.GetFileNameWithoutExtension(filename) + ".txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                foreach (ListViewItem item in textStringsListView.Items) textStrings.Add(item.SubItems[1].Text);

                using (var sw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Open, FileAccess.ReadWrite), Encoding.UTF8))
                {
                    for (int i = 0; i < textStrings.Count; i++) sw.WriteLine(textStrings[i]);
                }
            }
        }

        private void mwMenuStripImport_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Text file (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> textStrings = new List<string>();

                // Clear out the listview before populating it with the imported data
                textStringsListView.Items.Clear();

                using (var sr = new StreamReader(ofd.FileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null) textStrings.Add(line);         
                }

                for (int i = 0; i < textStrings.Count; i++)
                {
                    string numString = (i + 1).ToString();
                    textStringsListView.Items.Add(numString).SubItems.Add(textStrings[i]);
                }
            }
        }

        private void mwMenuStripSave_Click(object sender, EventArgs e)
        {
            List<string> newTextStrings = new List<string>();
            TextHelper txtHelper = new TextHelper();
            txtHelper.EbootText(filename);

            foreach (ListViewItem item in textStringsListView.Items)
            {
                newTextStrings.Add(item.SubItems[1].Text);
            }

            txtHelper.EbootImport(filename, newTextStrings);

        }
    }
}
