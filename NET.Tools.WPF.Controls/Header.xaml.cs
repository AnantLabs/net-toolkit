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
    /// Interaktionslogik für Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        private Color topColor, bottomColor;

        [Browsable(true)]
        [Category("Appearance")]
        public Color TopColor
        {
            get { return topColor; }
            set { topColor = value; BuildBrush(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Color BottomColor
        {
            get { return bottomColor; }
            set { bottomColor = value; BuildBrush(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Brush HeaderColor
        {
            get { return lblHeader.Foreground; }
            set { lblHeader.Foreground = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Brush InfoColor
        {
            get { return lblDescription.Foreground; }
            set { lblDescription.Foreground = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontFamily HeaderFontFamily
        {
            get { return lblHeader.FontFamily; }
            set { lblHeader.FontFamily = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public double HeaderFontSize
        {
            get { return lblHeader.FontSize; }
            set { lblHeader.FontSize = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontWeight HeaderFontWeight
        {
            get { return lblHeader.FontWeight; }
            set { lblHeader.FontWeight = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontStretch HeaderFontStretch
        {
            get { return lblHeader.FontStretch; }
            set { lblHeader.FontStretch = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontStyle HeaderFontStyle
        {
            get { return lblHeader.FontStyle; }
            set { lblHeader.FontStyle = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontFamily InfoFontFamily
        {
            get { return lblDescription.FontFamily; }
            set { lblDescription.FontFamily = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public double InfoFontSize
        {
            get { return lblDescription.FontSize; }
            set { lblDescription.FontSize = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontWeight InfoFontWeight
        {
            get { return lblDescription.FontWeight; }
            set { lblDescription.FontWeight = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontStyle InfoFontStyle
        {
            get { return lblDescription.FontStyle; }
            set { lblDescription.FontStyle = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public FontStretch InfoFontStretch
        {
            get { return lblDescription.FontStretch; }
            set { lblDescription.FontStretch = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public String HeaderText
        {
            get { return lblHeader.Content as String; }
            set { lblHeader.Content = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public String InfoText
        {
            get { return lblDescription.Content as String; }
            set { lblDescription.Content = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public ImageSource Icon
        {
            get { return imgIcon.Source; }
            set { imgIcon.Source = value; }
        }

        [Browsable(false)]
        public WPFFont HeaderFont
        {
            get
            {
                return new WPFFont(
                    HeaderFontFamily,
                    HeaderFontSize,
                    HeaderFontStyle,
                    HeaderFontWeight,
                    HeaderFontStretch);
            }
            set
            {
                HeaderFontFamily = value;
                HeaderFontSize = value;
                HeaderFontStretch = value;
                HeaderFontStyle = value;
                HeaderFontWeight = value;
            }
        }

        [Browsable(false)]
        public WPFFont InfoFont
        {
            get
            {
                return new WPFFont(
                    InfoFontFamily,
                    InfoFontSize,
                    InfoFontStyle,
                    InfoFontWeight,
                    InfoFontStretch);
            }
            set
            {
                InfoFontFamily = value;
                InfoFontSize = value;
                InfoFontStretch = value;
                InfoFontStyle = value;
                InfoFontWeight = value;
            }
        }

        public Header()
        {
            InitializeComponent();
            HeaderColor = SystemColors.ActiveCaptionTextBrush;
            InfoColor = SystemColors.ActiveCaptionTextBrush;

            topColor = SystemColors.ActiveCaptionColor;
            bottomColor = SystemColors.GradientActiveCaptionColor;
            BuildBrush();
        }

        private void BuildBrush()
        {
            LinearGradientBrush brush = new LinearGradientBrush(
                TopColor, BottomColor, 
                new Point(0, 0), new Point(0, 1));
            grdMain.Background = brush;
        }
    }
}
