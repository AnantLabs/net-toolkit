using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows;


namespace NET.Tools.WPF
{
    /// <summary>
    /// Abstract basic class for all only image pixel effects
    /// </summary>
    public abstract class ImageEffect : ChangableEffect
    {
        #region Static Members

        public static readonly DependencyProperty ImageProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty(
                    "Image",
                    typeof(ImageEffect),
                    1);

        #endregion

        public ImageEffect(PixelShader shader)
            : base(shader)
        {
            UpdateShaderValue(ImageProperty);
        }

        public Brush Image
        {
            get { return (Brush)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
    }
}
