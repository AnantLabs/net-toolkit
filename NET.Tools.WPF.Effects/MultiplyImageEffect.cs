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
    public class MultiplyImageEffect : ImageEffect
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/Shader/MultiplyImageShader.ps")
            };
        #endregion

        public MultiplyImageEffect()
            : base(shader)
        {
        }
    }
    /// @}
}
