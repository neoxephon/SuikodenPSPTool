namespace SuikodenPSPTool
{
    partial class FileManagerWindow
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
            this.fmProgressBox = new System.Windows.Forms.TextBox();
            this.fmProgressBar = new System.Windows.Forms.ProgressBar();
            this.fmProgressBarLabel = new System.Windows.Forms.Label();
            this.fmExtractButton = new System.Windows.Forms.Button();
            this.fmRebuildButton = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.fmCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fmProgressBox
            // 
            this.fmProgressBox.Location = new System.Drawing.Point(12, 12);
            this.fmProgressBox.Multiline = true;
            this.fmProgressBox.Name = "fmProgressBox";
            this.fmProgressBox.ReadOnly = true;
            this.fmProgressBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fmProgressBox.Size = new System.Drawing.Size(386, 258);
            this.fmProgressBox.TabIndex = 0;
            // 
            // fmProgressBar
            // 
            this.fmProgressBar.Location = new System.Drawing.Point(12, 276);
            this.fmProgressBar.Name = "fmProgressBar";
            this.fmProgressBar.Size = new System.Drawing.Size(485, 23);
            this.fmProgressBar.TabIndex = 1;
            // 
            // fmProgressBarLabel
            // 
            this.fmProgressBarLabel.AutoSize = true;
            this.fmProgressBarLabel.BackColor = System.Drawing.Color.Transparent;
            this.fmProgressBarLabel.Location = new System.Drawing.Point(43, 276);
            this.fmProgressBarLabel.Name = "fmProgressBarLabel";
            this.fmProgressBarLabel.Size = new System.Drawing.Size(0, 13);
            this.fmProgressBarLabel.TabIndex = 2;
            // 
            // fmExtractButton
            // 
            this.fmExtractButton.Location = new System.Drawing.Point(404, 12);
            this.fmExtractButton.Name = "fmExtractButton";
            this.fmExtractButton.Size = new System.Drawing.Size(93, 23);
            this.fmExtractButton.TabIndex = 3;
            this.fmExtractButton.Text = "Extract";
            this.fmExtractButton.UseVisualStyleBackColor = true;
            this.fmExtractButton.Click += new System.EventHandler(this.fmExtractButton_Click);
            // 
            // fmRebuildButton
            // 
            this.fmRebuildButton.Location = new System.Drawing.Point(404, 41);
            this.fmRebuildButton.Name = "fmRebuildButton";
            this.fmRebuildButton.Size = new System.Drawing.Size(93, 23);
            this.fmRebuildButton.TabIndex = 4;
            this.fmRebuildButton.Text = "Rebuild";
            this.fmRebuildButton.UseVisualStyleBackColor = true;
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // fmCancelButton
            // 
            this.fmCancelButton.Location = new System.Drawing.Point(404, 247);
            this.fmCancelButton.Name = "fmCancelButton";
            this.fmCancelButton.Size = new System.Drawing.Size(93, 23);
            this.fmCancelButton.TabIndex = 5;
            this.fmCancelButton.Text = "Cancel";
            this.fmCancelButton.UseVisualStyleBackColor = true;
            this.fmCancelButton.Click += new System.EventHandler(this.fmCancelButton_Click);
            // 
            // FileManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 311);
            this.Controls.Add(this.fmCancelButton);
            this.Controls.Add(this.fmRebuildButton);
            this.Controls.Add(this.fmExtractButton);
            this.Controls.Add(this.fmProgressBarLabel);
            this.Controls.Add(this.fmProgressBar);
            this.Controls.Add(this.fmProgressBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileManagerWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileManagerWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fmProgressBox;
        private System.Windows.Forms.ProgressBar fmProgressBar;
        private System.Windows.Forms.Label fmProgressBarLabel;
        private System.Windows.Forms.Button fmExtractButton;
        private System.Windows.Forms.Button fmRebuildButton;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Button fmCancelButton;
    }
}