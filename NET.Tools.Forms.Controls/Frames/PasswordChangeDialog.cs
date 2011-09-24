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
    internal partial class PasswordChangeDialog : Form
    {
        public event Func<String, bool> ValidatePassword;

        public String NewPassword { get { return txtNewPassword.Text; } }

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

        public PasswordChangeDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        public void Reset()
        {
            txtNewPassword.Text = "";
            txtOldPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidatePassword == null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (!ValidatePassword(txtOldPassword.Text))
                {
                    pbStatus.Image = Properties.Resources.Failed;
                    Refresh();
                    Thread.Sleep(500);

                    MessageBox.Show(TextManager.Dialog.Message.Error.Login.Message, 
                        TextManager.Dialog.Message.Error.Login.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
                    {
                        MessageBox.Show(TextManager.Dialog.Message.Error.Login.Message, 
                            TextManager.Dialog.Message.Error.Login.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    pbStatus.Image = Properties.Resources.OK;
                    Refresh();
                    Thread.Sleep(500);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
