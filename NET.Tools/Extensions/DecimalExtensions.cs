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
    public static class DecimalExtensions
    {
        public static String ToByteSizeString(this decimal d, bool makeSmaller)
        {
            if (!makeSmaller)
                return d.ToString("0.00") + " Bytes";

            if (d <= 1024)
                return d.ToString("0.00") + "B";
            else if (d < 1024 * 1024)
                return (d / 1024).ToString("0.00") + "KB";
            else if (d < 1024 * 1024 * 1024)
                return (d / (1024 * 1024)).ToString("0.00") + "MB";
            else
                return (d / (1024 * 1024 * 1024)).ToString("0.00") + "GB";
        }

        public static String ToByteSizeString(this decimal d)
        {
            return ToByteSizeString(d, true);
        }

        public unsafe static IntPtr ToPointer(this decimal d)
        {
            return new IntPtr(&d);
        }

        public static decimal Round(this decimal d, int decimals)
        {
            return Math.Round(d, decimals);
        }

        public static decimal Round(this decimal d)
        {
            return Math.Round(d);
        }

        public static decimal Truncate(this decimal d, byte decimals)
        {
            int pot = 10;
            if (decimals == 0)
                pot = 1;

            for (int i = 1; i < decimals; i++)
                pot *= 10;

            return Math.Truncate(d * pot) / pot;
        }

        public static decimal Truncate(this decimal d)
        {
            return Truncate(d, 0);
        }
    }
    /// @}
}
