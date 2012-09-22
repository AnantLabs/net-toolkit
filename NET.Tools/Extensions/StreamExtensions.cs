using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Contains all stream extensions
    /// </summary>
    public static class StreamExtensions
    {
        public static void WriteShort(this Stream stream, short value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteLong(this Stream stream, long value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteInteger(this Stream stream, int value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteDouble(this Stream stream, double value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteFloat(this Stream stream, float value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteUnsignedShort(this Stream stream, ushort value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteUnsignedLong(this Stream stream, ulong value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteUnsignedInteger(this Stream stream, uint value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteChar(this Stream stream, char value)
        {
            byte[] buffer = value.ToBytes();
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteSignedByte(this Stream stream, sbyte value)
        {
            stream.WriteByte((byte)value);
        }

        public static void WriteBoolean(this Stream stream, bool value)
        {
            stream.WriteByte(value ? (byte)1 : (byte)0);
        }

        public static void WriteString(this Stream stream, String str)
        {
            bool endChar = false;
            foreach (char c in str)
            {
                stream.WriteChar(c);
                if (c == '\0')
                {
                    endChar = true;
                    break;
                }
            }

            if (!endChar)
                stream.WriteChar('\0');
        }

        //*****************************************************************

        public static short ReadShort(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(short)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.ShortFromBytes(buffer);
        }

        public static long ReadLong(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(long)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.LongFromBytes(buffer);
        }

        public static int ReadInteger(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(int)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.IntegerFromBytes(buffer);
        }

        public static double ReadDouble(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(double)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.DoubleFromBytes(buffer);
        }

        public static float ReadFloat(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(float)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.FloatFromBytes(buffer);
        }

        public static ushort ReadUnsignedShort(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(ushort)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.UnsignedShortFromBytes(buffer);
        }

        public static ulong ReadUnsignedLong(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(ulong)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.UnsignedLongFromBytes(buffer);
        }

        public static uint ReadUnsignedInteger(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(uint)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.UnsignedIntegerFromBytes(buffer);
        }

        public static char ReadChar(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(char)];
            stream.Read(buffer, 0, buffer.Length);
            return BytesTool.CharacterFromBytes(buffer);
        }

        public static sbyte ReadSignedByte(this Stream stream)
        {
            return (sbyte)stream.ReadByte();
        }

        public static bool ReadBoolean(this Stream stream)
        {
            return stream.ReadByte() == 1;
        }

        public static String ReadString(this Stream stream)
        {
            StringBuilder result = new StringBuilder();

            char character = ' ';
            while (character != '\0')
            {
                character = stream.ReadChar();
                if (character != '\0')
                    result.Append(character);
            }

            return result.ToString();
        }

        public static byte[] ReadToEnd(this Stream stream)
        {
            long length = stream.Length - stream.Position;
            if (length > int.MaxValue)
                throw new InvalidOperationException("Cannot read to end: To many bytes to read!");

            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, (int)length);
            return buffer;
        }

        //******************************************************

        /// <summary>
        /// Copy from source stream to destination stream
        /// </summary>
        /// <param name="stream">Source stream</param>
        /// <param name="dest">Destination stream</param>
        /// <param name="bufferSize">Buffer size of one copy action</param>
        /// <param name="progress">Action for the progress change (max, value)</param>
        public static void CopyStream(this Stream stream, Stream dest, uint bufferSize, Action<long, long> progress)
        {
            byte[] buffer = new byte[bufferSize];
            long currentPosition = stream.Position;

            stream.Seek(0, SeekOrigin.Begin);

            long allBytes = 0;
            while (allBytes < stream.Length)
            {
                int readBytes = stream.Read(buffer, 0, (int)bufferSize);
                if (readBytes == 0)
                    break;

                dest.Write(buffer, 0, readBytes);
                allBytes += readBytes;

                if (progress != null)
                    progress(stream.Length, allBytes);
            }

            stream.Position = currentPosition;

            if (allBytes < stream.Length)
                throw new IOException("Error while copy stream: Cannot copy all bytes from source stream!");
        }

        /// <summary>
        /// Copy from source stream to destination stream
        /// </summary>
        /// <param name="stream">Source stream</param>
        /// <param name="dest">Destination stream</param>
        /// <param name="bufferSize">Buffer size of one copy action</param>
        public static void CopyStream(this Stream stream, Stream dest, uint bufferSize)
        {
            CopyStream(stream, dest, bufferSize, null);
        }

        /// <summary>
        /// Copy from source stream to destination stream
        /// </summary>
        /// <param name="stream">Source stream</param>
        /// <param name="dest">Destination stream</param>
        /// <param name="progress">Action for the progress change (max, value)</param>
        public static void CopyStream(this Stream stream, Stream dest, Action<long, long> progress)
        {
            CopyStream(stream, dest, 0xFFFF, progress);
        }

        /// <summary>
        /// Copy from source stream to destination stream
        /// </summary>
        /// <param name="stream">Source stream</param>
        /// <param name="dest">Destination stream</param>
        public static void CopyStream(this Stream stream, Stream dest)
        {
            CopyStream(stream, dest, null);
        }

        //***********************************************************************

        public static long SeekToBegin(this Stream stream)
        {
            return stream.Seek(0, SeekOrigin.Begin);
        }

        public static long SeekToEnd(this Stream stream)
        {
            return stream.Seek(0, SeekOrigin.End);
        }

        /// <summary>
        /// Write the stream to the given file
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="file">Destination file name</param>
        public static void WriteToFile(this Stream stream, string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                stream.CopyTo(fs);
                fs.Flush();
                fs.Close();
            }
        }

        public static void WriteToFile(this Stream stream, FileInfo file)
        {
            WriteToFile(stream, file.FullName);
        }
    }

    /// @}
}
