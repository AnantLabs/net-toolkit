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
    /// Interaktionslogik für NimbusSkinWin.xaml
    /// </summary>
    public partial class DemoSkinWin : Window
    {
        public DemoSkinWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
