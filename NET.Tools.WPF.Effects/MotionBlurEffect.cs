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
    public class MotionBlurEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/MotionBlurShader.ps")
            };

        public static readonly DependencyProperty AngleProperty =
           DependencyProperty.Register(
                   "Angle",
                   typeof(float),
                   typeof(MotionBlurEffect),
                   new UIPropertyMetadata(0.1f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty BlurAmountProperty =
           DependencyProperty.Register(
                   "BlurAmount",
                   typeof(float),
                   typeof(MotionBlurEffect),
                   new UIPropertyMetadata(0.005f, PixelShaderConstantCallback(1)));
        #endregion

        public MotionBlurEffect()
            : base(shader)
        {
            Angle = 0.1f;
            BlurAmount = 0.005f;

            UpdateShaderValue(AngleProperty);
            UpdateShaderValue(BlurAmountProperty);
        }

        public float Angle
        {
            get { return (float)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public float BlurAmount
        {
            get { return (float)GetValue(BlurAmountProperty); }
            set { SetValue(BlurAmountProperty, value); }
        }
    }
    /// @}
}
