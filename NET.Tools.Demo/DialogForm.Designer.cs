namespace NET.Tools
{
    partial class DialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            this.btnPictureDlg = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.openPictureDialog1 = new NET.Tools.Forms.OpenPictureDialog();
            this.passwordChangeDialog1 = new NET.Tools.Forms.PasswordChangeDialog();
            this.loginDialog1 = new NET.Tools.Forms.LoginDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPictureDlg
            // 
            this.btnPictureDlg.Location = new System.Drawing.Point(12, 12);
            this.btnPictureDlg.Name = "btnPictureDlg";
            this.btnPictureDlg.Size = new System.Drawing.Size(252, 23);
            this.btnPictureDlg.TabIndex = 0;
            this.btnPictureDlg.Text = "Picture - Dialog";
            this.btnPictureDlg.UseVisualStyleBackColor = true;
            this.btnPictureDlg.Click += new System.EventHandler(this.btnPictureDlg_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 41);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(252, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login - Dialog";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Password Change - Dialog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Error - Dialog";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(252, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "ComboBox - Input - Dialog";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 157);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(252, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Default - Input - Dialog";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // openPictureDialog1
            // 
            this.openPictureDialog1.InitialDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("openPictureDialog1.InitialDirectory")));
            // 
            // passwordChangeDialog1
            // 
            this.passwordChangeDialog1.Header = "Change password";
            this.passwordChangeDialog1.Icon = ((System.Drawing.Image)(resources.GetObject("passwordChangeDialog1.Icon")));
            this.passwordChangeDialog1.Info = "Change you password here";
            this.passwordChangeDialog1.Title = "Password Change";
            this.passwordChangeDialog1.ValidatePassword += new System.Func<string, bool>(this.passwordChangeDialog1_ValidatePassword);
            // 
            // loginDialog1
            // 
            this.loginDialog1.Header = "Login";
            this.loginDialog1.Icon = ((System.Drawing.Image)(resources.GetObject("loginDialog1.Icon")));
            this.loginDialog1.Info = "Please enter the username and the password";
            this.loginDialog1.Title = "Login";
            this.loginDialog1.ValidateUser += new System.Func<string, string, bool>(this.loginDialog1_ValidateUser);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(252, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Splash - Dialog";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 215);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(252, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Working - Dialog";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 269);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnPictureDlg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog - Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPictureDlg;
        private NET.Tools.Forms.OpenPictureDialog openPictureDialog1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button1;
        private NET.Tools.Forms.PasswordChangeDialog passwordChangeDialog1;
        private NET.Tools.Forms.LoginDialog loginDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}