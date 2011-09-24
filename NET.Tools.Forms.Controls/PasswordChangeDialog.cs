using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;


namespace NET.Tools.Forms
{
    /// <summary>
    /// Represent a password change dialog
    /// 
    /// <remarks>
    /// Support languages:
    /// - English (Default)
    /// - German
    /// </remarks>
    /// </summary>
    [ToolboxItemFilter("NET Tools")]
    [DefaultEvent("ValidatePassword")]
    public class PasswordChangeDialog : CommonDialog
    {
        private Frames.PasswordChangeDialog dlg;

        #region Properties

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set the title of this window")]
        [Localizable(true)]
        public String Title
        {
            get { return dlg.Text; }
            set { dlg.Text = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set the header text of this window")]
        [Localizable(true)]
        public String Header
        {
            get { return dlg.Header; }
            set { dlg.Header = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set the info text for this window (in header)")]
        [Localizable(true)]
        public String Info
        {
            get { return dlg.Info; }
            set { dlg.Info = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set a icon for this window (in header)")]
        [Localizable(true)]
        public Image Icon
        {
            get { return dlg.HeaderIcon; }
            set { dlg.HeaderIcon = value; }
        }

        [Browsable(false)]
        public String NewPassword
        {
            get { return dlg.NewPassword; }
        }

        #endregion

        #region Events

        [Browsable(true)]
        [Category("Action")]
        public event Func<String, bool> ValidatePassword;

        #endregion

        public PasswordChangeDialog()
        {
            dlg = new NET.Tools.Forms.Frames.PasswordChangeDialog();
            if (ValidatePassword != null)
                dlg.ValidatePassword += (password) =>
                {
                    return ValidatePassword(password);
                };
        }

        public override void Reset()
        {
            dlg.Reset();
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
                return true;

            return false;
        }
    }
}
