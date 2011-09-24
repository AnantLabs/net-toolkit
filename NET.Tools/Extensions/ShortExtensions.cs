using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class ShortExtensions
    {
        public unsafe static IntPtr ToPointer(this short s)
        {
            return new IntPtr(&s);
        }

        public static byte[] ToBytes(this short s)
        {
            //Copy to poshorter
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(short));
            Marshal.Copy(new short[] { s }, 0, ptr, 1);

            //Copy from poshorter to buffer
            byte[] buffer = new byte[sizeof(short)];
            Marshal.Copy(ptr, buffer, 0, sizeof(short));
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }

        public static short FromBytes(this short s, byte[] buffer)
        {
            //Copy to poshorter
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(short));
            Marshal.Copy(buffer, 0, ptr, sizeof(short));

            //Copy from poshorter to short
            short[] res = new short[1];
            Marshal.Copy(ptr, res, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return res[0];
        }

        public static sbyte ToLowSByte(this short value)
        {
            return (sbyte)(value & 0xFF);
        }

        public static sbyte ToHightSByte(this short value)
        {
            return (sbyte)(value >> 8);
        }
    }
    /// @}
}
