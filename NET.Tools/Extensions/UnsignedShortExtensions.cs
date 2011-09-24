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
    public static class UnsignedShortExtensions
    {
        public unsafe static IntPtr ToPointer(this ushort s)
        {
            return new IntPtr(&s);
        }

        public static byte[] ToBytes(this ushort s)
        {
            //Copy to poshorter
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(short));
            Marshal.Copy(new short[] { (short)s }, 0, ptr, 1);

            //Copy from poshorter to buffer
            byte[] buffer = new byte[sizeof(short)];
            Marshal.Copy(ptr, buffer, 0, sizeof(short));
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }

        public static ushort FromBytes(this ushort s, byte[] buffer)
        {
            //Copy to poshorter
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(short));
            Marshal.Copy(buffer, 0, ptr, sizeof(short));

            //Copy from poshorter to short
            short[] res = new short[1];
            Marshal.Copy(ptr, res, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return (ushort)res[0];
        }

        public static byte ToLowByte(this ushort value)
        {
            return (byte)(value & 0xFF);
        }

        public static byte ToHightByte(this ushort value)
        {
            return (byte)(value >> 8);
        }
    }
    /// @}
}
