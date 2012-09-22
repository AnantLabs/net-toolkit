using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;


namespace NET.Tools.Forms.Frames
{
    internal partial class LoginDialog : Form
    {
        public event Func<String, String, bool> ValidateUser;

        [Localizable(true)]
        public String Header
        {
            get { return hInfo.HeaderText; }
            set { hInfo.HeaderText = value; }
        }

        [Localizable(true)]
        public String Info
        {
            get { return hInfo.InfoText; }
            set { hInfo.InfoText = value; }
        }

        [Localizable(true)]
        public Image HeaderIcon
        {
            get { return hInfo.Icon; }
            set { hInfo.Icon = value; }
        }

        [Localizable(true)]
        public String UserNameText
        {
            get { return lblUserName.Text; }
            set { lblUserName.Text = value; }
        }

        public String UserName
        {
            get { return txtUserName.Text; }
            set { txtUserName.Text = value; }
        }

        public String Password
        {
            get { return txtPassword.Text; }
        }

        public LoginDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        public void Reset()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateUser == null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (ValidateUser(UserName, Password))
                {
                    pbStatus.Image = Properties.Resources.OK;
                    Refresh();
                    Thread.Sleep(500);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    pbStatus.Image = Properties.Resources.Failed;
                    txtPassword.Text = "";
                    Refresh();
                    Thread.Sleep(500);

                    MessageBox.Show(TextManager.Dialog.Message.Error.Login.Message, 
                        TextManager.Dialog.Message.Error.Login.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
