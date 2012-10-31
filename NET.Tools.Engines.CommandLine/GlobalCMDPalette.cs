using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Contains the global console palette
    /// 
    /// As defualt is turbo-vision (turbo pascal) color sheme used
    /// </summary>
    public static class GlobalCMDPalette
    {
        /// <summary>
        /// Gets or sets the global palette
        /// </summary>
        public static CMDPalette Palette { get; set; }

        static GlobalCMDPalette()
        {
            Palette = CMDPalette.TurboVisionPalette;
        }
    }
}
