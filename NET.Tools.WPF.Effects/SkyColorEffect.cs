using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace NET.Tools.WPF
{
    /// <summary>
    /// Creates an effect that looks like a sky with colored clouds. Default there are white clouds.
    /// </summary>
    public class SkyColorEffect : SkyEffect
    {
        #region Static Members

        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/SkyColorShader.ps")
            };

        /// <summary>
        /// Dependency-Property for the property "NewColor"
        /// </summary>
        public static readonly DependencyProperty NewColorProperty =
            DependencyProperty.Register(
                    "NewColor",
                    typeof(Color),
                    typeof(SkyColorEffect),
                    new UIPropertyMetadata(Colors.White, PixelShaderConstantCallback(2)));

        #endregion

        public SkyColorEffect()
            : base(shader)
        {
            NewColor = Colors.White;

            UpdateShaderValue(NewColorProperty);
        }

        /// <summary>
        /// The new color of sky clouds
        /// </summary>
        public Color NewColor
        {
            get { return (Color)GetValue(NewColorProperty); }
            set { SetValue(NewColorProperty, value); }
        }
    }
}
