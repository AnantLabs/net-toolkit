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
using System.Runtime.InteropServices;
using NET.Tools.WPF.Skins;
using NET.Tools.OS;



namespace NET.Tools.WPF
{
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Default message dialog for WPF
    /// 
    /// You can change the skin about the skin bundle parameter
    /// </summary>
    public partial class MessageDialogEx : Window
    {
        #region Static
        private static MessageResults ShowDialog(
            String message, String title, MessageButtons button, MessageIcons icon,
            ImageSource image, SkinBundle bundle)
        {
            MessageDialogEx dlg = new MessageDialogEx
                                      {
                                          Title = title,
                                          lblMessage = {Text = message},
                                          icon = icon,
                                          imgIcon = {Source = MessageIconHelper.GetIcon(icon, bundle)}
                                      };

            if (dlg.imgIcon.Source == null)
                if (image != null)
                    dlg.imgIcon.Source = image;

            switch (button)
            {
                case MessageButtons.OK:
                    dlg.btnOK.Visibility = Visibility.Visible;
                    break;
                case MessageButtons.OKCancel:
                    dlg.btnOK.Visibility = Visibility.Visible;
                    dlg.btnCancel.Visibility = Visibility.Visible;
                    break;
                case MessageButtons.YesNo:
                    dlg.btnYes.Visibility = Visibility.Visible;
                    dlg.btnNo.Visibility = Visibility.Visible;
                    break;
                case MessageButtons.YesNoCancel:
                    dlg.btnYes.Visibility = Visibility.Visible;
                    dlg.btnNo.Visibility = Visibility.Visible;
                    dlg.btnCancel.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (bundle != null)
                bundle.SetBundle(dlg);

            dlg.ShowDialog();

            return dlg.Result;
        }

        public static MessageResults ShowDialog(
            String message, String title, MessageButtons button, MessageIcons icon,
            SkinBundle bundle)
        {
            return ShowDialog(message, title, button, icon, null, bundle);
        }

        public static MessageResults ShowDialog(
            String message, String title, MessageButtons button,
            ImageSource image, SkinBundle bundle)
        {
            return ShowDialog(message, title, button, MessageIcons.None, image, bundle);
        }

        public static MessageResults ShowDialog(
            String message, String title, MessageButtons button, MessageIcons icon)
        {
            return ShowDialog(message, title, button, icon, null, null);
        }

        public static MessageResults ShowDialog(
            String message, String title, MessageButtons button,
            ImageSource image)
        {
            return ShowDialog(message, title, button, MessageIcons.None, image, null);
        }
        #endregion

        public MessageResults Result { get; private set; }
        private bool canClose = false;
        private MessageIcons icon;

        private MessageDialogEx()
        {
            InitializeComponent();
            Result = MessageResults.Cancel;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageResults.Cancel;
            canClose = true;
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageResults.OK;
            canClose = true;
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageResults.No;
            canClose = true;
            Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageResults.Yes;
            canClose = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!canClose)
                e.Cancel = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (icon)
            {
                case MessageIcons.None:
                    break;
                case MessageIcons.Info:
                    MessageTools.MessageBeep(MessageType.INFO);
                    break;
                case MessageIcons.Error:
                    MessageTools.MessageBeep(MessageType.ERROR);
                    break;
                case MessageIcons.Warn:
                    MessageTools.MessageBeep(MessageType.WARN);
                    break;
                case MessageIcons.Qestion:
                    MessageTools.MessageBeep(MessageType.QUESTION);
                    break;
                case MessageIcons.OK:
                    MessageTools.MessageBeep(MessageType.OK);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
    /// @}
}
