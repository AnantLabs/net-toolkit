using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent the interface for all runners
    /// </summary>
    public interface IRunner : IDisposable
    {
        /// <summary>
        /// Run the runner
        /// </summary>
        void Run();

        /// <summary>
        /// Represent the basic graphics object
        /// </summary>
        Graphics3D Graphics { get; }
    }

    /// @}
}
