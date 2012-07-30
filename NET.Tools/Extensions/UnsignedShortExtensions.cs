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
    public static class UnsignedShortExtensions
    {
        public static String ToByteSizeString(this ushort i, bool makeSmaller)
        {
            return MathUtils.ToByteSizeString(i, makeSmaller);
        }

        public static String ToByteSizeString(this ushort i)
        {
            return ToByteSizeString(i, true);
        }

        public unsafe static IntPtr ToPointer(this ushort s)
        {
            return new IntPtr(&s);
        }

        public static byte[] ToBytes(this ushort s)
        {
            return BitConverter.GetBytes(s);
        }

        public static ushort FromBytes(this ushort s, byte[] buffer)
        {
            return BitConverter.ToUInt16(buffer, 0);
        }

        public static byte ToLowByte(this ushort value)
        {
            return (byte)(value & 0xFF);
        }

        public static byte ToHightByte(this ushort value)
        {
            return (byte)(value >> 8);
        }

        public static String ToString(this ushort value, IntegerStringFormatType type)
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

        public static short FromString(this ushort value, String str, IntegerStringFormatType type)
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
        public static int GetSetBits(this ushort value)
        {
            return value.ToString(IntegerStringFormatType.ToBinary).GetCountOf('1');
        }
    }
    /// @}
}
