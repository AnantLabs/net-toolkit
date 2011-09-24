using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AVM
{
    /// <summary>
    /// Interface for all audio objects
    /// </summary>
    public interface IAudio
    {
        /// <summary>
        /// Gets or sets the volume of this audio track
        /// </summary>
        double Volume { get; set; }
        /// <summary>
        /// Gets or sets the balance of this audio track
        /// </summary>
        double Balance { get; set; }
    }
}
