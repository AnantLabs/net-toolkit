using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    public interface IInputHandler
    {
        event MouseEventHandler MouseMove;
        event MouseEventHandler MouseClick;
        event MouseEventHandler MouseWheel;
    }

    /// @}
}
