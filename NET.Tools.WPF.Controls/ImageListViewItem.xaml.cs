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
    /// Interaktionslogik für ImageListViewItem.xaml
    /// </summary>
    public partial class ImageListViewItem : ListViewItem, IImageItem
    {
        [Browsable(true)]
        [Category("Appearance")]
        public new object Content
        {
            get { return lblText.Content; }
            set { lblText.Content = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public ImageSource Icon
        {
            get { return imgIcon.Source; }
            set { imgIcon.Source = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Orientation Orientation
        {
            get { return pnl.Orientation; }
            set
            {
                pnl.Orientation = value;
                switch (value)
                {
                    case Orientation.Horizontal:
                        lblText.HorizontalContentAlignment = HorizontalAlignment.Left;
                        break;
                    case Orientation.Vertical:
                        lblText.HorizontalContentAlignment = HorizontalAlignment.Center;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public ImageListViewItem()
        {
            InitializeComponent();
        }
    }
}
