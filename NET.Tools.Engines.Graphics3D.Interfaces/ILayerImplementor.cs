using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Interfaces
{
    public interface ILayerImplementor
    {
        IMeshImplementor MeshImplementor { get; }
        IMatrixImplementor MatrixImplementor { get; }
    }
}
