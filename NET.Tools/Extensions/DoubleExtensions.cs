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
    public static class DoubleExtensions
    {
        public static String ToByteSizeString(this double d, bool makeSmaller)
        {
            return MathUtils.ToByteSizeString(d, makeSmaller);
        }

        public static String ToByteSizeString(this double d)
        {
            return ToByteSizeString(d, true);
        }

        public unsafe static IntPtr ToPointer(this double d)
        {
            return new IntPtr(&d);
        }

        public static byte[] ToBytes(this double d)
        {
            //Copy to podoubleer
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(double));
            Marshal.Copy(new double[] { d }, 0, ptr, 1);

            //Copy from podoubleer to buffer
            byte[] buffer = new byte[sizeof(double)];
            Marshal.Copy(ptr, buffer, 0, sizeof(double));
            Marshal.FreeHGlobal(ptr);

            return buffer;
        }

        public static double FromBytes(this double d, byte[] buffer)
        {
            //Copy to podoubleer
            IntPtr ptr = Marshal.AllocHGlobal(sizeof(double));
            Marshal.Copy(buffer, 0, ptr, sizeof(double));

            //Copy from podoubleer to double
            double[] res = new double[1];
            Marshal.Copy(ptr, res, 0, 1);
            Marshal.FreeHGlobal(ptr);

            return res[0];
        }

        public static double Round(this double d, int decimals)
        {
            return Math.Round(d, decimals);
        }

        public static double Round(this double d)
        {
            return Math.Round(d);
        }

        public static double Truncate(this double d, byte decimals)
        {
            int pot = 10;
            if (decimals == 0)
                pot = 1;

            for (int i = 1; i < decimals; i++)
                pot *= 10;

            return Math.Truncate(d * pot) / pot;
        }

        public static double Truncate(this double d)
        {
            return Truncate(d, 0);
        }
    }
    /// @}
}
