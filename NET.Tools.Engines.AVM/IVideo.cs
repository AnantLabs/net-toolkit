using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Engines.AVM
{
    /// <summary>
    /// Interface for all videos
    /// </summary>
    public interface IVideo
    {
        /// <summary>
        /// Gets or sets the target for the video
        /// </summary>
        Control Target { get; set; }
        /// <summary>
        /// Gets or sets the caption for the video frame
        /// 
        /// Only if no control target is set (null)
        /// </summary>
        String Caption { get; set; }
        /// <summary>
        /// Gets or sets the fullscreen mode on/off
        /// 
        /// Only if no control target is set (null)
        /// </summary>
        bool Fullscreen { get; set; }
    }
}
