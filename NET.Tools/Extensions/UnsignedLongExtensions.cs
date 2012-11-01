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
            return MathUtils.ToByteSizeString(l, makeSmaller);
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
            return BitConverter.GetBytes(l);
        }

        public static ulong FromBytes(this ulong l, byte[] buffer)
        {
            return BitConverter.ToUInt64(buffer, 0);
        }

        public static uint ToLowUInteger(this ulong value)
        {
            return (uint)(value & 0xFFFFFFFF);
        }

        public static uint ToHightUInteger(this ulong value)
        {
            return (uint)(value >> 32);
        }

        public static String ToString(this ulong value, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToString((long)value, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToString((long)value, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToString((long)value, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToString((long)value, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return MathUtils.ToRomanNumerals((long)value);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the number of set bits (1)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetSetBits(this ulong value)
        {
            return value.ToString(IntegerStringFormatType.Binary).GetCountOf('1');
        }
    }
    /// @}
}
