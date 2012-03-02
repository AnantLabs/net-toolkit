using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXMesh = SlimDX.Direct3D9.Mesh;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    internal sealed class Direct3D9Mesh : Mesh
    {
        private DXMesh mesh;

        public Direct3D9Mesh(DXMesh mesh)
        {
            this.mesh = mesh;
        }

        protected override void OnRender()
        {
            //GraphicsDirect3D9.Device

            for (int i = 0; i < mesh.FaceCount; i++)
            {
                mesh.DrawSubset(i);
            }
        }
    }
}
