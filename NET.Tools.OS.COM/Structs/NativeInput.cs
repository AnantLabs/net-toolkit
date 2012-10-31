using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeInput
    {
        [FieldOffset(0)]
        public EventType EventType;
        [FieldOffset(4)]
        public NativeKeyInput KeyEvent;
        [FieldOffset(4)]
        public NativeMouseInput MouseEvent;
        [FieldOffset(4)]
        public NativeBufferSize BufferSizeEvent;
        [FieldOffset(4)]
        public NativeMenuInput MenuEvent;
        [FieldOffset(4)]
        public NativeFocusInput FocusEvent;
    }
}
