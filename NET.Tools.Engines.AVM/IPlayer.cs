using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AVM
{
    /// <summary>
    /// Represent a defualt player interface
    /// </summary>
    /// <typeparam name="T">Type of length and position</typeparam>
    public interface IPlayer<T> where T : struct
    {
        /// <summary>
        /// Start playing media
        /// </summary>
        void Start();
        /// <summary>
        /// Pause playing media
        /// </summary>
        void Pause();
        /// <summary>
        /// Stop playing media
        /// </summary>
        void Stop();

        /// <summary>
        /// Check the media is playing
        /// </summary>
        bool IsPlayed { get; }
        /// <summary>
        /// Check the media is paused
        /// </summary>
        bool IsPaused { get; }
        /// <summary>
        /// Gets or sets that the media played in loop
        /// </summary>
        bool IsLoop { get; set; }
        /// <summary>
        /// Gets or sets the playing position
        /// </summary>
        T Position { get; set; }
        /// <summary>
        /// Gets the length of the media
        /// </summary>
        T Length { get; }

        /// <summary>
        /// Called if the media has finished
        /// </summary>
        event EventHandler Finished;
    }
}
