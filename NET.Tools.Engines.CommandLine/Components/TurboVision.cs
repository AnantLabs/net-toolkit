using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.AbstractGUI;

namespace NET.Tools.Engines.CommandLine.Components
{
    public sealed class TurboVision : StyleGroup
    {
        private static TurboVision instance = null;
        public static TurboVision Instance { get { return instance ?? (instance = new TurboVision()); } }

        private TurboVision() : base(new ButtonStyle(), new WindowStyle())
        {
        }
    }
}
