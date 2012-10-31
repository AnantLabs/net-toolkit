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
    public class ReliefEffect : PixelShaderEffectBase
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/ReliefShader.ps")
            };

        public static readonly DependencyProperty MovingProperty =
            DependencyProperty.Register(
                    "Moving",
                    typeof(float),
                    typeof(ReliefEffect),
                    new UIPropertyMetadata(0.003f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty InterpolarProperty =
            DependencyProperty.Register(
                    "Interpolar",
                    typeof(float),
                    typeof(ReliefEffect),
                    new UIPropertyMetadata(2.7f, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty IsGrayProperty =
            DependencyProperty.Register(
                    "IsGray",
                    typeof(float),
                    typeof(ReliefEffect),
                    new UIPropertyMetadata(1f, PixelShaderConstantCallback(2)));
        #endregion

        public ReliefEffect()
            : base(shader)
        {
            Moving = 0.003f;
            Interpolar = 2.7f;
            IsGray = 1f;

            UpdateShaderValue(MovingProperty);
            UpdateShaderValue(InterpolarProperty);
            UpdateShaderValue(IsGrayProperty);
        }

        public float Moving
        {
            get { return (float)GetValue(MovingProperty); }
            set { SetValue(MovingProperty, value); }
        }

        public float Interpolar
        {
            get { return (float)GetValue(InterpolarProperty); }
            set { SetValue(InterpolarProperty, value); }
        }

        public float IsGray
        {
            get { return (float)GetValue(IsGrayProperty); }
            set { SetValue(IsGrayProperty, value); }
        }
    }
    /// @}
}
