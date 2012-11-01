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
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToString(value, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToString(value, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToString(value, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToString(value, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return MathUtils.ToRomanNumerals(value);
                default:
                    throw new NotImplementedException();
            }
        }
    }
    /// @}
}
