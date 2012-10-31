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
    public enum HeaderIconSize : int
    {
        /// <summary>
        /// 16x16
        /// </summary>
        Small = 16,
        /// <summary>
        /// 32x32
        /// </summary>
        Medium = 32,
        /// <summary>
        /// 64x64
        /// </summary>
        Large = 64
    }

    /// <summary>
    /// Interaktionslogik für Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public static readonly DependencyProperty DescriptionBrushProperty =
            DependencyProperty.Register("DescriptionBrush", typeof (Brush), typeof (Header), new PropertyMetadata(null));

        [Browsable(true)]
        [Category("Appearance")]
        public Brush DescriptionBrush
        {
            get { return (Brush) GetValue(DescriptionBrushProperty); }
            set { SetValue(DescriptionBrushProperty, value); }
        }

        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof (ImageSource), typeof (Header), new PropertyMetadata(default(ImageSource)));

        [Browsable(true)]
        [Category("Appearance")]
        public ImageSource IconSource
        {
            get { return (ImageSource) GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public static readonly DependencyProperty DescriptionFontProperty =
            DependencyProperty.Register("DescriptionFont", typeof (WPFFont), typeof (Header), new PropertyMetadata(null));

        [Browsable(true)]
        [Category("Appearance")]
        public WPFFont DescriptionFont
        {
            get { return (WPFFont) GetValue(DescriptionFontProperty); }
            set { SetValue(DescriptionFontProperty, value); }
        }

        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent", typeof (object), typeof (Header), new PropertyMetadata("Header"));

        [Browsable(true)]
        [Category("Appearance")]
        public object HeaderContent
        {
            get { return (object) GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }

        public static readonly DependencyProperty DescriptionTextProperty =
            DependencyProperty.Register("DescriptionText", typeof (String), typeof (Header), new PropertyMetadata("Description"));

        [Browsable(true)]
        [Category("Appearance")]
        public String DescriptionText
        {
            get { return (String) GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof (HeaderIconSize), typeof (Header), new PropertyMetadata(HeaderIconSize.Medium));

        public HeaderIconSize IconSize
        {
            get { return (HeaderIconSize) GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public event RoutedEventHandler IconSizeChanged;

        public Header()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == IconSourceProperty)
            {
                imgIcon.Source = IconSource;
                InvalidateVisual();
            }
            else if (e.Property == DescriptionBrushProperty)
            {
                lblDescription.Foreground = DescriptionBrush;
                InvalidateVisual();
            }
            else if (e.Property == DescriptionFontProperty)
            {
                lblDescription.SetFont(DescriptionFont);
                InvalidateVisual();
            }
            else if (e.Property == HeaderContentProperty)
            {
                lblHeader.Content = HeaderContent;
                InvalidateVisual();
            }
            else if (e.Property == DescriptionTextProperty)
            {
                lblDescription.Text = DescriptionText;
                InvalidateVisual();
            }
            else if (e.Property == IconSizeProperty)
            {
                colImage.MaxWidth = (int)IconSize;
                if (IconSize == HeaderIconSize.Large)
                {
                    Grid.SetRowSpan(imgIcon, 2);
                }
                else
                {
                    Grid.SetRowSpan(imgIcon, 1);
                }

                OnIconSizeChanged();

                InvalidateVisual();
            }
        }

        protected void OnIconSizeChanged()
        {
            if (IconSizeChanged != null)
            {
                IconSizeChanged(this, new RoutedEventArgs());
            }
        }
    }
}
