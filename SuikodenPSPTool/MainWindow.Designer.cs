namespace SuikodenPSPTool
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mwMenuStripOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mwMenuStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mwMenuStripExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mwMenuStripImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mwMenuStripFm = new System.Windows.Forms.ToolStripMenuItem();
            this.textureConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textStringsListView = new System.Windows.Forms.ListView();
            this.numStringsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.japaneseCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mwStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mwMenuStripOpenFile,
            this.mwMenuStripSave,
            this.toolStripSeparator1,
            this.mwMenuStripExport,
            this.mwMenuStripImport,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mwMenuStripOpenFile
            // 
            this.mwMenuStripOpenFile.Name = "mwMenuStripOpenFile";
            this.mwMenuStripOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mwMenuStripOpenFile.Size = new System.Drawing.Size(185, 22);
            this.mwMenuStripOpenFile.Text = "Open";
            this.mwMenuStripOpenFile.Click += new System.EventHandler(this.mwMenuStripOpenFile_Click);
            // 
            // mwMenuStripSave
            // 
            this.mwMenuStripSave.Name = "mwMenuStripSave";
            this.mwMenuStripSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mwMenuStripSave.Size = new System.Drawing.Size(185, 22);
            this.mwMenuStripSave.Text = "Save";
            this.mwMenuStripSave.Click += new System.EventHandler(this.mwMenuStripSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // mwMenuStripExport
            // 
            this.mwMenuStripExport.Name = "mwMenuStripExport";
            this.mwMenuStripExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mwMenuStripExport.Size = new System.Drawing.Size(185, 22);
            this.mwMenuStripExport.Text = "Export to...";
            this.mwMenuStripExport.Click += new System.EventHandler(this.mwMenuStripExport_Click);
            // 
            // mwMenuStripImport
            // 
            this.mwMenuStripImport.Name = "mwMenuStripImport";
            this.mwMenuStripImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mwMenuStripImport.Size = new System.Drawing.Size(185, 22);
            this.mwMenuStripImport.Text = "Import from...";
            this.mwMenuStripImport.Click += new System.EventHandler(this.mwMenuStripImport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mwMenuStripFm,
            this.textureConverterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mwMenuStripFm
            // 
            this.mwMenuStripFm.Name = "mwMenuStripFm";
            this.mwMenuStripFm.Size = new System.Drawing.Size(167, 22);
            this.mwMenuStripFm.Text = "File Manager";
            this.mwMenuStripFm.Click += new System.EventHandler(this.mwMenuStripFm_Click);
            // 
            // textureConverterToolStripMenuItem
            // 
            this.textureConverterToolStripMenuItem.Name = "textureConverterToolStripMenuItem";
            this.textureConverterToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.textureConverterToolStripMenuItem.Text = "Texture Converter";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // textStringsListView
            // 
            this.textStringsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textStringsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numStringsCol,
            this.japaneseCol});
            this.textStringsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textStringsListView.FullRowSelect = true;
            this.textStringsListView.GridLines = true;
            this.textStringsListView.Location = new System.Drawing.Point(12, 27);
            this.textStringsListView.MultiSelect = false;
            this.textStringsListView.Name = "textStringsListView";
            this.textStringsListView.Size = new System.Drawing.Size(960, 409);
            this.textStringsListView.TabIndex = 1;
            this.textStringsListView.UseCompatibleStateImageBehavior = false;
            this.textStringsListView.View = System.Windows.Forms.View.Details;
            // 
            // numStringsCol
            // 
            this.numStringsCol.Text = "#";
            this.numStringsCol.Width = 50;
            // 
            // japaneseCol
            // 
            this.japaneseCol.Text = "Text string";
            this.japaneseCol.Width = 875;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mwStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mwStatusLabel
            // 
            this.mwStatusLabel.Name = "mwStatusLabel";
            this.mwStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textStringsListView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suikoden: The Woven Web of a Century - Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mwMenuStripFm;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mwMenuStripOpenFile;
        private System.Windows.Forms.ListView textStringsListView;
        private System.Windows.Forms.ColumnHeader numStringsCol;
        private System.Windows.Forms.ColumnHeader japaneseCol;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem mwMenuStripSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mwMenuStripExport;
        private System.Windows.Forms.ToolStripMenuItem mwMenuStripImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textureConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel mwStatusLabel;
    }
}

