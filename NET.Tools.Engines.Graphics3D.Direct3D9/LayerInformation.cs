using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    public sealed class LayerInformation : ILayerInformation
    {
        public LayerInformation()
        {
        }

        public string SystemName
        {
            get { return "Direct3D9"; }
        }

        public ILayerImplementor LayerImplementor
        {
            get { return Direct3D9LayerImplementor.GetInstance(); }
        }

        public Graphics3DDevice Device
        {
            get { return GraphicsDirect3D9.GetInstance(); }
        }
    }
}
