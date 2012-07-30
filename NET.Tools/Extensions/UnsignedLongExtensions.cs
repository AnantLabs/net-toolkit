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
                case IntegerStringFormatType.ToHexBinary:
                    return Convert.ToString((long)value, 16);
                case IntegerStringFormatType.ToDecimal:
                    return Convert.ToString((long)value, 10);
                case IntegerStringFormatType.ToOcted:
                    return Convert.ToString((long)value, 8);
                case IntegerStringFormatType.ToBinary:
                    return Convert.ToString((long)value, 2);
                default:
                    throw new NotImplementedException();
            }
        }

        public static short FromString(this ulong value, String str, IntegerStringFormatType type)
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
        public static int GetSetBits(this ulong value)
        {
            return value.ToString(IntegerStringFormatType.ToBinary).GetCountOf('1');
        }
    }
    /// @}
}
