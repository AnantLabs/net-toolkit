using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.OS
{
    public enum EventType : ushort
    {
        Focus = 0x0010,
        Key = 0x0001,
        Menu = 0x0008,
        Mouse = 0x0002,
        WindowBufferSize = 0x0004
    }
}
