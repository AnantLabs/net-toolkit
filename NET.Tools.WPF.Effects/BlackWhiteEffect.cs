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
    public class BlackWhiteEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = Global.GetPackageUri("Shader/BlackWhiteShader.ps")
            };

        public static readonly DependencyProperty MiddleProperty =
           DependencyProperty.Register(
                   "MiddleValue",
                   typeof(float),
                   typeof(BlackWhiteEffect),
                   new UIPropertyMetadata(0.5f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty HeightColorProperty =
            DependencyProperty.Register(
                    "HeightColor",
                    typeof(Color),
                    typeof(BlackWhiteEffect),
                    new UIPropertyMetadata(Colors.White,
                        PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty LowColorProperty =
            DependencyProperty.Register(
                    "LowColor",
                    typeof(Color),
                    typeof(BlackWhiteEffect),
                    new UIPropertyMetadata(Colors.Black,
                        PixelShaderConstantCallback(2)));

        #endregion

        public BlackWhiteEffect()
            : base(shader)
        {
            MiddleValue = 0.5f;
            HeightColor = Colors.White;
            LowColor = Colors.Black;

            UpdateShaderValue(MiddleProperty);
            UpdateShaderValue(HeightColorProperty);
            UpdateShaderValue(LowColorProperty);
        }

        public float MiddleValue
        {
            get { return (float)GetValue(MiddleProperty); }
            set { SetValue(MiddleProperty, value); }
        }

        public Color HeightColor
        {
            get
            {
                return (Color)GetValue(HeightColorProperty);
            }
            set
            {
                SetValue(HeightColorProperty, value);
            }
        }

        public Color LowColor
        {
            get
            {
                return (Color)GetValue(LowColorProperty);
            }
            set
            {
                SetValue(LowColorProperty, value);
            }
        }
    }
    /// @}
}
