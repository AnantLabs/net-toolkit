using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Interface for all animations
    /// </summary>
    public interface IAnimation
    {
        /// <summary>
        /// Gets or stes the speed of animation
        /// </summary>
        double Speed { get; set; }
        /// <summary>
        /// Gets or sets the position of the animation
        /// </summary>
        double Position { get; set; }
        /// <summary>
        /// Gets the length of the animation
        /// </summary>
        double Length { get; }
        /// <summary>
        /// Check the animation is running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Start the animation
        /// 
        /// Set IsRunninf on TRUE
        /// </summary>
        void Start();
        /// <summary>
        /// Stop the animation
        /// 
        /// Set IsRunning to FALSE
        /// </summary>
        void Stop();
        /// <summary>
        /// Reset the animation
        /// 
        /// Set the Position to 0
        /// </summary>
        void Reset();
    }

    /// @}
}
