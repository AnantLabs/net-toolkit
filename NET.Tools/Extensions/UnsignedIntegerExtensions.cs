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
            return MathUtils.ToByteSizeString(i, makeSmaller);
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
            return BitConverter.GetBytes(i);
        }

        public static uint FromBytes(this uint i, byte[] buffer)
        {
            return BitConverter.ToUInt32(buffer, 0);
        }

        public static ushort ToLowUShort(this uint value)
        {
            return (ushort)(value & 0xFFFF);
        }

        public static ushort ToHightUShort(this uint value)
        {
            return (ushort)(value >> 16);
        }

        public static String ToString(this uint value, IntegerStringFormatType type)
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
                default:
                    throw new NotImplementedException();
            }
        }

        public static short FromString(this uint value, String str, IntegerStringFormatType type)
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
        public static int GetSetBits(this uint value)
        {
            return value.ToString(IntegerStringFormatType.ToBinary).GetCountOf('1');
        }
    }
    /// @}
}
