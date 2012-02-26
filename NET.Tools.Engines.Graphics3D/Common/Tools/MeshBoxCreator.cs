using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DX9Mesh = SlimDX.Direct3D9.Mesh;
using NET.Tools.Engines.Graphics3D.Engines;

namespace NET.Tools.Engines.Graphics3D.Common.Tools
{
    public sealed class MeshBoxCreator : MeshCreator
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

        protected override Mesh<Object> CreateDirect3D9Mesh()
        {
            DX9Mesh mesh = DX9Mesh.CreateBox(GraphicsDirect3D9.Device, Width, Height, Depth);
            return (Mesh<Object>)Convert.ChangeType(new Direct3D9Mesh(mesh), typeof(Mesh<Object>));
        }

        protected override Mesh<Object> CreateDirect3D11Mesh()
        {
            throw new NotSupportedException();
        }

        protected override Mesh<Object> CreateOpenGLMesh()
        {
            throw new NotSupportedException();
        }
    }
}
