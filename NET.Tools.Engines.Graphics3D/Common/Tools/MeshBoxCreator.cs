using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    internal sealed class MeshBoxCreator : MeshCreator
    {
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float Depth { get; private set; }

        internal MeshBoxCreator(float width, float height, float depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        /*protected override Mesh CreateDirect3D9Mesh()
        {
            DX9Mesh mesh = DX9Mesh.CreateBox(GraphicsDirect3D9.Device, Width, Height, Depth);
            return new Direct3D9Mesh(mesh);
        }

        protected override Mesh CreateDirect3D11Mesh()
        {
            throw new NotSupportedException();
        }

        protected override Mesh CreateOpenGLMesh()
        {
            throw new NotSupportedException();
        }*/

        internal override Mesh Create()
        {
            return Graphics3DSystem.Implementors.MeshImplementor.CreateBoxMesh(Width, Height, Depth);
        }
    }
}
