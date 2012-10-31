using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools.Engines.Network
{
    [Serializable]
    public sealed class StreamFileLoader : IFileLoader
    {
        private Stream stream;

        public StreamFileLoader(String tagetFile)
        {
            stream = new FileStream(tagetFile, FileMode.Create);
        }

        public StreamFileLoader(Stream target)
        {
            stream = target;
        }

        #region IFileLoader Member

        public void SendBytes(byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        public double Percent
        {
            get;
            set;
        }

        #endregion

        #region IDisposable Member

        public void Dispose()
        {
            stream.Close();
            stream.Dispose();
        }

        #endregion
    }
}
