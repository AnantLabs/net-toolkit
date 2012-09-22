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
using System.Windows.Markup;
using System.Threading;

namespace NET.Tools.WPF
{
    /// <summary>
    /// Interaktionslogik für FontComboBox.xaml
    /// </summary>
    public partial class FontComboBox : UserControl
    {
        [Browsable(true)]
        public int SelectedIndex
        {
            get { return cmbFonts.SelectedIndex; }
            set { cmbFonts.SelectedIndex = value; }
        }

        [Browsable(false)]
        public FontFamily SelectedFont
        {
            get { return (cmbFonts.SelectedItem as ComboBoxItem).Tag as FontFamily; }
        }

        public FontComboBox()
        {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            //Console.WriteLine(Fonts.SystemFontFamilies.Count);

            cmbFonts.Items.Clear();
            foreach (FontFamily ff in Fonts.SystemFontFamilies)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = ff.Source;
                item.FontFamily = ff;
                item.Tag = ff;

                cmbFonts.Items.Add(item);
            }
            cmbFonts.SelectedIndex = 0;
        }
    }
}
