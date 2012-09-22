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

namespace NET.Tools.Demo
{
    /// <summary>
    /// Interaktionslogik für StartWin.xaml
    /// </summary>
    public partial class StartWin : Window
    {
        public StartWin()
        {
            InitializeComponent();

            this.Title += " (" + new AssemblyInfo(GetType().Assembly).AssemblyVersion + ")";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnWPF_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new StartWPFWin().ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void btnForms_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new StartForm().ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
