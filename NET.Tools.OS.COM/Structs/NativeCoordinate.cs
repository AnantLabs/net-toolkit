using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    /// <summary>
    /// Represent a native coordinate (short x, short y)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeCoordinate
    {
        public short X;
        public short Y;
    }
}
