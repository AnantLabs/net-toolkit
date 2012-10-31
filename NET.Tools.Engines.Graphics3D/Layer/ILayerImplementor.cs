using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public interface ILayerImplementor
    {
        IMeshImplementor MeshImplementor { get; }
        IMatrixImplementor MatrixImplementor { get; }
        IViewportImplementor ViewportImplementor { get; }
        IMaterialImplementor MaterialImplementor { get; }
        ILightImplementor LightImplementor { get; }
    }
}
