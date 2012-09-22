using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media.Effects;
using System.Windows;

namespace NET.Tools.WPF
{
    /// <summary>
    /// Create an effect that looks like a cloudy sky with dark clouds
    /// </summary>
    public class SkyEffect : PixelShaderEffectBase
    {
        #region Static Members

        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/SkyShader.ps")
            };

        public static readonly DependencyProperty AlphaProperty =
            DependencyProperty.Register(
                    "Alpha",
                    typeof(float),
                    typeof(SkyEffect),
                    new UIPropertyMetadata(1f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty InvertProperty =
            DependencyProperty.Register(
                    "Invert",
                    typeof(float),
                    typeof(SkyEffect),
                    new UIPropertyMetadata(0f, PixelShaderConstantCallback(1)));

        #endregion

        internal protected SkyEffect(PixelShader pixShader)
            : base(pixShader)
        {
            Alpha = 1f;
            Invert = 0f;

            UpdateShaderValue(AlphaProperty);
            UpdateShaderValue(InvertProperty);
        }

        public SkyEffect()
            : this(shader)
        {
        }

        /// <summary>
        /// Alpha value for the cloud displaying
        /// </summary>
        public float Alpha
        {
            get { return (float)GetValue(AlphaProperty); }
            set { SetValue(AlphaProperty, value); }
        }

        /// <summary>
        /// Invert the alpha value
        /// </summary>
        public float Invert
        {
            get { return (float)GetValue(InvertProperty); }
            set { SetValue(InvertProperty, value); }
        }
    }
}
