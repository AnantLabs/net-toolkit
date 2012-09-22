using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct NativeKeyInput
    {
        [FieldOffset(0),MarshalAs(UnmanagedType.Bool)]
        public bool KeyDown;
        [FieldOffset(4), MarshalAs(UnmanagedType.U2)]
        public short RepeatCount;
        [FieldOffset(6), MarshalAs(UnmanagedType.U2)]
        public short VirtualKeyCode;
        [FieldOffset(8), MarshalAs(UnmanagedType.U2)]
        public short VirtualScanCode;
        [FieldOffset(10)]
        public char UnicodeChar;
        [FieldOffset(12), MarshalAs(UnmanagedType.U4)]
        public ControlKeyState ControlKeyState;
    }
}
