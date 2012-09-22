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
    public class DarkenImageEffect : ImageEffect
    {
        #region Static Members
        private readonly static PixelShader shader =
            new PixelShader()
            {
                UriSource = Global.GetPackageUri("Shader/DarkenImageShader.ps")
            };
        #endregion

        public DarkenImageEffect()
            : base(shader)
        {
        }
    }
    /// @}
}
