using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace NET.Tools
{
    /// <summary>
    /// Represent a stream to read and write appended data on it with this stream
    /// </summary>
    public class FileAppenderStream : Stream
    {
        #region static

        private static readonly byte[] signature = CreateSignature();

        private static byte[] CreateSignature()
        {
            List<byte> lst = new List<byte>();
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                lst.Add((byte)i);
                lst.Add((byte)(byte.MaxValue - i));
            }

            return lst.ToArray();
        }

        #endregion

        private FileStream stream = null;

        private String tmpContentFile, tmpAppenderFile;

        public String Filename { get; private set; }

        /// <summary>
        /// Create the stream object
        /// </summary>
        /// <param name="fileName">File to write and read appended data</param>
        public FileAppenderStream(String fileName)
        {
            this.Filename = fileName;

            this.tmpContentFile = Path.GetTempFileName();
            new FileInfo(tmpContentFile).DeleteOnExit();

            this.tmpAppenderFile = Path.GetTempFileName();
            new FileInfo(tmpAppenderFile).DeleteOnExit();

            File.Copy(Filename, tmpAppenderFile, true);

            //Out file (Appender)
            using (FileStream tmpOut = new FileStream(tmpAppenderFile, FileMode.Open))
            {
                //In file (Temporary)
                using (FileStream tmpIn = new FileStream(tmpContentFile, FileMode.Create))
                {
                    int read = 0;
                    uint counter = 0;

                    //Search pasttern 
                    while (tmpOut.Length > tmpOut.Position)
                    {
                        //Read byte
                        read = tmpOut.ReadByte();
                        //Byte is the signature byte (dependence of counter state)
                        if (read == signature[counter])
                        {
                            counter++; //Add counter (goon in signature byte array)
                            if (counter >= signature.Length) //Is counter full (end of signature byte array)
                            {
                                //Copy to tmp stream
                                byte[] buffer = tmpOut.ReadToEnd();
                                tmpIn.Write(buffer, 0, buffer.Length);
                                //Clear data from exe (cut it)
                                long length = buffer.Length + signature.Length;
                                tmpOut.SetLength(tmpOut.Length - length);
                                //Break while
                                break;
                            }
                        }
                        else //Byte is not the signature byte
                            counter = 0; //Reset counter (search signature from start)
                    }

                    tmpIn.Close();
                }
                tmpOut.Close();
            }

            //Set stream to temporary file
            this.stream = new FileStream(tmpContentFile, FileMode.Open);
        }

        public override bool CanRead
        {
            get { return stream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return stream.CanWrite; }
        }

        public override void Flush()
        {
            stream.Flush();
        }

        public override long Length
        {
            get { return stream.Length; }
        }

        public override long Position
        {
            get
            {
                return stream.Position;
            }
            set
            {
                stream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }

        /// <summary>
        /// Close the file appender stream
        /// </summary>
        /// <param name="writeBack">
        /// TRUE if the stream must be write the content of himself to the appender file.
        /// <remarks>
        /// The file must be closed to this time
        /// </remarks>
        /// </param>
        public virtual void Close(bool writeBack)
        {
            long length = stream.Length;
            stream.Close();

            if (length > 0)
            {
                //Write data to appender file
                using (FileStream tmpIn = new FileStream(Filename, FileMode.Append))
                {
                    tmpIn.Write(signature, 0, signature.Length);

                    using (FileStream tmpOut = new FileStream(tmpContentFile, FileMode.Open))
                    {
                        tmpOut.CopyStream(tmpIn);
                        tmpOut.Close();
                    }

                    tmpIn.Close();
                }
            }
        }

        /// <summary>
        /// Close the stream and write the content of himself back to file
        /// </summary>
        public override void Close()
        {
            Close(true);
        }
    }
}
