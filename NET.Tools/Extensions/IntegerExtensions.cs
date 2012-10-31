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
    public static class IntegerExtensions
    {
        public static String ToByteSizeString(this int i, bool makeSmaller)
        {
            return MathUtils.ToByteSizeString(i, makeSmaller);
        }

        public static String ToByteSizeString(this int i)
        {
            return ToByteSizeString(i, true);
        }

        public unsafe static IntPtr ToPointer(this int i)
        {
            return new IntPtr(&i);
        }

        public static byte[] ToBytes(this int f)
        {
            return BitConverter.GetBytes(f);
        }

        public static int FromBytes(this int f, byte[] buffer)
        {
            return BitConverter.ToInt32(buffer, 0);
        }

        public static short ToLowShort(this int value)
        {
            return (short)(value & 0xFFFF);
        }

        public static short ToHightShort(this int value)
        {
            return (short)(value >> 16);
        }

        public static String ToString(this int value, IntegerStringFormatType type)
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

        public static int FromString(this byte value, String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.ToHexBinary:
                    return Convert.ToInt32(str, 16);
                case IntegerStringFormatType.ToDecimal:
                    return Convert.ToInt32(str, 10);
                case IntegerStringFormatType.ToOcted:
                    return Convert.ToInt32(str, 8);
                case IntegerStringFormatType.ToBinary:
                    return Convert.ToInt32(str, 2);
                default:
                    throw new NotImplementedException();
            }
        }
    }
    /// @}
}
