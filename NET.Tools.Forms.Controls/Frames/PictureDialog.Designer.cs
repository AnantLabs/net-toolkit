namespace NET.Tools.Forms.Frames
{
    partial class PictureDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureDialog));
            this.imgLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbFileFilter = new NET.Tools.Forms.FileFilterComboBox();
            this.cmbDirectories = new NET.Tools.Forms.DirectoryComboBox();
            this.lstFiles = new NET.Tools.Forms.FileSystemManager();
            this.tvDirectories = new NET.Tools.Forms.DirectoryTree();
            this.txtFileNames = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLarge
            // 
            this.imgLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imgLarge, "imgLarge");
            this.imgLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgSmall
            // 
            this.imgSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imgSmall, "imgSmall");
            this.imgSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pbPreview
            // 
            resources.ApplyResources(this.pbPreview, "pbPreview");
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.TabStop = false;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbFileFilter
            // 
            this.cmbFileFilter.BackColor = System.Drawing.Color.Transparent;
            this.cmbFileFilter.FileFilterList = new NET.Tools.Forms.FileFilter[0];
            resources.ApplyResources(this.cmbFileFilter, "cmbFileFilter");
            this.cmbFileFilter.Name = "cmbFileFilter";
            this.cmbFileFilter.SelectedFilter = null;
            this.cmbFileFilter.SelectedFilterIndex = -1;
            this.cmbFileFilter.SelectedFilterString = null;
            // 
            // cmbDirectories
            // 
            this.cmbDirectories.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.cmbDirectories, "cmbDirectories");
            this.cmbDirectories.Name = "cmbDirectories";
            this.cmbDirectories.SelectedDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("cmbDirectories.SelectedDirectory")));
            // 
            // lstFiles
            // 
            this.lstFiles.AutoFileActionHandle = false;
            this.lstFiles.BackColor = System.Drawing.Color.Transparent;
            this.lstFiles.Directory = ((System.IO.DirectoryInfo)(resources.GetObject("lstFiles.Directory")));
            this.lstFiles.Filter = "*.bmp";
            this.lstFiles.HasObjectContextMenu = false;
            this.lstFiles.HasPlaceContextMenu = false;
            this.lstFiles.LinkedDirectoryBox = this.cmbDirectories;
            this.lstFiles.LinkedDirectoryTree = this.tvDirectories;
            this.lstFiles.LinkedFileFilterBox = this.cmbFileFilter;
            resources.ApplyResources(this.lstFiles, "lstFiles");
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectedObjectChanged += new System.EventHandler(this.lstFiles_SelectedObjectChanged);
            // 
            // tvDirectories
            // 
            this.tvDirectories.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tvDirectories, "tvDirectories");
            this.tvDirectories.Name = "tvDirectories";
            this.tvDirectories.SelectedDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("tvDirectories.SelectedDirectory")));
            // 
            // txtFileNames
            // 
            resources.ApplyResources(this.txtFileNames, "txtFileNames");
            this.txtFileNames.Name = "txtFileNames";
            // 
            // PictureDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.txtFileNames);
            this.Controls.Add(this.cmbFileFilter);
            this.Controls.Add(this.cmbDirectories);
            this.Controls.Add(this.tvDirectories);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PictureDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imgLarge;
        private System.Windows.Forms.ImageList imgSmall;
        private NET.Tools.Forms.FileSystemManager lstFiles;
        private NET.Tools.Forms.DirectoryTree tvDirectories;
        private NET.Tools.Forms.DirectoryComboBox cmbDirectories;
        private NET.Tools.Forms.FileFilterComboBox cmbFileFilter;
        private System.Windows.Forms.TextBox txtFileNames;
    }
}