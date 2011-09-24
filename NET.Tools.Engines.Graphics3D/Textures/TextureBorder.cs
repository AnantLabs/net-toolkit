using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a texture border
    /// </summary>
    public sealed class TextureBorder
    {
        /// <summary>
        /// Gets or sets u border style
        /// </summary>
        public TextureBorderStyle UBorderStyle { get; set; }
        /// <summary>
        /// Gets or sets v border style
        /// </summary>
        public TextureBorderStyle VBorderStyle { get; set; }
        /// <summary>
        /// Gets or sets w border style
        /// </summary>
        public TextureBorderStyle WBorderStyle { get; set; }
        /// <summary>
        /// Gets or sets border color
        /// </summary>
        public Color BorderColor { get; set; }

        public TextureBorder(TextureBorderStyle uborder, TextureBorderStyle vborder,
            Color borderColor)
        {
            UBorderStyle = uborder;
            VBorderStyle = vborder;
            WBorderStyle = TextureBorderStyle.Wrap;
            BorderColor = borderColor;
        }

        public TextureBorder(TextureBorderStyle uborder, TextureBorderStyle vborder)
            : this(uborder, vborder, Color.Transparent)
        {
        }

        public TextureBorder()
            : this(TextureBorderStyle.Wrap, TextureBorderStyle.Wrap)
        {
        }
    }

    /// @}
}
