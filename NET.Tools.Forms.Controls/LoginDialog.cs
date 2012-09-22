using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace NET.Tools.Forms
{
    /// <summary>
    /// Represent a login dialog
    /// 
    /// <remarks>
    /// Support languages:
    /// - English (Default)
    /// - German
    /// </remarks>
    /// </summary>
    [ToolboxItemFilter("NET Tools")]
    [DefaultEvent("ValidateUser")]
    public class LoginDialog : CommonDialog
    {
        private Frames.LoginDialog dlg = null;

        #region Events

        [Browsable(true)]
        [Category("Behavior")]
        public event Func<String, String, bool> ValidateUser;

        #endregion

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
            get { return dlg.Text; }
            set { dlg.Text = value; }
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

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Set the username-text")]
        [DefaultValue("Username:")]
        [Localizable(true)]
        public String UserNameText
        {
            get { return dlg.UserNameText; }
            set { dlg.UserNameText = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Set the default username")]
        [DefaultValue("")]
        public String UserName
        {
            get { return dlg.UserName; }
            set { dlg.UserName = value; }
        }

        [Browsable(false)]
        public String Password
        {
            get { return dlg.Password; }
        }

        #endregion

        public LoginDialog()
            : base()
        {
            dlg = new NET.Tools.Forms.Frames.LoginDialog();
            dlg.ValidateUser += (user, password) =>
            {
                if (ValidateUser != null)
                    if (!ValidateUser(user, password))
                        return false;

                return true;
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
