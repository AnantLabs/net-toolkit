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

        public static void DeleteOnExit(this FileInfo fi)
        {
            if (!deleteOnExitList.Contains(fi))
                deleteOnExitList.Add(fi);
        }

        public static String GetNameWithoutExtension(this FileInfo fi)
        {
            return fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
        }

        public static Icon GetIcon(this FileInfo fi)
        {
            return Icon.ExtractAssociatedIcon(fi.FullName);
        }

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

        public static bool EncodeWithMD5File(this FileInfo fi)
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

        public static bool EncodeWithSHA1File(this FileInfo fi)
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
