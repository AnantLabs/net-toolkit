using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class SByteExtensions
    {
        public unsafe static IntPtr ToPointer(this sbyte b)
        {
            return new IntPtr(&b);
        }
    }
    /// @}
}
