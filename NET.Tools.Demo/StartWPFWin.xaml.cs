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
    public partial class StartWPFWin : Window
    {
        public StartWPFWin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEffects_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new MyEffectsWin().ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void btnAnimations_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new AnimationWin().ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void btnCodeComplexEffects_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new CodeComplexEffectsWin().ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void btnSkins_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new SkinWin().ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new DialogWin().ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void btnComponents_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new ComponentsWin().ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
