namespace NET.Tools.Forms
{
    partial class ColorComboBox
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
            this.cmbColors = new NET.Tools.Forms.ImageComboBox();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth4Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmbColors
            // 
            this.cmbColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColors.FormattingEnabled = true;
            this.cmbColors.ImageList = this.imgList;
            this.cmbColors.Location = new System.Drawing.Point(0, 0);
            this.cmbColors.Name = "cmbColors";
            this.cmbColors.Size = new System.Drawing.Size(150, 21);
            this.cmbColors.TabIndex = 0;
            // 
            // ColorComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbColors);
            this.Name = "ColorComboBox";
            this.Size = new System.Drawing.Size(150, 25);
            this.Resize += new System.EventHandler(this.ColorComboBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageComboBox cmbColors;
        private System.Windows.Forms.ImageList imgList;

    }
}
