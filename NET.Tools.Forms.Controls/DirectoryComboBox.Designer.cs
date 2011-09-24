namespace NET.Tools.Forms
{
    partial class DirectoryComboBox
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
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cmbDirectory = new NET.Tools.Forms.FolderComboBox();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmbDirectory
            // 
            this.cmbDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDirectory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirectory.FormattingEnabled = true;
            this.cmbDirectory.Location = new System.Drawing.Point(0, 0);
            this.cmbDirectory.Name = "cmbDirectory";
            this.cmbDirectory.Size = new System.Drawing.Size(150, 21);
            this.cmbDirectory.TabIndex = 0;
            this.cmbDirectory.SelectedIndexChanged += new System.EventHandler(this.cmbDirectory_SelectedIndexChanged);
            // 
            // DirectoryComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbDirectory);
            this.Name = "DirectoryComboBox";
            this.Size = new System.Drawing.Size(150, 25);
            this.Resize += new System.EventHandler(this.DirectoryComboBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private FolderComboBox cmbDirectory;
    }
}
