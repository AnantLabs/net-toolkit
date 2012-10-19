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
using NET.Tools.OS;



namespace NET.Tools.WPF
{
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Default dialog for WPF Error Messages (Exceptions)
    /// 
    /// Change the skin about the bundle parameter
    /// </summary>
    public partial class ErrorDialogEx : Window
    {
        public static void ShowDialog(String title, String msg, Exception e)
        {
            ShowDialog(title, msg, e, null);
        }

        public static void ShowDialog(String title, String msg, Exception e, SkinBundle bundle)
        {
            ErrorDialogEx dlg = new ErrorDialogEx();

            if (bundle != null)
                bundle.SetBundle(dlg);

            dlg.Title = title;
            dlg.lblError.Text = e.GetType().Name + ": " + e.Message + "\n" + e.StackTrace;
            dlg.lblMsg.Text = msg;

            dlg.ShowDialog();
        }

        private ErrorDialogEx()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadedWin(object sender, RoutedEventArgs e)
        {
            MessageTools.MessageBeep(MessageType.ERROR);
        }
    }

    /// @}
}
