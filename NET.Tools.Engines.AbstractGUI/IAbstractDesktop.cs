using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Interface for the abstract desktop
    /// </summary>
    public interface IAbstractDesktop
    {
        /// <summary>
        /// Paint itself and all undergrouped components
        /// </summary>
        void Paint();

        void Show(AbstractFrame frame);
        void Hide(AbstractFrame frame);
    }

    /// @}
}
