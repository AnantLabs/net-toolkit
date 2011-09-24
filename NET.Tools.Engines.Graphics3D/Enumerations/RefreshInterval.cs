using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent the refresh interval
    /// </summary>
    public enum RefreshInterval
    {
        /// <summary>
        /// High speed (without limiter)
        /// </summary>
        Immediate = -2147483648,
        /// <summary>
        /// Default settings
        /// </summary>
        Default = 0,
        /// <summary>
        /// Maximum 60 fps
        /// </summary>
        One = 1,
        Two = 2,
        Three = 4,
        Four = 8,
    }

    /// @}
}
