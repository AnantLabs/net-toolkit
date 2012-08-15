using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Compression;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class FileInfoExtensions
    {
        private static List<FileInfo> deleteOnExitList = new List<FileInfo>();

        static FileInfoExtensions()
        {
            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                foreach (FileInfo fi in deleteOnExitList)
                {
                    try
                    {
                        File.Delete(fi.FullName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            };
        }

        /// <summary>
        /// Checks that the file is one of the given file types via extensions
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="ignoreCase">TRUE to ignore case sensitive</param>
        /// <param name="exts">The extensions to check</param>
        /// <returns></returns>
        public static bool IsOneOfFileType(this FileInfo fi, bool ignoreCase, params String[] exts)
        {
            foreach (String ext in exts)
            {
                if (ignoreCase)
                {
                    if (fi.Extension.ToLower().EndsWith(ext))
                        return true;
                }
                else
                {
                    if (fi.Extension.EndsWith(ext))
                        return true;
                }
            }

            return false;
        }

        public static bool IsOneOfFileType(this FileInfo fi, params String[] exts)
        {
            return IsOneOfFileType(fi, true, exts);
        }

        /// <summary>
        /// Delete file automatically on application exit. Use the App Domain ProcessExit Event-Method.
        /// <b>Warning: A file cannot be delete from file on exit list!</b>
        /// </summary>
        /// <param name="fi"></param>
        public static void DeleteOnExit(this FileInfo fi)
        {
            if (!deleteOnExitList.Contains(fi))
                deleteOnExitList.Add(fi);
        }

        /// <summary>
        /// Returns the file name without the extension
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static String GetNameWithoutExtension(this FileInfo fi)
        {
            return fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
        }

        /// <summary>
        /// Returns the file icon used in explorer
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static Icon GetIcon(this FileInfo fi)
        {
            return Icon.ExtractAssociatedIcon(fi.FullName);
        }

        /// <summary>
        /// Zip the given file via GZipStream.
        /// <b>Warning: File will be overwritten!</b>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static bool ZipFile(this FileInfo fi)
        {
            String tmpFile = Path.GetTempFileName();
            bool res = true;

            using (FileStream input = new FileStream(fi.FullName, FileMode.Open))
            {
                using (FileStream output = new FileStream(tmpFile, FileMode.Create))
                {
                    using (GZipStream zip = new GZipStream(output, CompressionMode.Compress))
                    {
                        if (!DoActionWithBytes(fi, input, (buf) =>
                        {
                            zip.Write(buf, 0, buf.Length);
                        }))
                            res = false;
                    }
                }
            }

            if (res)
            {
                File.Delete(fi.FullName);
                File.Move(tmpFile, fi.FullName);
                File.Delete(tmpFile);
            }
            else
            {
                File.Delete(tmpFile);
            }

            return res;
        }

        /// <summary>
        /// Unzip the given file via GZipStream.
        /// <b>Warning: File will be overwritten!</b>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static bool UnzipFile(this FileInfo fi)
        {
            String tmpFile = Path.GetTempFileName();
            bool res = true;

            using (FileStream input = new FileStream(fi.FullName, FileMode.Open))
            {
                using (FileStream output = new FileStream(tmpFile, FileMode.Create))
                {
                    using (GZipStream zip = new GZipStream(input, CompressionMode.Decompress))
                    {
                        if (!DoActionWithBytes(fi, zip, (buf) =>
                        {
                            output.Write(buf, 0, buf.Length);
                        }))
                            res = false;
                    }
                }
            }

            if (res)
            {
                File.Delete(fi.FullName);
                File.Move(tmpFile, fi.FullName);
                File.Delete(tmpFile);
            }
            else
            {
                File.Delete(tmpFile);
            }

            return res;
        }

        /// <summary>
        /// Encode the file with MD5
        /// <b>Warning: File will be overwritten</b>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static bool EncodeWithMD5(this FileInfo fi)
        {
            String tmpFile = Path.GetTempFileName();
            bool res = true;

            using (FileStream input = new FileStream(fi.FullName, FileMode.Open))
            {
                using (FileStream output = new FileStream(tmpFile, FileMode.Create))
                {
                    if (!DoActionWithBytes(fi, input, (buf) =>
                    {
                        byte[] crypto = buf.EncodeWithMD5();
                        output.Write(crypto, 0, crypto.Length);
                    }))
                        res = false;
                }
            }

            if (res)
            {
                File.Delete(fi.FullName);
                File.Move(tmpFile, fi.FullName);
                File.Delete(tmpFile);
            }
            else
            {
                File.Delete(tmpFile);
            }

            return res;
        }

        /// <summary>
        /// Encode the file with SHA1
        /// <b>Warning: File will be overwritten</b>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static bool EncodeWithSHA1(this FileInfo fi)
        {
            String tmpFile = Path.GetTempFileName();
            bool res = true;

            using (FileStream input = new FileStream(fi.FullName, FileMode.Open))
            {
                using (FileStream output = new FileStream(tmpFile, FileMode.Create))
                {
                    if (!DoActionWithBytes(fi, input, (buf) =>
                    {
                        byte[] crypto = buf.EncodeWithSHA1();
                        output.Write(crypto, 0, crypto.Length);
                    }))
                        res = false;
                }
            }

            if (res)
            {
                File.Delete(fi.FullName);
                File.Move(tmpFile, fi.FullName);
                File.Delete(tmpFile);
            }
            else
            {
                File.Delete(tmpFile);
            }

            return res;
        }

        /// <summary>
        /// Encode the file with SHA256
        /// <b>Warning: File will be overwritten</b>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static bool EncodeWithSHA256(this FileInfo fi)
        {
            String tmpFile = Path.GetTempFileName();
            bool res = true;

            using (FileStream input = new FileStream(fi.FullName, FileMode.Open))
            {
                using (FileStream output = new FileStream(tmpFile, FileMode.Create))
                {
                    if (!DoActionWithBytes(fi, input, (buf) =>
                    {
                        byte[] crypto = buf.EncodeWithSHA256();
                        output.Write(crypto, 0, crypto.Length);
                    }))
                        res = false;
                }
            }

            if (res)
            {
                File.Delete(fi.FullName);
                File.Move(tmpFile, fi.FullName);
                File.Delete(tmpFile);
            }
            else
            {
                File.Delete(tmpFile);
            }

            return res;
        }

        /// <summary>
        /// Encode the file with SHA512
        /// <b>Warning: File will be overwritten</b>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static bool EncodeWithSHA512(this FileInfo fi)
        {
            String tmpFile = Path.GetTempFileName();
            bool res = true;

            using (FileStream input = new FileStream(fi.FullName, FileMode.Open))
            {
                using (FileStream output = new FileStream(tmpFile, FileMode.Create))
                {
                    if (!DoActionWithBytes(fi, input, (buf) =>
                    {
                        byte[] crypto = buf.EncodeWithSHA512();
                        output.Write(crypto, 0, crypto.Length);
                    }))
                        res = false;
                }
            }

            if (res)
            {
                File.Delete(fi.FullName);
                File.Move(tmpFile, fi.FullName);
                File.Delete(tmpFile);
            }
            else
            {
                File.Delete(tmpFile);
            }

            return res;
        }

        /// <summary>
        /// Encode the file with the given hash algorithm
        /// <b>Warning: File will be overwritten</b>
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="hashAlgo">Hash algorithm name to use for encoding</param>
        /// <returns></returns>
        public static bool EncodeWith(this FileInfo fi, string hashAlgo)
        {
            String tmpFile = Path.GetTempFileName();
            bool res = true;

            using (FileStream input = new FileStream(fi.FullName, FileMode.Open))
            {
                using (FileStream output = new FileStream(tmpFile, FileMode.Create))
                {
                    if (!DoActionWithBytes(fi, input, (buf) =>
                    {
                        byte[] crypto = buf.EncodeWith(hashAlgo);
                        output.Write(crypto, 0, crypto.Length);
                    }))
                        res = false;
                }
            }

            if (res)
            {
                File.Delete(fi.FullName);
                File.Move(tmpFile, fi.FullName);
                File.Delete(tmpFile);
            }
            else
            {
                File.Delete(tmpFile);
            }

            return res;
        }

        /// <summary>
        /// Write the stream into this file (overwrites file!)
        /// </summary>
        /// <param name="file"></param>
        /// <param name="stream">Stream to write into file</param>
        public static void WriteFromStream(this FileInfo file, Stream stream)
        {
            stream.WriteToFile(file);
        }

        /// <summary>
        /// Read the content of the file to stream
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Stream ReadToStream(this FileInfo file)
        {
            return new FileStream(file.FullName, FileMode.Open);
        }

        public static byte[] ReadAllBytes(this FileInfo file)
        {
            return File.ReadAllBytes(file.FullName);
        }

        public static void WriteAllBytes(this FileInfo file, byte[] data)
        {
            File.WriteAllBytes(file.FullName, data);
        }

        #region Private

        private static bool DoActionWithBytes(FileInfo fi, Stream input, Action<byte[]> action)
        {
            int readBytes = 0;
            while (readBytes < input.Length)
            {
                byte[] buffer = new byte[0xffff];
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0) //Nothing to read
                    break;
                action(buffer);

                readBytes += read;
            }

            if (readBytes < input.Length)
                return false;

            return true;
        }

        #endregion
    }
    /// @}
}
