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
    public class ColorShiftEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/ColorShiftShader.ps")
            };

        public static readonly DependencyProperty ValueProperty =
           DependencyProperty.Register(
                   "Value",
                   typeof(float),
                   typeof(ColorShiftEffect),
                   new UIPropertyMetadata(0.001f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ChannelRProperty =
           DependencyProperty.Register(
                   "ChannelR",
                   typeof(float),
                   typeof(ColorShiftEffect),
                   new UIPropertyMetadata(-1f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty ChannelGProperty =
           DependencyProperty.Register(
                   "ChannelG",
                   typeof(float),
                   typeof(ColorShiftEffect),
                   new UIPropertyMetadata(1f, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty ChannelBProperty =
           DependencyProperty.Register(
                   "ChannelB",
                   typeof(float),
                   typeof(ColorShiftEffect),
                   new UIPropertyMetadata(-1f, PixelShaderConstantCallback(3)));
        #endregion

        public ColorShiftEffect()
            : base(shader)
        {
            Value = 0.001f;
            ChannelR = -1f;
            ChannelG = 1f;
            ChannelB = -1f;

            UpdateShaderValue(ValueProperty);
            UpdateShaderValue(ChannelRProperty);
            UpdateShaderValue(ChannelGProperty);
            UpdateShaderValue(ChannelBProperty);
        }

        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
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
    }
    /// @}
}
