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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using NET.Tools.WPF;


namespace NET.Tools.Demo
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class MyEffectsWin : Window
    {
        public MyEffectsWin()
        {
            InitializeComponent();
        }

        private void ckbRelief_Checked(object sender, RoutedEventArgs e)
        {
            ((ReliefEffect)imgRelief.Effect).IsGray = 0f;
        }

        private void ckbRelief_Unchecked(object sender, RoutedEventArgs e)
        {
            ((ReliefEffect)imgRelief.Effect).IsGray = 1f;
        }
    }
}
