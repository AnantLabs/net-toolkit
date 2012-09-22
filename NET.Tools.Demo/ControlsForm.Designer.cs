namespace NET.Tools
{
    partial class ControlsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlsForm));
            NET.Tools.Forms.HighLightingRecord highLightingRecord3 = new NET.Tools.Forms.HighLightingRecord();
            NET.Tools.Forms.HighLightingRecord highLightingRecord4 = new NET.Tools.Forms.HighLightingRecord();
            this.TaskbarTimer = new System.Windows.Forms.Timer(this.components);
            this.labeledTextBox1 = new NET.Tools.Forms.LabeledTextBox();
            this.separator1 = new NET.Tools.Forms.Separator();
            this.fileFilterComboBox1 = new NET.Tools.Forms.FileFilterComboBox();
            this.header1 = new NET.Tools.Forms.Header();
            this.fontComboBox1 = new NET.Tools.Forms.FontComboBox();
            this.directoryComboBox1 = new NET.Tools.Forms.DirectoryComboBox();
            this.fileSystemManager1 = new NET.Tools.Forms.FileSystemManager();
            this.directoryTree1 = new NET.Tools.Forms.DirectoryTree();
            this.colorComboBox1 = new NET.Tools.Forms.ColorComboBox();
            this.highLightingTextBox1 = new NET.Tools.Forms.HighLightingTextBox();
            this.SuspendLayout();
            // 
            // TaskbarTimer
            // 
            this.TaskbarTimer.Tick += new System.EventHandler(this.TaskbarTimer_Tick);
            // 
            // labeledTextBox1
            // 
            this.labeledTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.labeledTextBox1.Location = new System.Drawing.Point(285, 12);
            this.labeledTextBox1.Name = "labeledTextBox1";
            this.labeledTextBox1.Size = new System.Drawing.Size(148, 33);
            this.labeledTextBox1.TabIndex = 10;
            this.labeledTextBox1.Title = "Textbox:";
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.separator1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.separator1.Location = new System.Drawing.Point(12, 56);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(760, 2);
            this.separator1.TabIndex = 9;
            // 
            // fileFilterComboBox1
            // 
            this.fileFilterComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.fileFilterComboBox1.FileFilterList = new NET.Tools.Forms.FileFilter[0];
            this.fileFilterComboBox1.Location = new System.Drawing.Point(405, 458);
            this.fileFilterComboBox1.Name = "fileFilterComboBox1";
            this.fileFilterComboBox1.SelectedFilter = null;
            this.fileFilterComboBox1.SelectedFilterIndex = -1;
            this.fileFilterComboBox1.SelectedFilterString = null;
            this.fileFilterComboBox1.Size = new System.Drawing.Size(367, 21);
            this.fileFilterComboBox1.TabIndex = 8;
            // 
            // header1
            // 
            this.header1.BottomColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.HeaderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.header1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header1.HeaderText = "My Header";
            this.header1.Icon = ((System.Drawing.Image)(resources.GetObject("header1.Icon")));
            this.header1.InfoColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.header1.InfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header1.InfoText = "My Info";
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(784, 50);
            this.header1.TabIndex = 7;
            this.header1.TopColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // fontComboBox1
            // 
            this.fontComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.fontComboBox1.Location = new System.Drawing.Point(12, 431);
            this.fontComboBox1.Name = "fontComboBox1";
            this.fontComboBox1.Size = new System.Drawing.Size(204, 21);
            this.fontComboBox1.TabIndex = 6;
            // 
            // directoryComboBox1
            // 
            this.directoryComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.directoryComboBox1.Location = new System.Drawing.Point(405, 68);
            this.directoryComboBox1.Name = "directoryComboBox1";
            this.directoryComboBox1.SelectedDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("directoryComboBox1.SelectedDirectory")));
            this.directoryComboBox1.Size = new System.Drawing.Size(367, 21);
            this.directoryComboBox1.TabIndex = 4;
            // 
            // fileSystemManager1
            // 
            this.fileSystemManager1.BackColor = System.Drawing.Color.Transparent;
            this.fileSystemManager1.Directory = ((System.IO.DirectoryInfo)(resources.GetObject("fileSystemManager1.Directory")));
            this.fileSystemManager1.LinkedDirectoryBox = this.directoryComboBox1;
            this.fileSystemManager1.LinkedDirectoryTree = this.directoryTree1;
            this.fileSystemManager1.LinkedFileFilterBox = this.fileFilterComboBox1;
            this.fileSystemManager1.Location = new System.Drawing.Point(405, 95);
            this.fileSystemManager1.Name = "fileSystemManager1";
            this.fileSystemManager1.Size = new System.Drawing.Size(367, 357);
            this.fileSystemManager1.TabIndex = 3;
            // 
            // directoryTree1
            // 
            this.directoryTree1.BackColor = System.Drawing.Color.Transparent;
            this.directoryTree1.Location = new System.Drawing.Point(222, 68);
            this.directoryTree1.Name = "directoryTree1";
            this.directoryTree1.SelectedDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("directoryTree1.SelectedDirectory")));
            this.directoryTree1.Size = new System.Drawing.Size(172, 411);
            this.directoryTree1.TabIndex = 2;
            // 
            // colorComboBox1
            // 
            this.colorComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.colorComboBox1.Location = new System.Drawing.Point(12, 458);
            this.colorComboBox1.Name = "colorComboBox1";
            this.colorComboBox1.SelectedColor = System.Drawing.Color.Transparent;
            this.colorComboBox1.Size = new System.Drawing.Size(204, 21);
            this.colorComboBox1.TabIndex = 1;
            // 
            // highLightingTextBox1
            // 
            this.highLightingTextBox1.Location = new System.Drawing.Point(12, 68);
            this.highLightingTextBox1.Name = "highLightingTextBox1";
            highLightingRecord3.BackColor = System.Drawing.Color.White;
            highLightingRecord3.FontStyle = System.Drawing.FontStyle.Italic;
            highLightingRecord3.ForeColor = System.Drawing.Color.Maroon;
            highLightingRecord3.RegularExpression = ((System.Text.RegularExpressions.Regex)(resources.GetObject("highLightingRecord3.RegularExpression")));
            highLightingRecord4.BackColor = System.Drawing.Color.White;
            highLightingRecord4.FontStyle = System.Drawing.FontStyle.Bold;
            highLightingRecord4.ForeColor = System.Drawing.Color.Blue;
            highLightingRecord4.RegularExpression = ((System.Text.RegularExpressions.Regex)(resources.GetObject("highLightingRecord4.RegularExpression")));
            this.highLightingTextBox1.RecordList = new NET.Tools.Forms.HighLightingRecord[] {
        highLightingRecord3,
        highLightingRecord4};
            this.highLightingTextBox1.Size = new System.Drawing.Size(204, 357);
            this.highLightingTextBox1.TabIndex = 0;
            this.highLightingTextBox1.Text = "I say: \"Hello!\" and his public answer was \"No\", and so on.";
            // 
            // ControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.labeledTextBox1);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.fileFilterComboBox1);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.fontComboBox1);
            this.Controls.Add(this.directoryComboBox1);
            this.Controls.Add(this.fileSystemManager1);
            this.Controls.Add(this.directoryTree1);
            this.Controls.Add(this.colorComboBox1);
            this.Controls.Add(this.highLightingTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ControlsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controls - Form";
            this.ResumeLayout(false);

        }

        #endregion

        private NET.Tools.Forms.HighLightingTextBox highLightingTextBox1;
        private NET.Tools.Forms.ColorComboBox colorComboBox1;
        private NET.Tools.Forms.DirectoryTree directoryTree1;
        private NET.Tools.Forms.FileSystemManager fileSystemManager1;
        private NET.Tools.Forms.DirectoryComboBox directoryComboBox1;
        private NET.Tools.Forms.FontComboBox fontComboBox1;
        private NET.Tools.Forms.Header header1;
        private NET.Tools.Forms.FileFilterComboBox fileFilterComboBox1;
        private NET.Tools.Forms.Separator separator1;
        private System.Windows.Forms.Timer TaskbarTimer;
        private NET.Tools.Forms.LabeledTextBox labeledTextBox1;
    }
}