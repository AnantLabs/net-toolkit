using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DX9Mesh = SlimDX.Direct3D9.Mesh;

namespace NET.Tools.Engines.Graphics3D
{
    internal sealed class MeshCylinderCreator : MeshCreator
    {
        public float Radius1 { get; private set; }
        public float Radius2 { get; private set; }
        public float Length { get; private set; }

        public int Slices { get; private set; }
        public int Stacks { get; private set; }

        internal MeshCylinderCreator(float radius1, float radius2, float length, int slices, int stacks)
        {
            Radius1 = radius1;
            Radius2 = radius2;
            Length = length;

            Slices = slices;
            Stacks = stacks;
        }

        /*protected override Mesh CreateDirect3D9Mesh()
        {
            DX9Mesh mesh = DX9Mesh.CreateCylinder(GraphicsDirect3D9.Device, Radius1, Radius2, Length, Slices, Stacks);
            return new Direct3D9Mesh(mesh);
        }

        protected override Mesh CreateDirect3D11Mesh()
        {
            throw new NotImplementedException();
        }

        protected override Mesh CreateOpenGLMesh()
        {
            throw new NotImplementedException();
        }*/

        internal override Mesh Create()
        {
            return Graphics3DSystem.Implementors.MeshImplementor.CreateCylinderMesh(Radius1, Radius2, Length, Slices, Stacks);
        }
    }
}
