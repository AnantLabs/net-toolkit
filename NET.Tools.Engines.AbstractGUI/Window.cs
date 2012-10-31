using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    public sealed class Window : Container
    {
        public Window()
        {
            WindowManager.WindowList.Add(this);
        }

        protected override void InternalPaint()
        {
            Style.Paint(this);
        }

        protected override void InternalRepaint()
        {
            Style.Repaint(this);
        }

        public void Close()
        {
            IsVisible = false;
            WindowManager.WindowList.Remove(this);
            //TODO ERROR HANDLING
        }
    }

    /// @}
}
