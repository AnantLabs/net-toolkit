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






namespace NET.Tools.Demo
{
    /// <summary>
    /// Interaktionslogik für SkinWin.xaml
    /// </summary>
    public partial class SkinWin : Window
    {
        private SkinBundle activeBundle = null;

        public SkinWin()
        {
            InitializeComponent();
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
                    case "chalk":
                        activeBundle = ChalkSkin.SkinBundle;
                        break;
                    case "art":
                        activeBundle = ArtSkin.SkinBundle;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            DemoSkinWin win = new DemoSkinWin();
            if (activeBundle != null)
                activeBundle.SetBundle(win);
            win.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
