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
            return MathUtils.ToByteSizeString(f, makeSmaller);
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
            return BitConverter.GetBytes(f);
        }

        public static float FromBytes(this float f, byte[] buffer)
        {
            return (float)BitConverter.ToSingle(buffer, 0);
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
