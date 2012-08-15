using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Office
{
    /// \addtogroup office
    /// @{

    /// <summary>
    /// Represent an Office document
    /// </summary>
    public interface IOfficeDocument : IDisposable
    {
        /// <summary>
        /// Open a file
        /// </summary>
        /// <param name="file"></param>
        void Open(String file);
        /// <summary>
        /// Open from stream
        /// </summary>
        /// <param name="stream"></param>
        void Open(Stream stream);

        /// <summary>
        /// Save to file
        /// </summary>
        /// <param name="file"></param>
        void Save(String file);
        /// <summary>
        /// Save to stream
        /// </summary>
        /// <param name="stream"></param>
        void Save(Stream stream);
    }

    /// @}
}
