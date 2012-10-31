using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeFocusInput
    {
        public uint SetFocus;
    }
}
