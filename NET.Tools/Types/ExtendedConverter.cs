using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Extended Convertion class for integer numbers
    /// </summary>
    public static class ExtendedConverter
    {
        public static byte ConvertStringToByte(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToByte(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToByte(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToByte(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToByte(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return (byte) MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }

        public static sbyte ConvertStringToSByte(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToSByte(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToSByte(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToSByte(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToSByte(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return (sbyte)MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }

        public static short ConvertStringToShort(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToInt16(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToInt16(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToInt16(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToInt16(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return (short)MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }

        public static ushort ConvertStringToUShort(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToUInt16(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToUInt16(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToUInt16(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToUInt16(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return (ushort)MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }

        public static int ConvertStringToInteger(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToInt32(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToInt32(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToInt32(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToInt32(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return (int)MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }

        public static uint ConvertStringToUInteger(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToUInt32(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToUInt32(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToUInt32(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToUInt32(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return (uint)MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }

        public static long ConvertStringToLong(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToInt64(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToInt64(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToInt64(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToInt64(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }

        public static ulong ConvertStringToULong(String str, IntegerStringFormatType type)
        {
            switch (type)
            {
                case IntegerStringFormatType.HexBinary:
                    return Convert.ToUInt64(str, 16);
                case IntegerStringFormatType.Decimal:
                    return Convert.ToUInt64(str, 10);
                case IntegerStringFormatType.Octed:
                    return Convert.ToUInt64(str, 8);
                case IntegerStringFormatType.Binary:
                    return Convert.ToUInt64(str, 2);
                case IntegerStringFormatType.RomanNumeral:
                    return (ulong)MathUtils.FromRomanNumerals(str);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
