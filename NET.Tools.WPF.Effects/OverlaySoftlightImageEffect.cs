using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media.Effects;

namespace NET.Tools.WPF
{
    /// <summary>
    /// \addtogroup effects 
    /// @{
    /// </summary>
    public class OverlaySoftlightImageEffect : ImageEffect
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/OverlaySoftlightImageShader.ps")
            };
        #endregion

        public OverlaySoftlightImageEffect()
            : base(shader)
        {
        }
    }
    /// @}
}
