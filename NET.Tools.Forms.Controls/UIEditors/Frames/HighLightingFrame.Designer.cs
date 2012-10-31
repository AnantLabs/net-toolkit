namespace NET.Tools.Forms
{
    partial class HighLightingFrame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighLightingFrame));
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFontStyle = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlForeground = new System.Windows.Forms.Panel();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlExample = new System.Windows.Forms.Panel();
            this.lblExample = new System.Windows.Forms.Label();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.pnlExample.SuspendLayout();
            this.SuspendLayout();
            // 
            // errProv
            // 
            this.errProv.ContainerControl = this;
            resources.ApplyResources(this.errProv, "errProv");
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.errProv.SetError(this.label1, resources.GetString("label1.Error"));
            this.label1.Font = null;
            this.errProv.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errProv.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // txtRegex
            // 
            this.txtRegex.AccessibleDescription = null;
            this.txtRegex.AccessibleName = null;
            resources.ApplyResources(this.txtRegex, "txtRegex");
            this.txtRegex.BackgroundImage = null;
            this.errProv.SetError(this.txtRegex, resources.GetString("txtRegex.Error"));
            this.txtRegex.Font = null;
            this.errProv.SetIconAlignment(this.txtRegex, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtRegex.IconAlignment"))));
            this.errProv.SetIconPadding(this.txtRegex, ((int)(resources.GetObject("txtRegex.IconPadding"))));
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.TextChanged += new System.EventHandler(this.txtRegex_TextChanged);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.errProv.SetError(this.label2, resources.GetString("label2.Error"));
            this.label2.Font = null;
            this.errProv.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errProv.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.errProv.SetError(this.label3, resources.GetString("label3.Error"));
            this.label3.Font = null;
            this.errProv.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errProv.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.errProv.SetError(this.label4, resources.GetString("label4.Error"));
            this.label4.Font = null;
            this.errProv.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
            this.errProv.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding"))));
            this.label4.Name = "label4";
            // 
            // cmbFontStyle
            // 
            this.cmbFontStyle.AccessibleDescription = null;
            this.cmbFontStyle.AccessibleName = null;
            resources.ApplyResources(this.cmbFontStyle, "cmbFontStyle");
            this.cmbFontStyle.BackgroundImage = null;
            this.cmbFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errProv.SetError(this.cmbFontStyle, resources.GetString("cmbFontStyle.Error"));
            this.cmbFontStyle.Font = null;
            this.cmbFontStyle.FormattingEnabled = true;
            this.errProv.SetIconAlignment(this.cmbFontStyle, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cmbFontStyle.IconAlignment"))));
            this.errProv.SetIconPadding(this.cmbFontStyle, ((int)(resources.GetObject("cmbFontStyle.IconPadding"))));
            this.cmbFontStyle.Name = "cmbFontStyle";
            this.cmbFontStyle.Sorted = true;
            this.cmbFontStyle.SelectedIndexChanged += new System.EventHandler(this.cmbFontStyle_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = null;
            this.btnOK.AccessibleName = null;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackgroundImage = null;
            this.errProv.SetError(this.btnOK, resources.GetString("btnOK.Error"));
            this.btnOK.Font = null;
            this.errProv.SetIconAlignment(this.btnOK, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnOK.IconAlignment"))));
            this.errProv.SetIconPadding(this.btnOK, ((int)(resources.GetObject("btnOK.IconPadding"))));
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errProv.SetError(this.btnCancel, resources.GetString("btnCancel.Error"));
            this.btnCancel.Font = null;
            this.errProv.SetIconAlignment(this.btnCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancel.IconAlignment"))));
            this.errProv.SetIconPadding(this.btnCancel, ((int)(resources.GetObject("btnCancel.IconPadding"))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlForeground
            // 
            this.pnlForeground.AccessibleDescription = null;
            this.pnlForeground.AccessibleName = null;
            resources.ApplyResources(this.pnlForeground, "pnlForeground");
            this.pnlForeground.BackColor = System.Drawing.Color.Black;
            this.pnlForeground.BackgroundImage = null;
            this.pnlForeground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errProv.SetError(this.pnlForeground, resources.GetString("pnlForeground.Error"));
            this.pnlForeground.Font = null;
            this.errProv.SetIconAlignment(this.pnlForeground, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlForeground.IconAlignment"))));
            this.errProv.SetIconPadding(this.pnlForeground, ((int)(resources.GetObject("pnlForeground.IconPadding"))));
            this.pnlForeground.Name = "pnlForeground";
            this.pnlForeground.Click += new System.EventHandler(this.pnlForeground_Click);
            // 
            // pnlBackground
            // 
            this.pnlBackground.AccessibleDescription = null;
            this.pnlBackground.AccessibleName = null;
            resources.ApplyResources(this.pnlBackground, "pnlBackground");
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.BackgroundImage = null;
            this.pnlBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errProv.SetError(this.pnlBackground, resources.GetString("pnlBackground.Error"));
            this.pnlBackground.Font = null;
            this.errProv.SetIconAlignment(this.pnlBackground, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlBackground.IconAlignment"))));
            this.errProv.SetIconPadding(this.pnlBackground, ((int)(resources.GetObject("pnlBackground.IconPadding"))));
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Click += new System.EventHandler(this.pnlBackground_Click);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.errProv.SetError(this.label5, resources.GetString("label5.Error"));
            this.label5.Font = null;
            this.errProv.SetIconAlignment(this.label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment"))));
            this.errProv.SetIconPadding(this.label5, ((int)(resources.GetObject("label5.IconPadding"))));
            this.label5.Name = "label5";
            // 
            // pnlExample
            // 
            this.pnlExample.AccessibleDescription = null;
            this.pnlExample.AccessibleName = null;
            resources.ApplyResources(this.pnlExample, "pnlExample");
            this.pnlExample.BackColor = System.Drawing.Color.White;
            this.pnlExample.BackgroundImage = null;
            this.pnlExample.Controls.Add(this.lblExample);
            this.errProv.SetError(this.pnlExample, resources.GetString("pnlExample.Error"));
            this.pnlExample.Font = null;
            this.errProv.SetIconAlignment(this.pnlExample, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlExample.IconAlignment"))));
            this.errProv.SetIconPadding(this.pnlExample, ((int)(resources.GetObject("pnlExample.IconPadding"))));
            this.pnlExample.Name = "pnlExample";
            // 
            // lblExample
            // 
            this.lblExample.AccessibleDescription = null;
            this.lblExample.AccessibleName = null;
            resources.ApplyResources(this.lblExample, "lblExample");
            this.lblExample.BackColor = System.Drawing.Color.White;
            this.errProv.SetError(this.lblExample, resources.GetString("lblExample.Error"));
            this.lblExample.Font = null;
            this.errProv.SetIconAlignment(this.lblExample, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblExample.IconAlignment"))));
            this.errProv.SetIconPadding(this.lblExample, ((int)(resources.GetObject("lblExample.IconPadding"))));
            this.lblExample.Name = "lblExample";
            // 
            // HighLightingFrame
            // 
            this.AcceptButton = this.btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pnlExample);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.pnlForeground);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbFontStyle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.label1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.Name = "HighLightingFrame";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.pnlExample.ResumeLayout(false);
            this.pnlExample.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFontStyle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlForeground;
        private System.Windows.Forms.Panel pnlExample;
        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColorDialog colorDlg;
    }
}