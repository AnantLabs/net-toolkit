using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows;
using System.Windows.Media;


namespace NET.Tools.WPF
{
    /// <summary>
    /// \addtogroup effects 
    /// @{
    /// </summary>
    public class ColorKeyEffect : PixelShaderEffectBase
    {
        #region Static Members

        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/ColorKeyShader.ps")
            };

        public static readonly DependencyProperty ChannelRProperty =
           DependencyProperty.Register(
                   "ChannelR",
                   typeof(float),
                   typeof(ColorKeyEffect),
                   new UIPropertyMetadata(0f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ChannelGProperty =
           DependencyProperty.Register(
                   "ChannelG",
                   typeof(float),
                   typeof(ColorKeyEffect),
                   new UIPropertyMetadata(0f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty ChannelBProperty =
           DependencyProperty.Register(
                   "ChannelB",
                   typeof(float),
                   typeof(ColorKeyEffect),
                   new UIPropertyMetadata(0f, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty ToleranceProperty =
            DependencyProperty.Register(
                    "Tolerance", 
                    typeof (float), 
                    typeof (ColorKeyEffect), 
                    new UIPropertyMetadata(0.3f, PixelShaderConstantCallback(3)));

        #endregion

        public ColorKeyEffect()
            : base(shader)
        {
            ChannelR = 0f;
            ChannelG = 0f;
            ChannelB = 0f;
            Tolerance = 0.3f;

            UpdateShaderValue(ChannelRProperty);
            UpdateShaderValue(ChannelGProperty);
            UpdateShaderValue(ChannelBProperty);
            UpdateShaderValue(ToleranceProperty);
        }

        public float ChannelR
        {
            get { return (float)GetValue(ChannelRProperty); }
            set { SetValue(ChannelRProperty, value); }
        }

        public float ChannelG
        {
            get { return (float)GetValue(ChannelGProperty); }
            set { SetValue(ChannelGProperty, value); }
        }

        public float ChannelB
        {
            get { return (float)GetValue(ChannelBProperty); }
            set { SetValue(ChannelBProperty, value); }
        }

        public Color ColorKey
        {
            get { return Color.FromScRgb(1f, ChannelR, ChannelG, ChannelB); }
            set
            {
                ChannelR = value.ScR;
                ChannelG = value.ScG;
                ChannelB = value.ScB;
            }
        }

        public float Tolerance
        {
            get { return (float)GetValue(ToleranceProperty); }
            set { SetValue(ToleranceProperty, value); }
        }
    }
    /// @}
}
