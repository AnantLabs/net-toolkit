using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// <summary>
    /// Interface for the abstract button
    /// </summary>
    public interface IAbstractButton
    {
        /// <summary>
        /// Defines that the button is the default (RETURN) button of a dialog or window
        /// </summary>
        bool IsDefault { get; set; }
        /// <summary>
        /// Defines that the button is the cancel (ESCAPE) button of a dialog or a window
        /// </summary>
        bool IsCancel { get; set; }
    }
}
