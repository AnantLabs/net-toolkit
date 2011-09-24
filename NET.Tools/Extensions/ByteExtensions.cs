using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for bytes
    /// </summary>
    public static class ByteExtensions
    {
        public unsafe static IntPtr ToPointer(this byte b)
        {
            return new IntPtr(&b);
        }
    }
    /// @}
}
