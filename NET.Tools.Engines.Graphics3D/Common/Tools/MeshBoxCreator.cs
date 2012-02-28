using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DX9Mesh = SlimDX.Direct3D9.Mesh;
using NET.Tools.Engines.Graphics3D.Engines;
using NET.Tools.Engines.Graphics3D.Layer.Direct3D9;

namespace NET.Tools.Engines.Graphics3D.Common.Tools
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

        protected override Mesh CreateDirect3D9Mesh()
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
        }
    }
}
