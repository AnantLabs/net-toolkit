using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Direct3D11
{
    public sealed class LayerInformation : ILayerInformation
    {
        public LayerInformation()
        {
        }

        public string SystemName
        {
            get { return "Direct3D11"; }
        }

        public ILayerImplementor LayerImplementor
        {
            get { return Direct3D11LayerImplementor.GetInstance(); }
        }

        public Graphics3DDevice Device
        {
            get { return GraphicsDirect3D11.GetInstance(); }
        }
    }
}
