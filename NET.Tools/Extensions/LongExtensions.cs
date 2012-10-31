using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for long
    /// </summary>
    public static class LongExtensions
    {
        public static String ToByteSizeString(this long l, bool makeSmaller)
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

        public static String ToByteSizeString(this long l)
        {
            return ToByteSizeString(l, true);
        }

        public unsafe static IntPtr ToPointer(this long l)
        {
            return new IntPtr(&l);
        }

        public static byte[] ToBytes(this long l)
        {
            return BitConverter.GetBytes(l);
        }

        public static long FromBytes(this long l, byte[] buffer)
        {
            return BitConverter.ToInt64(buffer, 0);
        }

        public static int ToLowInteger(this long value)
        {
            return (int)(value & 0xFFFFFFFF);
        }

        public static int ToHightInteger(this long value)
        {
            return (int)(value >> 32);
        }

        public static String ToString(this long value, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.ToHexBinary:
                    return Convert.ToString(value, 16);
                case IntegerStringFormatType.ToDecimal:
                    return Convert.ToString(value, 10);
                case IntegerStringFormatType.ToOcted:
                    return Convert.ToString(value, 8);
                case IntegerStringFormatType.ToBinary:
                    return Convert.ToString(value, 2);
                case IntegerStringFormatType.ToRomanNumeral:
                    return MathUtils.ToRomanNumerals(value);
                default:
                    throw new NotImplementedException();
            }
        }

        public static short FromString(this long value, String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.ToHexBinary:
                    return Convert.ToInt16(str, 16);
                case IntegerStringFormatType.ToDecimal:
                    return Convert.ToInt16(str, 10);
                case IntegerStringFormatType.ToOcted:
                    return Convert.ToInt16(str, 8);
                case IntegerStringFormatType.ToBinary:
                    return Convert.ToInt16(str, 2);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the number of set bits (1)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetSetBits(this long value)
        {
            return value.ToString(IntegerStringFormatType.ToBinary).GetCountOf('1');
        }
    }
    /// @}
}
