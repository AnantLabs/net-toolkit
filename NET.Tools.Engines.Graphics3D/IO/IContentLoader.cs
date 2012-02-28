using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.IO
{
    /// <summary>
    /// Represent a simple interface for a content loader
    /// </summary>
    public interface IContentLoader : IDisposable
    {
        /// <summary>
        /// Load a content
        /// </summary>
        void Load();
    }
}
