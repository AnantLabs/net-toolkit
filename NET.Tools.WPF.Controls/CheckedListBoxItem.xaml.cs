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
using System.ComponentModel;

namespace NET.Tools.WPF
{
    /// <summary>
    /// Interaktionslogik für CheckedListBoxItem.xaml
    /// </summary>
    public partial class CheckedListBoxItem : ListBoxItem
    {
        [Browsable(true)]
        [DefaultValue("")]
        public string Label
        {
            get { return lblName.Content as String; }
            set { lblName.Content = value; }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool? IsChecked
        {
            get { return ckbChecked.IsChecked; }
            set { ckbChecked.IsChecked = value; }
        }

        public CheckedListBoxItem()
        {
            InitializeComponent();
        }

        private void lblName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ckbChecked.IsChecked = !ckbChecked.IsChecked;
        }

        private void ckbChecked_Checked(object sender, RoutedEventArgs e)
        {
            this.IsSelected = true;
        }
    }
}
