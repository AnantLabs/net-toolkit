using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class ByteArrayExtensions
    {
        public static String ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static String ToHexString(this byte[] bytes)
        {
            String res = "";

            foreach (byte b in bytes)
            {
                res += b.ToString("x").PadLeft(2,'0');
            }

            return res;
        }

        public static byte[] EncodeWithMD5(this byte[] bytes)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(bytes);
        }

        public static byte[] EncodeWithMD5(this byte[] bytes, int off, int count)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(bytes, off, count);
        }

        public static byte[] EncodeWithSHA1(this byte[] bytes)
        {
            SHA1 sha1 = SHA1.Create();
            return sha1.ComputeHash(bytes);
        }

        public static byte[] EncodeWithSHA1(this byte[] bytes, int off, int count)
        {
            SHA1 sha1 = SHA1.Create();
            return sha1.ComputeHash(bytes, off, count);
        }

        public static byte[] EncodeWithSHA256(this byte[] bytes)
        {
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(bytes);
        }

        public static byte[] EncodeWithSHA256(this byte[] bytes, int off, int count)
        {
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(bytes, off, count);
        }

        public static byte[] EncodeWithSHA512(this byte[] bytes)
        {
            SHA512 sha512 = SHA512.Create();
            return sha512.ComputeHash(bytes);
        }

        public static byte[] EncodeWithSHA512(this byte[] bytes, int off, int count)
        {
            SHA512 sha512 = SHA512.Create();
            return sha512.ComputeHash(bytes, off, count);
        }

        public static byte[] EncodeWith(this byte[] bytes, string hashAlgo)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashAlgo);
            return hashAlgorithm.ComputeHash(bytes);
        }

        public static byte[] EncodeWith(this byte[] bytes, string hashAlgo, int off, int count)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashAlgo);
            return hashAlgorithm.ComputeHash(bytes, off, count);
        }

        public static long GetCheckSum(this byte[] bytes)
        {
            long counter = 0;

            foreach (byte b in bytes)
                counter += b;

            return counter;
        }

        public static String ToString(this byte[] buf, Encoding encoding)
        {
            using(MemoryStream ms = new MemoryStream(buf))
            {
                using (StreamReader reader = new StreamReader(ms, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static char[] ToCharacterArray(this byte[] buf, Encoding encoding)
        {
            return ToString(buf, encoding).ToCharArray();
        }
    }
    /// @}
}
