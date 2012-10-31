using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeMouseInput
    {
        [FieldOffset(0)]
        public NativeCoordinate MousePosition;
        [FieldOffset(4)]
        public NativeMouseButton ButtonState;
        [FieldOffset(8)]
        public uint ControlKeyState;
        [FieldOffset(12)]
        public uint EventFlags;
    }
}
