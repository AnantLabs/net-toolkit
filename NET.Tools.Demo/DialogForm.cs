using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using System.Threading;
using NET.Tools.Forms;

namespace NET.Tools
{
    public partial class DialogForm : Form
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        private void btnPictureDlg_Click(object sender, EventArgs e)
        {
            if (openPictureDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Abort!");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (loginDialog1.ShowDialog() == DialogResult.OK)
                MessageBox.Show("OK");
            else
                MessageBox.Show("Failed!");
        }

        private bool loginDialog1_ValidateUser(string arg1, string arg2)
        {
            return (arg1.ToLower().Equals("user") &&
                    arg2.Equals("12345"));
        }

        private bool passwordChangeDialog1_ValidatePassword(string arg)
        {
            return arg.Equals("12345");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordChangeDialog1.ShowDialog() == DialogResult.OK)
                MessageBox.Show("OK");
            else
                MessageBox.Show("Failed!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    throw new Exception("Inner exception");
                }
                catch (Exception iex)
                {
                    throw new NotImplementedException("My Test Exception", iex);
                }
            }
            catch (Exception ex)
            {
                ErrorDialog.ShowError("There is an error!", "Error", ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<String> lst = new List<string>();
            lst.Add("First");
            lst.Add("Second");
            lst.Add("Third");

            String res = InputDialog.ShowComboBoxInputDialog("Input Dialog", "Please enter a string:", lst);
            if (res == null)
                MessageBox.Show("Canceled!");
            else
                MessageBox.Show("OK: " + res);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String res = InputDialog.ShowDefaultDialog("Input Dialog", "Please enter a string:");
            if (res == null)
                MessageBox.Show("Canceled!");
            else
                MessageBox.Show("OK: " + res);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SplashApplication.Run(new SplashWin(), new MainWin());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (WorkingDialog.ShowDialog("Work...", (s, arg) =>
            {
                arg.HideKBS();
                arg.Maximum = 100;
                arg.Info = "Do something...";

                for (int i = 0; i < 100; i++)
                {
                    arg.Value = i + 1;
                    arg.ShowTime(100, i + 1);

                    Thread.Sleep(25);
                }
            }))
                MessageBox.Show("OK");
            else
                MessageBox.Show("Cancel");
        }
    }
}
