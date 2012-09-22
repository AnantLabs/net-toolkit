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
    public class PixelEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = Global.GetPackageUri("Shader/PixelShader.ps")
            };

        public static readonly DependencyProperty TranslationXProperty =
           DependencyProperty.Register(
                   "TranslationX",
                   typeof(float),
                   typeof(PixelEffect),
                   new UIPropertyMetadata(0.01f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty TranslationYProperty =
           DependencyProperty.Register(
                   "TranslationY",
                   typeof(float),
                   typeof(PixelEffect),
                   new UIPropertyMetadata(0.01f, PixelShaderConstantCallback(1)));

        #endregion

        public PixelEffect()
            : base(shader)
        {
            TranslationX = 0.01f;
            TranslationY = 0.01f;

            UpdateShaderValue(TranslationXProperty);
            UpdateShaderValue(TranslationYProperty);
        }

        public float TranslationX
        {
            get { return (float)GetValue(TranslationXProperty); }
            set { SetValue(TranslationXProperty, value); }
        }

        public float TranslationY
        {
            get { return (float)GetValue(TranslationYProperty); }
            set { SetValue(TranslationYProperty, value); }
        }
    }
    /// @}
}
