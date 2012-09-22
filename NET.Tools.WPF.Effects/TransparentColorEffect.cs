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
    public class TransparentColorEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = Global.GetPackageUri("Shader/TransparentColorShader.ps")
            };

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                    "Color",
                    typeof(Color),
                    typeof(TransparentColorEffect),
                    new UIPropertyMetadata(Colors.White, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                    "Value",
                    typeof(float),
                    typeof(TransparentColorEffect),
                    new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(1)));
        #endregion

        public TransparentColorEffect()
            : base(shader)
        {
            Color = Colors.White;
            Value = 0.5f;

            UpdateShaderValue(ValueProperty);
            UpdateShaderValue(ColorProperty);
        }

        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
    /// @}
}
