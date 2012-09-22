namespace NET.Tools.Forms
{
    partial class Header
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AccessibleDescription = null;
            this.lblHeader.AccessibleName = null;
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHeader.Name = "lblHeader";
            // 
            // lblDescription
            // 
            this.lblDescription.AccessibleDescription = null;
            this.lblDescription.AccessibleName = null;
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = null;
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDescription.Name = "lblDescription";
            // 
            // imgIcon
            // 
            this.imgIcon.AccessibleDescription = null;
            this.imgIcon.AccessibleName = null;
            resources.ApplyResources(this.imgIcon, "imgIcon");
            this.imgIcon.BackColor = System.Drawing.Color.Transparent;
            this.imgIcon.BackgroundImage = null;
            this.imgIcon.Font = null;
            this.imgIcon.ImageLocation = null;
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.TabStop = false;
            // 
            // Header
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.imgIcon);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblHeader);
            this.Font = null;
            this.Name = "Header";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Header_Paint);
            this.Resize += new System.EventHandler(this.Header_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox imgIcon;
    }
}
