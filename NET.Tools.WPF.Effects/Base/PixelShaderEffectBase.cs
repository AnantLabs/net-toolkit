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
    /// Abstract basic class for all Pixel-Shader effects
    /// </summary>
    public abstract class PixelShaderEffectBase : ShaderEffect
    {
        #region Static Members

        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty(
                    "Input",
                    typeof(PixelShaderEffectBase),
                    0);

        #endregion

        public PixelShaderEffectBase(PixelShader shader)
        {
            PixelShader = shader;

            UpdateShaderValue(InputProperty);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
    }
}
