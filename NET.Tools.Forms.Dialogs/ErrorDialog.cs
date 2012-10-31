using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using NET.Tools.OS;


namespace NET.Tools.Forms
{
    /// \defgroup dialogGroup Dialogs for WPF and Window Forms
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Dialog for errors
    /// </summary>
    public partial class ErrorDialog : Form
    {
        #region Static

        /// <summary>
        /// Shows the dialog
        /// </summary>
        /// <param name="msg">General message</param>
        /// <param name="title">Title of message box</param>
        /// <param name="e">Excpetion to show, when user pressed "Details"</param>
        public static void ShowError(String msg, String title, Exception e)
        {
            ErrorDialog dlg = new ErrorDialog();
            dlg.lblMessage.Text = msg;
            dlg.lblException.Text = e.GetType().Name + ": " + e.Message;

            StringBuilder error = new StringBuilder();
            Exception current = e;
            while (current != null)
            {
                error.Append(current.GetType().Name + ": " + current.Message + "\r\n" + current.StackTrace + "\r\n");
                current = current.InnerException;
            }
            dlg.txtError.Text = error.ToString();
            dlg.txtError.Select(0, 0);

            dlg.Text = title;

            MessageTools.MessageBeep(MessageType.ERROR);
            dlg.ShowDialog();
        }

        #endregion

        private ErrorDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            btnDetails.Enabled = false;

            for (int i = 0; i < 100; i++)
            {
                this.Height++;
                this.txtError.Height++;
                Refresh();

                Thread.Sleep(1);
                Application.DoEvents();
            }
        }
    }
    /// @}
}
