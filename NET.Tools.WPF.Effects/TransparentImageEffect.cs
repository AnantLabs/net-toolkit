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
    public class TransparentImageEffect : ImageEffect
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = Global.GetPackageUri("Shader/TransparentImageShader.ps")
            };

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                    "Value",
                    typeof(float),
                    typeof(TransparentImageEffect),
                    new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(1)));

        #endregion

        public TransparentImageEffect()
            : base(shader)
        {
            Value = 0.5f;

            UpdateShaderValue(ValueProperty);
        }

        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
    /// @}
}
