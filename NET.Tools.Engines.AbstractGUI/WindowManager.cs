using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    public static class WindowManager
    {
        internal static List<Window> WindowList { get; private set; }

        static WindowManager()
        {
            WindowList = new List<Window>();
        }

        public static void PaintAll()
        {
            foreach (Window window in WindowList)
            {
                window.Paint();
            }
        }
    }

    /// @}
}
