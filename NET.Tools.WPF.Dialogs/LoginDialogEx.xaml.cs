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
    /// Default login dialog for WPF
    /// 
    /// You can change the skin about the bundle parameter
    /// </summary>
    public partial class LoginDialogEx : Window
    {
        #region Static

        public static LoginData ShowDialog(String title, String header, String info,
            String userNameText, String userName, ImageSource icon, SkinBundle bundle, Func<String, String, bool> validateUser)
        {
            LoginDialogEx dlg = new LoginDialogEx(validateUser, bundle);
            dlg.Title = title;
            dlg.hInfo.HeaderText = header;
            dlg.hInfo.InfoText = info;
            if (bundle != null)
            {
                if (bundle.HeaderTopColor.HasValue)
                    dlg.hInfo.TopColor = bundle.HeaderTopColor.Value;
                if (bundle.HeadLineTextBrush != null)
                    dlg.hInfo.HeaderColor = bundle.HeadLineTextBrush;
                if (bundle.InfoTextBrush != null)
                    dlg.hInfo.InfoColor = bundle.InfoTextBrush;
                if (bundle.HeaderBottomColor.HasValue)
                    dlg.hInfo.BottomColor = bundle.HeaderBottomColor.Value;

                bundle.SetBundle(dlg);
            }

            if (userNameText != null)
                dlg.lblUserName.Content = userNameText;
            dlg.txtUsername.Text = userName;
            if (icon != null)
                dlg.Icon = icon;

            if (dlg.ShowDialog().GetValueOrDefault(false))
                return new LoginData(dlg.txtUsername.Text, dlg.txtPassword.Password);
            else
                return null;
        }

        public static LoginData ShowDialog(String title, String header, String info,
            String userNameText, String userName, ImageSource icon, SkinBundle bundle)
        {
            return ShowDialog(title, header, info, userNameText, userName, icon, bundle, null);
        }

        public static LoginData ShowDialog(String title, String header, String info,
            String userName, ImageSource icon, SkinBundle bundle)
        {
            return ShowDialog(title, header, info, null, userName, icon, bundle);
        }

        public static LoginData ShowDialog(String title, String header, String info,
            String userName, ImageSource icon)
        {
            return ShowDialog(title, header, info, userName, icon, (SkinBundle)null);
        }

        public static LoginData ShowDialog(String title, String header, String info,
            String userName)
        {
            return ShowDialog(title, header, info, userName, (ImageSource)null);
        }

        public static LoginData ShowDialog(String title, String header, String info)
        {
            return ShowDialog(title, header, info, "");
        }

        public static LoginData ShowDialog(String title, String info)
        {
            return ShowDialog(title, title, info);
        }

        public static LoginData ShowDialog(String title, String header, String info,
            String userName, ImageSource icon, SkinBundle bundle, Func<String, String, bool> validateUser)
        {
            return ShowDialog(title, header, info, null, userName, icon, bundle, validateUser);
        }

        public static LoginData ShowDialog(String title, String header, String info,
            String userName, ImageSource icon, Func<String, String, bool> validateUser)
        {
            return ShowDialog(title, header, info, userName, icon, null, validateUser);
        }

        public static LoginData ShowDialog(String title, String header, String info,
            String userName, Func<String, String, bool> validateUser)
        {
            return ShowDialog(title, header, info, userName, null, validateUser);
        }

        public static LoginData ShowDialog(String title, String header, String info,
            Func<String, String, bool> validateUser)
        {
            return ShowDialog(title, header, info, "", validateUser);
        }

        public static LoginData ShowDialog(String title, String info,
            Func<String, String, bool> validateUser)
        {
            return ShowDialog(title, title, info, validateUser);
        }

        #endregion

        private Func<String, String, bool> validate;
        private SkinBundle bundle;

        private LoginDialogEx(Func<String, String, bool> validate, SkinBundle bundle)
        {
            InitializeComponent();
            this.validate = validate;
            this.bundle = bundle;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (validate == null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                if (!validate(txtUsername.Text, txtPassword.Password))
                {
                    imgState.Source = BitmapFrame.Create(new Uri(@"pack://application:,,, /NET.Tools.WPF.Dialogs;component/Resources/State/User022.png"));
                    MessageDialogEx.ShowDialog("Login failed!", "Login", MessageButtons.OK, MessageIcons.Error, bundle);
                }
                else
                {
                    imgState.Source = BitmapFrame.Create(new Uri(@"pack://application:,,, /NET.Tools.WPF.Dialogs;component/Resources/State/User020.png"));
                    DialogResult = true;
                    Close();
                }
            }
        }
    }
    /// @}

    /// <summary>
    /// Represent the login data for a default login dialog
    /// </summary>
    public sealed class LoginData
    {
        public String UserName { get; private set; }
        public String Password { get; private set; }

        internal LoginData(String userName, String password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
