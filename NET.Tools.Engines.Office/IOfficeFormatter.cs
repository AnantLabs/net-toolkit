using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Office
{
    /// \addtogroup office
    /// @{

    /// <summary>
    /// Represent an Office formatter for text formatting
    /// </summary>
    public interface IOfficeFormatter : IDisposable
    {
        /// <summary>
        /// Foreground color of text
        /// </summary>
        Color Foreground { get; set; }
        /// <summary>
        /// Background color of text
        /// </summary>
        Color Background { get; set; }
        /// <summary>
        /// Font of text
        /// </summary>
        Font Font { get; set; }

        /// <summary>
        /// Returns the selected text
        /// </summary>
        String Text { get; }
    }

    /// @}
}
