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
    /// Extensions for System.IO.TextReader
    /// </summary>
    public static class TextReaderExtensions
    {
        public static short ReadShort(this TextReader stream)
        {
            char[] buffer = new char[sizeof(short) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.ShortFromBytes(buffer.ToByteArray());
        }

        public static long ReadLong(this TextReader stream)
        {
            char[] buffer = new char[sizeof(long) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.LongFromBytes(buffer.ToByteArray());
        }

        public static int ReadInteger(this TextReader stream)
        {
            char[] buffer = new char[sizeof(int) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.IntegerFromBytes(buffer.ToByteArray());
        }

        public static double ReadDouble(this TextReader stream)
        {
            char[] buffer = new char[sizeof(double) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.DoubleFromBytes(buffer.ToByteArray());
        }

        public static float ReadFloat(this TextReader stream)
        {
            char[] buffer = new char[sizeof(float) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.FloatFromBytes(buffer.ToByteArray());
        }

        public static ushort ReadUnsignedShort(this TextReader stream)
        {
            char[] buffer = new char[sizeof(ushort) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.UnsignedShortFromBytes(buffer.ToByteArray());
        }

        public static ulong ReadUnsignedLong(this TextReader stream)
        {
            char[] buffer = new char[sizeof(ulong) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.UnsignedLongFromBytes(buffer.ToByteArray());
        }

        public static uint ReadUnsignedInteger(this TextReader stream)
        {
            char[] buffer = new char[sizeof(uint) / sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);

            return BytesTool.UnsignedIntegerFromBytes(buffer.ToByteArray());
        }

        public static char ReadChar(this TextReader stream)
        {
            return (char)stream.Read();
        }

        public static sbyte ReadSignedByte(this TextReader stream)
        {
            return (sbyte)ReadChar(stream).ToBytes()[1];
        }

        public static byte ReadByte(this TextReader stream)
        {
            return ReadChar(stream).ToBytes()[1];
        }

        public static bool ReadBoolean(this TextReader stream)
        {
            return ReadByte(stream) == (byte)1;
        }
    }

    /// @}
}
