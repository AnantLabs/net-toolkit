using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Common;
using DXMesh = SlimDX.Direct3D9.Mesh;

namespace NET.Tools.Engines.Graphics3D
{
    internal sealed class Direct3D9Mesh : Mesh<DXMesh>
    {
        public Direct3D9Mesh(DXMesh mesh)
            : base(mesh)
        {
        }

        internal override void Render()
        {
            
        }
    }
}
