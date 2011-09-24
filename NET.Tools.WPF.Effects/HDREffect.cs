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
    public class HDREffect : PixelShaderEffectBase
    {
        #region Static Members

        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/HDRShader.ps")
            };

        public static readonly DependencyProperty HighValueProperty =
            DependencyProperty.Register(
                    "HighValue",
                    typeof(float),
                    typeof(HDREffect),
                    new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty LowValueProperty =
            DependencyProperty.Register(
                    "LowValue",
                    typeof(float),
                    typeof(HDREffect),
                    new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(1)));

        #endregion

        public HDREffect()
            : base(shader)
        {
            HighValue = 0.5f;
            LowValue = 0.5f;

            UpdateShaderValue(LowValueProperty);
            UpdateShaderValue(HighValueProperty);
        }

        public float HighValue
        {
            get { return (float)GetValue(HighValueProperty); }
            set { SetValue(HighValueProperty, value); }
        }

        public float LowValue
        {
            get { return (float)GetValue(LowValueProperty); }
            set { SetValue(LowValueProperty, value); }
        }
    }
    /// @}
}
