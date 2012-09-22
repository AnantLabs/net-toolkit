using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows;

namespace NET.Tools.WPF
{
    public class ImageShiftEffect : ImageEffect
    {
        #region Static Members

        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/ImageShiftShader.ps")
            };

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                    "Value",
                    typeof(float),
                    typeof(ImageShiftEffect),
                    new UIPropertyMetadata(0.001f, PixelShaderConstantCallback(1)));

        #endregion

        public ImageShiftEffect()
            : base(shader)
        {
            Value = 0.001f;

            UpdateShaderValue(ValueProperty);
        }

        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
