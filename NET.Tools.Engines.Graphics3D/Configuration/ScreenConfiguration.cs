using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Configuration
{
    public enum ColorMode
    {
        Bit16,
        Bit32
    }

    public sealed class ScreenConfiguration
    {
        public bool FullScreen { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ColorMode ColorMode { get; set; }

        internal ScreenConfiguration()
        {
        }
    }
}
