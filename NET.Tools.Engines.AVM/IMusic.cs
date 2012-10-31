using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AVM
{
    /// <summary>
    /// Interface for all music players
    /// </summary>
    public interface IMusic
    {
        /// <summary>
        /// Gets a list of music files to play
        /// </summary>
        IList<String> MusicFileList { get; }
        /// <summary>
        /// Gets or sets the list playing of player
        /// </summary>
        bool PlayRandom { get; set; }
        /// <summary>
        /// Gets or sets the overlapping of musics in seconds
        /// </summary>
        double Overlap { get; set; }
    }
}
