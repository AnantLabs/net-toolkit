using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows;


namespace NET.Tools.WPF
{
    /// \defgroup effects WPF-Effects
    /// \addtogroup effects 
    /// @{

    /// <summary>
    /// Alpha Effect
    /// </summary>
    public class AlphaEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/AlphaShader.ps")
            };

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                    "Value",
                    typeof(float),
                    typeof(AlphaEffect),
                    new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(0)));
        #endregion

        public AlphaEffect() 
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
