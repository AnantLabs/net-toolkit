using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DX9Mesh = SlimDX.Direct3D9.Mesh;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    internal sealed class Direct3D9MeshImplementor : IMeshImplementor
    {
        private static Direct3D9MeshImplementor instance = null;
        public static Direct3D9MeshImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D9MeshImplementor();
            }

            return instance;
        }

        private Direct3D9MeshImplementor()
        {
        }

        public Mesh CreateBoxMesh(float width, float height, float depth)
        {
            DX9Mesh mesh = DX9Mesh.CreateBox(GraphicsDirect3D9.Device, width, height, depth);
            return new Direct3D9Mesh(mesh);
        }

        public Mesh CreateCylinderMesh(float radius1, float radius2, float length, int slices, int stacks)
        {
            DX9Mesh mesh = DX9Mesh.CreateCylinder(GraphicsDirect3D9.Device, radius1, radius2, length, slices, stacks);
            return new Direct3D9Mesh(mesh);
        }
    }
}
