using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Represent the abstract class for all update services implementations
    /// </summary>
    public abstract class UpdateServer : MarshalByRefObject, IUpdateServer
    {
        #region IUpdateService Member

        public abstract Version GetNewVersion(Version currentVersion);

        public abstract bool CheckForUpdate(Version currentVersion);

        public abstract void DownloadUpdate(IFileLoader fileLoader);

        #endregion
    }
}
