namespace NET.Tools.Forms.Frames
{
    partial class LoginDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.hInfo = new NET.Tools.Forms.Header();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.separator1 = new NET.Tools.Forms.Separator();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AccessibleDescription = null;
            this.lblUserName.AccessibleName = null;
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Font = null;
            this.lblUserName.Name = "lblUserName";
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleDescription = null;
            this.txtUserName.AccessibleName = null;
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.BackgroundImage = null;
            this.txtUserName.Font = null;
            this.txtUserName.Name = "txtUserName";
            // 
            // lblPassword
            // 
            this.lblPassword.AccessibleDescription = null;
            this.lblPassword.AccessibleName = null;
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Font = null;
            this.lblPassword.Name = "lblPassword";
            // 
            // txtPassword
            // 
            this.txtPassword.AccessibleDescription = null;
            this.txtPassword.AccessibleName = null;
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.BackgroundImage = null;
            this.txtPassword.Font = null;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.UseSystemPasswordChar = true;
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
            // LoginDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.hInfo);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Header hInfo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbStatus;
        private Separator separator1;
    }
}