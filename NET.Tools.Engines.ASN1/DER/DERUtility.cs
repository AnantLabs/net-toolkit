using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.ASN1
{
    /// <summary>
    /// Utility class for DER Encoding
    /// </summary>
    public static class DERUtility
    {
        private const byte FIRST_BIT_SET = 0x80;

        /// <summary>
        /// Encoding the length in DER encoding style
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] EncodeLength(long length)
        {
            List<byte> lst = new List<byte>();

            if (length > FIRST_BIT_SET)
            {
                byte neededBytes = (byte)((length / 256) + 1);
                lst.Add((byte)(FIRST_BIT_SET | neededBytes));

                byte[] lengthBytes = BitConverter.GetBytes(length);
                foreach (byte b in lengthBytes)
                {
                    if (b != 0x00)
                    {
                        lst.Add(b);
                    }
                }
            }
            else
            {
                lst.Add((byte)length);
            }

            return lst.ToArray();
        }

        /*public static long DecodeLength(byte[] buffer)
        {
            if (buffer.Length == 1)
            {
                if ((buffer[0] & FIRST_BIT_SET) != 0)
                    throw new ASN1DecodingException("Cannot decode length bytes: " + buffer.ToHexString(),
                        ASN1LengthException.GenerateShortLengthException());

                return buffer[0];
            }
            else
            {
                if ((buffer[0] & FIRST_BIT_SET) == 0)
                    throw new ASN1DecodingException("Cannot decode length bytes: " + buffer.ToHexString(),
                        ASN1LengthException.GenerateLongLengthException());

                byte neededBytes = (byte)(buffer[0] ^ FIRST_BIT_SET);
                if (buffer.Length != neededBytes + 1)
                    throw new ASN1DecodingException("Cannot decode length bytes: " + buffer.ToHexString(),
                        new ASN1LengthException("Length buffer with wrong size!"));
                byte[] tmp = buffer.SubArray(1);
            }
        }*/
    }
}
