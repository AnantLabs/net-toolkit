using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools.Engines.Network
{
    public abstract class DefaultUpdateServer : UpdateServer
    {
        public abstract Version NewVersion { get; }
        public abstract Stream UpdateSetup { get; }

        public override Version GetNewVersion(Version currentVersion)
        {
            if (currentVersion < NewVersion)
                return NewVersion;

            return null;
        }

        public override bool CheckForUpdate(Version currentVersion)
        {
            return GetNewVersion(currentVersion) != null;
        }

        public override void DownloadUpdate(IFileLoader fileLoader)
        {
            byte[] buffer = new byte[0xffff];
            long currentPosition = UpdateSetup.Position;

            UpdateSetup.Seek(0, SeekOrigin.Begin);

            long allBytes = 0;
            while (allBytes < UpdateSetup.Length)
            {
                int readBytes = UpdateSetup.Read(buffer, 0, 0xffff);
                if (readBytes == 0)
                    break;

                lock (fileLoader)
                {
                    fileLoader.SendBytes(buffer);
                    fileLoader.Percent = (100d * allBytes / UpdateSetup.Length);
                }

                allBytes += readBytes;
            }

            UpdateSetup.Position = currentPosition;

            if (allBytes < UpdateSetup.Length)
                throw new IOException("Error while copy UpdateSetup: Cannot copy all bytes from source!");
        }
    }
}
