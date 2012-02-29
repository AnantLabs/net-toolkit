using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Layer.Direct3D9;
using NET.Tools.Engines.Graphics3D.Layer.Direct3D11;

namespace NET.Tools.Engines.Graphics3D.Layer
{
    internal static class LayerImplementorFactory
    {
        public static ILayerImplementor Direct3D9Implementor { get { return Direct3D9LayerImplementor.GetInstance(); } }
        public static ILayerImplementor Direct3D11Implementor { get { return Direct3D11LayerImplementor.GetInstance(); } }
    }
}
