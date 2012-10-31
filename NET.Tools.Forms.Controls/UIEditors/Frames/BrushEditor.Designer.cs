namespace NET.Tools.Forms
{
    partial class BrushEditor
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbBrushes = new System.Windows.Forms.ComboBox();
            this.grbSolidBrush = new System.Windows.Forms.GroupBox();
            this.pnlSolidBrushExample = new System.Windows.Forms.Panel();
            this.btnSolidBrushColor = new System.Windows.Forms.Button();
            this.grbLinearGradientBrush = new System.Windows.Forms.GroupBox();
            this.pnlLinearGradientBrushExample = new System.Windows.Forms.Panel();
            this.txtLinearGradientRectangle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLinearGradientBrushColor2 = new System.Windows.Forms.Button();
            this.btnLinearGradientBrushColor1 = new System.Windows.Forms.Button();
            this.grbHatchBrush = new System.Windows.Forms.GroupBox();
            this.pnlHatchBrushExample = new System.Windows.Forms.Panel();
            this.cmbHatches = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHatchBrushColor2 = new System.Windows.Forms.Button();
            this.btnHatchBrushColor1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.grbSolidBrush.SuspendLayout();
            this.grbLinearGradientBrush.SuspendLayout();
            this.grbHatchBrush.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBrushes
            // 
            this.cmbBrushes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrushes.FormattingEnabled = true;
            this.cmbBrushes.Location = new System.Drawing.Point(12, 12);
            this.cmbBrushes.Name = "cmbBrushes";
            this.cmbBrushes.Size = new System.Drawing.Size(266, 21);
            this.cmbBrushes.Sorted = true;
            this.cmbBrushes.TabIndex = 0;
            this.cmbBrushes.SelectedIndexChanged += new System.EventHandler(this.cmbBrushes_SelectedIndexChanged);
            // 
            // grbSolidBrush
            // 
            this.grbSolidBrush.Controls.Add(this.pnlSolidBrushExample);
            this.grbSolidBrush.Controls.Add(this.btnSolidBrushColor);
            this.grbSolidBrush.Enabled = false;
            this.grbSolidBrush.Location = new System.Drawing.Point(12, 39);
            this.grbSolidBrush.Name = "grbSolidBrush";
            this.grbSolidBrush.Size = new System.Drawing.Size(266, 54);
            this.grbSolidBrush.TabIndex = 1;
            this.grbSolidBrush.TabStop = false;
            this.grbSolidBrush.Text = "SolidBrush";
            // 
            // pnlSolidBrushExample
            // 
            this.pnlSolidBrushExample.Location = new System.Drawing.Point(87, 19);
            this.pnlSolidBrushExample.Name = "pnlSolidBrushExample";
            this.pnlSolidBrushExample.Size = new System.Drawing.Size(173, 29);
            this.pnlSolidBrushExample.TabIndex = 1;
            this.pnlSolidBrushExample.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSolidBrushExample_Paint);
            // 
            // btnSolidBrushColor
            // 
            this.btnSolidBrushColor.Location = new System.Drawing.Point(6, 19);
            this.btnSolidBrushColor.Name = "btnSolidBrushColor";
            this.btnSolidBrushColor.Size = new System.Drawing.Size(75, 29);
            this.btnSolidBrushColor.TabIndex = 0;
            this.btnSolidBrushColor.Text = "Color...";
            this.btnSolidBrushColor.UseVisualStyleBackColor = true;
            this.btnSolidBrushColor.Click += new System.EventHandler(this.btnSolidBrushColor_Click);
            // 
            // grbLinearGradientBrush
            // 
            this.grbLinearGradientBrush.Controls.Add(this.txtAngle);
            this.grbLinearGradientBrush.Controls.Add(this.label2);
            this.grbLinearGradientBrush.Controls.Add(this.pnlLinearGradientBrushExample);
            this.grbLinearGradientBrush.Controls.Add(this.txtLinearGradientRectangle);
            this.grbLinearGradientBrush.Controls.Add(this.label1);
            this.grbLinearGradientBrush.Controls.Add(this.btnLinearGradientBrushColor2);
            this.grbLinearGradientBrush.Controls.Add(this.btnLinearGradientBrushColor1);
            this.grbLinearGradientBrush.Enabled = false;
            this.grbLinearGradientBrush.Location = new System.Drawing.Point(12, 99);
            this.grbLinearGradientBrush.Name = "grbLinearGradientBrush";
            this.grbLinearGradientBrush.Size = new System.Drawing.Size(266, 163);
            this.grbLinearGradientBrush.TabIndex = 2;
            this.grbLinearGradientBrush.TabStop = false;
            this.grbLinearGradientBrush.Text = "LinearGradientBrush";
            // 
            // pnlLinearGradientBrushExample
            // 
            this.pnlLinearGradientBrushExample.Location = new System.Drawing.Point(87, 19);
            this.pnlLinearGradientBrushExample.Name = "pnlLinearGradientBrushExample";
            this.pnlLinearGradientBrushExample.Size = new System.Drawing.Size(173, 138);
            this.pnlLinearGradientBrushExample.TabIndex = 4;
            this.pnlLinearGradientBrushExample.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLinearGradientBrushExample_Paint);
            // 
            // txtLinearGradientRectangle
            // 
            this.txtLinearGradientRectangle.Location = new System.Drawing.Point(6, 90);
            this.txtLinearGradientRectangle.Name = "txtLinearGradientRectangle";
            this.txtLinearGradientRectangle.Size = new System.Drawing.Size(75, 20);
            this.txtLinearGradientRectangle.TabIndex = 3;
            this.txtLinearGradientRectangle.Text = "0|0|100|100";
            this.txtLinearGradientRectangle.TextChanged += new System.EventHandler(this.txtPoint1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rectangle:";
            // 
            // btnLinearGradientBrushColor2
            // 
            this.btnLinearGradientBrushColor2.Location = new System.Drawing.Point(6, 48);
            this.btnLinearGradientBrushColor2.Name = "btnLinearGradientBrushColor2";
            this.btnLinearGradientBrushColor2.Size = new System.Drawing.Size(75, 23);
            this.btnLinearGradientBrushColor2.TabIndex = 1;
            this.btnLinearGradientBrushColor2.Text = "Color 2...";
            this.btnLinearGradientBrushColor2.UseVisualStyleBackColor = true;
            this.btnLinearGradientBrushColor2.Click += new System.EventHandler(this.btnLinearGradientBrushColor2_Click);
            // 
            // btnLinearGradientBrushColor1
            // 
            this.btnLinearGradientBrushColor1.Location = new System.Drawing.Point(6, 19);
            this.btnLinearGradientBrushColor1.Name = "btnLinearGradientBrushColor1";
            this.btnLinearGradientBrushColor1.Size = new System.Drawing.Size(75, 23);
            this.btnLinearGradientBrushColor1.TabIndex = 0;
            this.btnLinearGradientBrushColor1.Text = "Color 1...";
            this.btnLinearGradientBrushColor1.UseVisualStyleBackColor = true;
            this.btnLinearGradientBrushColor1.Click += new System.EventHandler(this.btnLinearGradientBrushColor1_Click);
            // 
            // grbHatchBrush
            // 
            this.grbHatchBrush.Controls.Add(this.pnlHatchBrushExample);
            this.grbHatchBrush.Controls.Add(this.cmbHatches);
            this.grbHatchBrush.Controls.Add(this.label3);
            this.grbHatchBrush.Controls.Add(this.btnHatchBrushColor2);
            this.grbHatchBrush.Controls.Add(this.btnHatchBrushColor1);
            this.grbHatchBrush.Enabled = false;
            this.grbHatchBrush.Location = new System.Drawing.Point(12, 268);
            this.grbHatchBrush.Name = "grbHatchBrush";
            this.grbHatchBrush.Size = new System.Drawing.Size(266, 121);
            this.grbHatchBrush.TabIndex = 3;
            this.grbHatchBrush.TabStop = false;
            this.grbHatchBrush.Text = "HatchBrush";
            // 
            // pnlHatchBrushExample
            // 
            this.pnlHatchBrushExample.Location = new System.Drawing.Point(87, 19);
            this.pnlHatchBrushExample.Name = "pnlHatchBrushExample";
            this.pnlHatchBrushExample.Size = new System.Drawing.Size(173, 96);
            this.pnlHatchBrushExample.TabIndex = 6;
            this.pnlHatchBrushExample.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHatchBrushExample_Paint);
            // 
            // cmbHatches
            // 
            this.cmbHatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHatches.FormattingEnabled = true;
            this.cmbHatches.Location = new System.Drawing.Point(6, 90);
            this.cmbHatches.Name = "cmbHatches";
            this.cmbHatches.Size = new System.Drawing.Size(75, 21);
            this.cmbHatches.Sorted = true;
            this.cmbHatches.TabIndex = 5;
            this.cmbHatches.SelectedIndexChanged += new System.EventHandler(this.cmbHatches_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hatch:";
            // 
            // btnHatchBrushColor2
            // 
            this.btnHatchBrushColor2.Location = new System.Drawing.Point(6, 48);
            this.btnHatchBrushColor2.Name = "btnHatchBrushColor2";
            this.btnHatchBrushColor2.Size = new System.Drawing.Size(75, 23);
            this.btnHatchBrushColor2.TabIndex = 3;
            this.btnHatchBrushColor2.Text = "Color 2...";
            this.btnHatchBrushColor2.UseVisualStyleBackColor = true;
            this.btnHatchBrushColor2.Click += new System.EventHandler(this.btnHatchBrushColor2_Click);
            // 
            // btnHatchBrushColor1
            // 
            this.btnHatchBrushColor1.Location = new System.Drawing.Point(6, 19);
            this.btnHatchBrushColor1.Name = "btnHatchBrushColor1";
            this.btnHatchBrushColor1.Size = new System.Drawing.Size(75, 23);
            this.btnHatchBrushColor1.TabIndex = 2;
            this.btnHatchBrushColor1.Text = "Color 1...";
            this.btnHatchBrushColor1.UseVisualStyleBackColor = true;
            this.btnHatchBrushColor1.Click += new System.EventHandler(this.btnHatchBrushColor1_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(203, 400);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Angle:";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(6, 129);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(75, 20);
            this.txtAngle.TabIndex = 0;
            this.txtAngle.Text = "0";
            this.txtAngle.TextChanged += new System.EventHandler(this.txtAngle_TextChanged);
            // 
            // BrushEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(290, 435);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbHatchBrush);
            this.Controls.Add(this.grbLinearGradientBrush);
            this.Controls.Add(this.grbSolidBrush);
            this.Controls.Add(this.cmbBrushes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BrushEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brush-Editor";
            this.grbSolidBrush.ResumeLayout(false);
            this.grbLinearGradientBrush.ResumeLayout(false);
            this.grbLinearGradientBrush.PerformLayout();
            this.grbHatchBrush.ResumeLayout(false);
            this.grbHatchBrush.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBrushes;
        private System.Windows.Forms.GroupBox grbSolidBrush;
        private System.Windows.Forms.Panel pnlSolidBrushExample;
        private System.Windows.Forms.Button btnSolidBrushColor;
        private System.Windows.Forms.GroupBox grbLinearGradientBrush;
        private System.Windows.Forms.Button btnLinearGradientBrushColor2;
        private System.Windows.Forms.Button btnLinearGradientBrushColor1;
        private System.Windows.Forms.TextBox txtLinearGradientRectangle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLinearGradientBrushExample;
        private System.Windows.Forms.GroupBox grbHatchBrush;
        private System.Windows.Forms.ComboBox cmbHatches;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHatchBrushColor2;
        private System.Windows.Forms.Button btnHatchBrushColor1;
        private System.Windows.Forms.Panel pnlHatchBrushExample;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDlg;
    }
}