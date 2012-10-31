namespace NET.Tools.Forms
{
    partial class FontComboBox
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
            this.cmbFonts = new NET.Tools.FontPaintComboBox();
            this.SuspendLayout();
            // 
            // cmbFonts
            // 
            this.cmbFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFonts.DrawFont = false;
            this.cmbFonts.DrawFontInEditBox = false;
            this.cmbFonts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFonts.FormattingEnabled = true;
            this.cmbFonts.Location = new System.Drawing.Point(0, 0);
            this.cmbFonts.Name = "cmbFonts";
            this.cmbFonts.Size = new System.Drawing.Size(150, 21);
            this.cmbFonts.TabIndex = 0;
            this.cmbFonts.SelectedIndexChanged += new System.EventHandler(this.cmbFonts_SelectedIndexChanged);
            // 
            // FontComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbFonts);
            this.Name = "FontComboBox";
            this.Size = new System.Drawing.Size(150, 25);
            this.Resize += new System.EventHandler(this.FontComboBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private FontPaintComboBox cmbFonts;


    }
}
