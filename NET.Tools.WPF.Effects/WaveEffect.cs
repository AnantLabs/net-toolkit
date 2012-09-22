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
    public class WaveEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/WaveShader.ps")
            };

        public static readonly DependencyProperty ScaleXProperty =
            DependencyProperty.Register(
                    "ScaleX",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(100f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ScaleYProperty =
            DependencyProperty.Register(
                    "ScaleY",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(0.03f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty MovingXProperty =
            DependencyProperty.Register(
                    "MovingX",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(0f, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty MovingYProperty =
            DependencyProperty.Register(
                    "MovingY",
                    typeof(float),
                    typeof(WaveEffect),
                    new UIPropertyMetadata(0f, PixelShaderConstantCallback(3)));
        #endregion

        public WaveEffect()
            : base(shader)
        {
            ScaleX = 100f;
            ScaleY = 0.03f;
            MovingX = 0f;
            MovingY = 0f;

            UpdateShaderValue(ScaleXProperty);
            UpdateShaderValue(ScaleYProperty);
            UpdateShaderValue(MovingXProperty);
            UpdateShaderValue(MovingYProperty);
        }

        public float ScaleX
        {
            get { return (float)GetValue(ScaleXProperty); }
            set { SetValue(ScaleXProperty, value); }
        }

        public float ScaleY
        {
            get { return (float)GetValue(ScaleYProperty); }
            set { SetValue(ScaleYProperty, value); }
        }

        public float MovingX
        {
            get { return (float)GetValue(MovingXProperty); }
            set { SetValue(MovingXProperty, value); }
        }

        public float MovingY
        {
            get { return (float)GetValue(MovingYProperty); }
            set { SetValue(MovingYProperty, value); }
        }
    }
    /// @}
}
