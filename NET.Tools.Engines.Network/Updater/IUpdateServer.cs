using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Network
{
    /// <summary>
    /// Represent the interface for all update services
    /// </summary>
    public interface IUpdateServer
    {
        /// <summary>
        /// Get the new version number if it exists
        /// </summary>
        /// <param name="currentVersion">The current version</param>
        /// <returns>The new version or null, if no newer version exists</returns>
        Version GetNewVersion(Version currentVersion);
        /// <summary>
        /// Check for updates
        /// </summary>
        /// <param name="currentVersion">The current version number</param>
        /// <returns>TRUE, if there are a newer version</returns>
        bool CheckForUpdate(Version currentVersion);

        /// <summary>
        /// Download the new version as setup file
        /// </summary>
        /// <param name="fileLoader">Load the file to local space</param>
        void DownloadUpdate(IFileLoader fileLoader);
    }
}
