using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Defines the handling while creating an object with a manager
    /// </summary>
    public enum ManagerCreateHandling
    {
        /// <summary>
        /// Throws an exception if the key is already exists
        /// </summary>
        ThrowExceptionIfExists,
        /// <summary>
        /// Overwrite the old object if the key already exists
        /// </summary>
        OverwriteIfExists,
        /// <summary>
        /// Do nothing and returns the found object if key already exists
        /// </summary>
        DoNothingIfExists
    }

    /// @}
}
