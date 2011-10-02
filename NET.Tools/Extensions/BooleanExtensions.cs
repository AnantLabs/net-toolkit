using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Gets the Pointer to the boolean
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public unsafe static IntPtr ToPointer(this bool b)
        {
            return new IntPtr(&b);
        }

        public static byte[] ToByte(this bool b)
        {
            return BitConverter.GetBytes(b);
        }

        public static bool FromByte(this bool b, byte[] buffer, int startIndex)
        {
            return BitConverter.ToBoolean(buffer, startIndex);
        }

        public static bool FromByte(this bool b, byte[] buffer)
        {
            return FromByte(b, buffer, 0);
        }
    }
    /// @}
}
