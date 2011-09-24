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
    /// Interaktionslogik für ColorSlider.xaml
    /// </summary>
    public partial class ColorSlider : UserControl
    {
        [Browsable(true)]
        public event RoutedEventHandler ColorChanged;

        [Browsable(true)]
        [Category("Behavior")]
        public Color Color
        {
            get
            {
                return Color.FromScRgb(1f, (float)sldRed.Value,(float)sldGreen.Value, 
                    (float)sldBlue.Value);
            }
            set
            {
                sldRed.Value = value.ScR;
                sldGreen.Value = value.ScG;
                sldBlue.Value = value.ScB;

                DoColorChanged();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public bool AllowNegativeValues
        {
            get { return sldRed.Minimum < 0; }
            set
            {
                if (value)
                {
                    sldRed.Minimum = -1;
                    sldGreen.Minimum = -1;
                    sldBlue.Minimum = -1;
                }
                else
                {
                    sldRed.Minimum = 0;
                    sldGreen.Minimum = 0;
                    sldBlue.Minimum = 0;
                }
            }
        }

        public ColorSlider()
        {
            InitializeComponent();
        }

        protected void DoColorChanged()
        {
            if (ColorChanged != null)
                ColorChanged(this, new RoutedEventArgs());
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DoColorChanged();
        }
    }
}
