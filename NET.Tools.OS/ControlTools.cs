using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    /// <summary>
    /// \defgroup dlltools Default System Tools
    /// \addtogroup dlltools
    /// @{
    /// </summary>
    public static class ControlTools
    {
        public static bool StopControlRepaint(IntPtr ptr)
        {
            return User32.LockWindowUpdate(ptr);
        }

        public static bool RunAllControlRepaint()
        {
            return User32.LockWindowUpdate(IntPtr.Zero);
        }

        public static bool StopControlRepaint(this Control c)
        {
            return StopControlRepaint(c.Handle);
        }

        public static bool RunAllControlRepaint(this Control c)
        {
            return RunAllControlRepaint();
        }
    }
    /// @}
}
