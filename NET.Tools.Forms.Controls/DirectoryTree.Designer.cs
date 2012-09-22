namespace NET.Tools.Forms
{
    partial class DirectoryTree
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvDirectories = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvDirectories
            // 
            this.tvDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirectories.HideSelection = false;
            this.tvDirectories.ImageIndex = 0;
            this.tvDirectories.ImageList = this.imgList;
            this.tvDirectories.Location = new System.Drawing.Point(0, 0);
            this.tvDirectories.Name = "tvDirectories";
            this.tvDirectories.SelectedImageIndex = 0;
            this.tvDirectories.Size = new System.Drawing.Size(172, 370);
            this.tvDirectories.TabIndex = 0;
            this.tvDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectories_AfterSelect);
            this.tvDirectories.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectories_AfterExpand);
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DirectoryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tvDirectories);
            this.Name = "DirectoryTree";
            this.Size = new System.Drawing.Size(172, 370);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDirectories;
        private System.Windows.Forms.ImageList imgList;
    }
}
