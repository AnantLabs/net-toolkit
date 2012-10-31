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





using System.Threading;
using NET.Tools.WPF;
using NET.Tools.WPF.Skins;

namespace NET.Tools.Demo
{
    /// <summary>
    /// Interaktionslogik für FramesWin.xaml
    /// </summary>
    public partial class DialogWin : Window
    {
        private SkinBundle activeBundle = null;

        public DialogWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new NotImplementedException("My Exception");
            }
            catch (Exception ee)
            {
                ErrorDialogEx.ShowDialog("My Title", "My Message", ee, 
                    activeBundle);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogEx.ShowDialog(
                "Hello!", "Info", MessageButtons.OK, MessageIcons.Info,
                activeBundle);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (WorkingDialogEx.ShowDialog("Working", "The process is working...", (s, ee) =>
                {
                    ee.Maximum = 500;
                    ee.HideKBS();

                    for (int i = 1; i <= 500; i++)
                    {
                        ee.Value = i;
                        ee.ShowTime(500, i);

                        Thread.Sleep(10);
                    }
                }, activeBundle))
                MessageBox.Show("OK");
            else
                MessageBox.Show("Canceled!");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            LoginDialogEx.ShowDialog("Login", "Login", "Please enter your username and your password!", "Username:", 
                "", null, activeBundle,
                (user, password) => { return (user.ToLower().Equals("user") || password.Equals("12345")); });
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            String res = InputDialogEx.ShowDialog("Input", "Please enter a string:", "MyString", MessageIcons.None, activeBundle);
            if (res == null)
                MessageDialogEx.ShowDialog("Cancel!", "Info", MessageButtons.OK, MessageIcons.Info, activeBundle);
            else
                MessageDialogEx.ShowDialog("String: " + res, "Info", MessageButtons.OK, MessageIcons.Info, activeBundle);
        }

        private void lstSkins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSkins.SelectedIndex < 0)
                activeBundle = null;
            else
            {
                switch ((lstSkins.SelectedItem as ListBoxItem).Content.ToString().ToLower())
                {
                    case "default":
                        activeBundle = null;
                        break;
                    case "nimbus":
                        activeBundle = NimbusSkin.SkinBundle;
                        break;
                    case "paper":
                        activeBundle = PaperSkin.SkinBundle;
                        break;
                    case "sims 3":
                        activeBundle = Sims3Skin.SkinBundle_Random;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
