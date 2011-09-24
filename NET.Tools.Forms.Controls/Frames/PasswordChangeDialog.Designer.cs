namespace NET.Tools.Forms.Frames
{
    partial class PasswordChangeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordChangeDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.separator1 = new NET.Tools.Forms.Separator();
            this.hInfo = new NET.Tools.Forms.Header();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.AccessibleDescription = null;
            this.txtOldPassword.AccessibleName = null;
            resources.ApplyResources(this.txtOldPassword, "txtOldPassword");
            this.txtOldPassword.BackgroundImage = null;
            this.txtOldPassword.Font = null;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.AccessibleDescription = null;
            this.txtNewPassword.AccessibleName = null;
            resources.ApplyResources(this.txtNewPassword, "txtNewPassword");
            this.txtNewPassword.BackgroundImage = null;
            this.txtNewPassword.Font = null;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AccessibleDescription = null;
            this.txtConfirmPassword.AccessibleName = null;
            resources.ApplyResources(this.txtConfirmPassword, "txtConfirmPassword");
            this.txtConfirmPassword.BackgroundImage = null;
            this.txtConfirmPassword.Font = null;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = null;
            this.btnOK.AccessibleName = null;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackgroundImage = null;
            this.btnOK.Font = null;
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
            this.btnCancel.Font = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.AccessibleDescription = null;
            this.pbStatus.AccessibleName = null;
            resources.ApplyResources(this.pbStatus, "pbStatus");
            this.pbStatus.BackColor = System.Drawing.Color.Transparent;
            this.pbStatus.BackgroundImage = null;
            this.pbStatus.Font = null;
            this.pbStatus.ImageLocation = null;
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.TabStop = false;
            // 
            // separator1
            // 
            this.separator1.AccessibleDescription = null;
            this.separator1.AccessibleName = null;
            resources.ApplyResources(this.separator1, "separator1");
            this.separator1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.separator1.BackgroundImage = null;
            this.separator1.Font = null;
            this.separator1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.separator1.Name = "separator1";
            // 
            // hInfo
            // 
            this.hInfo.AccessibleDescription = null;
            this.hInfo.AccessibleName = null;
            resources.ApplyResources(this.hInfo, "hInfo");
            this.hInfo.BackgroundImage = null;
            this.hInfo.BottomColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.hInfo.Font = null;
            this.hInfo.HeaderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hInfo.InfoColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hInfo.Name = "hInfo";
            this.hInfo.TopColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // PasswordChangeDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hInfo);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordChangeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Header hInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Separator separator1;
        private System.Windows.Forms.PictureBox pbStatus;
    }
}