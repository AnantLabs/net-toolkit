using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NET.Tools.WPF.Skins;


namespace NET.Tools.WPF
{
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Default password change dialog for wpf
    /// 
    /// Change the skin about the bundle parameter
    /// </summary>
    public partial class PasswordChangeDialogEx : Window
    {
        #region Static

        public static String ShowDialog(String title, String header, String info, ImageSource icon,
            SkinBundle bundle, Func<String, bool> validatePassword)
        {
            PasswordChangeDialogEx dlg = new PasswordChangeDialogEx(validatePassword, bundle)
                {
                    Title = title,
                    hInfo =
                        {
                            HeaderContent = header,
                            DescriptionText = info
                        }
                };
            if (icon != null)
                dlg.hInfo.IconSource = icon;
            if (bundle != null)
            {
                bundle.SetBundle(dlg);
            }

            if (dlg.ShowDialog().GetValueOrDefault(false))
                return dlg.txtNewPassword.Password;
            else
                return null;
        }

        public static String ShowDialog(String title, String header, String info, ImageSource icon,
            SkinBundle bundle)
        {
            return ShowDialog(title, header, info, icon, bundle, null);
        }

        public static String ShowDialog(String title, String header, String info, ImageSource icon,
            Func<String, bool> validatePassword)
        {
            return ShowDialog(title, header, info, icon, null, validatePassword);
        }

        public static String ShowDialog(String title, String header, String info, ImageSource icon)
        {
            return ShowDialog(title, header, info, icon, (SkinBundle)null);
        }

        public static String ShowDialog(String title, String header, String info)
        {
            return ShowDialog(title, header, info, null);
        }

        public static String ShowDialog(String title, String info)
        {
            return ShowDialog(title, title, info);
        }

        #endregion

        private Func<String, bool> validatePassword;
        private SkinBundle bundle;

        private PasswordChangeDialogEx(Func<String, bool> validatePassword, SkinBundle bundle)
        {
            InitializeComponent();

            this.validatePassword = validatePassword;
            this.bundle = bundle;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (validatePassword == null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                if (!validatePassword(txtOldPassword.Password))
                {
                    MessageDialogEx.ShowDialog("The old password is wrong!", "Error", MessageButtons.OK, MessageIcons.Error);
                    return;
                }
                else
                {
                    if (!txtNewPassword.Password.Equals(txtNewPasswordRepeating.Password))
                    {
                        MessageDialogEx.ShowDialog("The confirmed password is wrong!", "Error", MessageButtons.OK, MessageIcons.Error);
                        return;
                    }

                    DialogResult = true;
                    Close();
                }
            }
        }
    }
    /// @}
}
