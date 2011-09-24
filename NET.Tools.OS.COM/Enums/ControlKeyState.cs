using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.OS
{
    [Flags()]
    public enum ControlKeyState
    {
        None = 0x0000,
        RightAltPressed = 0x0001,
        LeftAltPressed = 0x0002,
        RightCtrlPressed = 0x0004,
        LeftCtrlPressed = 0x0008,
        ShiftPressed = 0x0010,
        NumLockOn = 0x0020,
        ScrollLockOn = 0x0040,
        CapsLockOn = 0x0080,
        EnhancedKey = 0x0100
    }
}
