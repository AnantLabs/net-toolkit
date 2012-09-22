using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Media.Effects;


namespace NET.Tools.WPF
{
    /// <summary>
    /// \addtogroup effects 
    /// @{
    /// </summary>
    public class ColorSnowEffect : PixelShaderEffectBase
    {
        #region Static

        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/ColorSnowShader.ps")
            };

        public static readonly DependencyProperty AlphaProperty =
           DependencyProperty.Register(
                   "Alpha",
                   typeof(float),
                   typeof(ColorSnowEffect),
                   new UIPropertyMetadata(0.1f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty DetailsProperty =
           DependencyProperty.Register(
                   "Details",
                   typeof(float),
                   typeof(ColorSnowEffect),
                   new UIPropertyMetadata(0.9f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty RandomProperty =
           DependencyProperty.Register(
                   "Random",
                   typeof(float),
                   typeof(ColorSnowEffect),
                   new UIPropertyMetadata(5f, PixelShaderConstantCallback(2)));

        #endregion

        public ColorSnowEffect()
            : base(shader)
        {
            Alpha = 0.1f;
            Details = 0.9f;
            Random = 5f;

            UpdateShaderValue(AlphaProperty);
            UpdateShaderValue(DetailsProperty);
            UpdateShaderValue(RandomProperty);
        }

        public float Alpha
        {
            get { return (float)GetValue(AlphaProperty); }
            set
            {
                if (!value.IsBetween(0f, 1f))
                    throw new ArgumentOutOfRangeException("Alpha value must be between 0 and 1!");

                SetValue(AlphaProperty, value);
            }
        }

        public float Details
        {
            get { return (float)GetValue(DetailsProperty); }
            set
            {
                if (!value.IsBetween(0f, 1f))
                    throw new ArgumentOutOfRangeException("Details must be between 0 and 1!");

                SetValue(DetailsProperty, value);
            }
        }

        public float Random
        {
            get { return (float)GetValue(RandomProperty); }
            set { SetValue(RandomProperty, value); }
        }

    }
    /// @}
}
