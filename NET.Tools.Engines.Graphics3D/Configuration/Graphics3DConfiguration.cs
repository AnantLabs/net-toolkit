using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Configuration
{
    public sealed class Graphics3DConfiguration
    {
        public ScreenConfiguration ScreenConfiguration { get; private set; }
        public IntPtr Target { get; set; }

        public Graphics3DConfiguration()
        {
            ScreenConfiguration = new ScreenConfiguration();
        }
    }
}
