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
    public static class UnsignedIntegerExtensions
    {
        public static String ToByteSizeString(this uint i, bool makeSmaller)
        {
            if (!makeSmaller)
                return i.ToString("0.00") + " Bytes";

            if (i <= 1024)
                return i.ToString("0.00") + "B";
            else if (i < 1024 * 1024)
                return (i / 1024).ToString("0.00") + "KB";
            else if (i < 1024 * 1024 * 1024)
                return (i / (1024 * 1024)).ToString("0.00") + "MB";
            else
                return (i / (1024 * 1024 * 1024)).ToString("0.00") + "GB";
        }

        public static String ToByteSizeString(this uint i)
        {
            return ToByteSizeString(i, true);
        }

        public unsafe static IntPtr ToPointer(this uint i)
        {
            return new IntPtr(&i);
        }

        public static byte[] ToBytes(this uint i)
        {
            //Copy to pointer
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(int));
            Marshal.Copy(new int[] { (int)i }, 0, ptr, 1);

            //Copy from pointer to buffer
            byte[] buffer = new byte[sizeof(int)];
            Marshal.Copy(ptr, buffer, 0, sizeof(int));
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }

        public static uint FromBytes(this uint i, byte[] buffer)
        {
            //Copy to pointer
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(int));
            Marshal.Copy(buffer, 0, ptr, sizeof(int));

            //Copy from pointer to int
            int[] res = new int[1];
            Marshal.Copy(ptr, res, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return (uint)res[0];
        }

        public static ushort ToLowUShort(this uint value)
        {
            return (ushort)(value & 0xFFFF);
        }

        public static ushort ToHightUShort(this uint value)
        {
            return (ushort)(value >> 16);
        }
    }
    /// @}
}
