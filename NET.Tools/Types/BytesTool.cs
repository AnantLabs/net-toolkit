using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Tool for building the types from byte array
    /// </summary>
    public static class BytesTool
    {
        public static short ShortFromBytes(byte[] buffer)
        {
            return ShortExtensions.FromBytes(0, buffer);
        }

        public static int IntegerFromBytes(byte[] buffer)
        {
            return IntegerExtensions.FromBytes(0, buffer);
        }

        public static long LongFromBytes(byte[] buffer)
        {
            return LongExtensions.FromBytes(0, buffer);
        }

        public static double DoubleFromBytes(byte[] buffer)
        {
            return DoubleExtensions.FromBytes(0, buffer);
        }

        public static float FloatFromBytes(byte[] buffer)
        {
            return FloatExtensions.FromBytes(0, buffer);
        }

        public static char CharacterFromBytes(byte[] buffer)
        {
            return CharacterExtensions.FromBytes(' ', buffer);
        }

        public static ushort UnsignedShortFromBytes(byte[] buffer)
        {
            return UnsignedShortExtensions.FromBytes(0, buffer);
        }

        public static uint UnsignedIntegerFromBytes(byte[] buffer)
        {
            return UnsignedIntegerExtensions.FromBytes(0, buffer);
        }

        public static ulong UnsignedLongFromBytes(byte[] buffer)
        {
            return UnsignedLongExtensions.FromBytes(0, buffer);
        }

        public static bool BooleanFromByte(byte[] buffer)
        {
            return BooleanExtensions.FromByte(true, buffer);
        }
    }
}
