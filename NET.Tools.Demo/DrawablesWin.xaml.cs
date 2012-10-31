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

namespace NET.Tools
{
    /// <summary>
    /// Interaktionslogik für DrawablesWin.xaml
    /// </summary>
    public partial class DrawablesWin : Window
    {
        public DrawablesWin()
        {
            InitializeComponent();
        }

        private void coordinateSystem1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Console.WriteLine(e.Delta);
        }
    }
}
