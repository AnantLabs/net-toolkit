using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    public interface IStyle
    {
        void Paint(Component button);
        void Repaint(Component button);
        void OnClick(Component button);
        void OnEnabledChanged(Component component);
        void OnMouseEnter(Component component);
        void OnMouseLeave(Component component);
        void OnMouseMove(Component component);
    }

    /// @}
}
