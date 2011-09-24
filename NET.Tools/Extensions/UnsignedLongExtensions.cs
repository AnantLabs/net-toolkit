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
    public static class UnsignedLongExtensions
    {
        public static String ToByteSizeString(this ulong l, bool makeSmaller)
        {
            if (!makeSmaller)
                return l.ToString("0.00") + " Bytes";

            if (l <= 1024L)
                return l.ToString("0.00") + "B";
            else if (l < 1024L * 1024L)
                return (l / 1024L).ToString("0.00") + "KB";
            else if (l < 1024L * 1024L * 1024L)
                return (l / (1024L * 1024L)).ToString("0.00") + "MB";
            else if (l < 1024L * 1024L * 1024L * 1024L)
                return (l / (1024L * 1024L * 1024L)).ToString("0.00") + "GB";
            else
                return (l / (1024L * 1024L * 1024L * 1024L)).ToString("0.00") + "TB";
        }

        public static String ToByteSizeString(this ulong l)
        {
            return ToByteSizeString(l, true);
        }

        public unsafe static IntPtr ToPointer(this ulong l)
        {
            return new IntPtr(&l);
        }

        public static byte[] ToBytes(this ulong l)
        {
            //Copy to polonger
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(long));
            Marshal.Copy(new long[] { (long)l }, 0, ptr, 1);

            //Copy from polonger to buffer
            byte[] buffer = new byte[sizeof(long)];
            Marshal.Copy(ptr, buffer, 0, sizeof(long));
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }

        public static ulong FromBytes(this ulong l, byte[] buffer)
        {
            //Copy to polonger
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(long));
            Marshal.Copy(buffer, 0, ptr, sizeof(long));

            //Copy from polonger to long
            long[] res = new long[1];
            Marshal.Copy(ptr, res, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return (ulong)res[0];
        }

        public static uint ToLowUInteger(this ulong value)
        {
            return (uint)(value & 0xFFFFFFFF);
        }

        public static uint ToHightUInteger(this ulong value)
        {
            return (uint)(value >> 32);
        }
    }
    /// @}
}
