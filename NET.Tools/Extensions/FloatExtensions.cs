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
    public static class FloatExtensions
    {
        public static String ToByteSizeString(this float f, bool makeSmaller)
        {
            if (!makeSmaller)
                return f.ToString("0.00") + " Bytes";

            if (f <= 1024f)
                return f.ToString("0.00") + "B";
            else if (f < 1024f * 1024f)
                return (f / 1024f).ToString("0.00") + "KB";
            else if (f < 1024f * 1024f * 1024f)
                return (f / (1024f * 1024f)).ToString("0.00") + "MB";
            else if (f < 1024f * 1024f * 1024f * 1024f)
                return (f / (1024f * 1024f * 1024f)).ToString("0.00") + "GB";
            else
                return (f / (1024f * 1024f * 1024f * 1024f)).ToString("0.00") + "TB";
        }

        public static String ToByteSizeString(this float f)
        {
            return ToByteSizeString(f, true);
        }

        public unsafe static IntPtr ToPointer(this float f)
        {
            return new IntPtr(&f);
        }

        public static byte[] ToBytes(this float f)
        {
            //Copy to pofloater
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(float));
            Marshal.Copy(new float[] { f }, 0, ptr, 1);

            //Copy from pofloater to buffer
            byte[] buffer = new byte[sizeof(float)];
            Marshal.Copy(ptr, buffer, 0, sizeof(float));
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }

        public static float FromBytes(this float f, byte[] buffer)
        {
            //Copy to pofloater
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(float));
            Marshal.Copy(buffer, 0, ptr, sizeof(float));

            //Copy from pofloater to float
            float[] res = new float[1];
            Marshal.Copy(ptr, res, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return res[0];
        }

        public static float Round(this float f, int decimals)
        {
            return (float)Math.Round(f, decimals);
        }

        public static float Round(this float f)
        {
            return (float)Math.Round(f);
        }

        public static float Truncate(this float f, byte decimals)
        {
            int pot = 10;
            if (decimals == 0)
                pot = 1;

            for (int i = 1; i < decimals; i++)
                pot *= 10;

            return (float)(Math.Truncate(f * pot) / pot);
        }

        public static float Truncate(this float f)
        {
            return Truncate(f, 0);
        }
    }
    /// @}
}
