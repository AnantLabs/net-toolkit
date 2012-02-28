using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Common;
using DXMesh = SlimDX.Direct3D9.Mesh;
using NET.Tools.Engines.Graphics3D.Engines;

namespace NET.Tools.Engines.Graphics3D.Layer.Direct3D9
{
    internal sealed class Direct3D9Mesh : Mesh
    {
        private DXMesh mesh;

        public Direct3D9Mesh(DXMesh mesh)
        {
            this.mesh = mesh;
        }

        internal override void Render()
        {
            //GraphicsDirect3D9.Device

            for (int i = 0; i < mesh.FaceCount; i++)
            {
                mesh.DrawSubset(i);
            }
        }
    }
}
