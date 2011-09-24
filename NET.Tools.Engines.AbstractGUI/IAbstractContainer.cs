using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Interface for all abstract containers
    /// </summary>
    public interface IAbstractContainer
    {
        /// <summary>
        /// Gets the list interface of all children of this container
        /// </summary>
        IList<AbstractComponent> Children { get; }
    }

    /// @}
}
