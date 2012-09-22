using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows;


namespace NET.Tools.WPF
{
    /// <summary>
    /// \addtogroup effects 
    /// @{
    /// </summary>
    public class GrayscaleEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/GrayscaleShader.ps")
            };

        public static readonly DependencyProperty ChannelRProperty =
           DependencyProperty.Register(
                   "ChannelR",
                   typeof(float),
                   typeof(GrayscaleEffect),
                   new UIPropertyMetadata(0.3f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ChannelGProperty =
           DependencyProperty.Register(
                   "ChannelG",
                   typeof(float),
                   typeof(GrayscaleEffect),
                   new UIPropertyMetadata(0.59f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty ChannelBProperty =
           DependencyProperty.Register(
                   "ChannelB",
                   typeof(float),
                   typeof(GrayscaleEffect),
                   new UIPropertyMetadata(0.11f, PixelShaderConstantCallback(2)));
        #endregion

        public GrayscaleEffect()
            : base(shader)
        {
            ChannelR = 0.3f;
            ChannelG = 0.59f;
            ChannelB = 0.11f;

            UpdateShaderValue(ChannelRProperty);
            UpdateShaderValue(ChannelGProperty);
            UpdateShaderValue(ChannelBProperty);
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
