using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Interface for an abstract window
    /// </summary>
    public interface IAbstractWindow
    {
        /// <summary>
        /// Gets or sets the visibility of the minimize button
        /// </summary>
        bool ShowMinimzeButton { get; set; }
        /// <summary>
        /// Gets or sets the visibility of the maximize button
        /// </summary>
        bool ShowMaximizeButton { get; set; }
    }

    /// @}
}
