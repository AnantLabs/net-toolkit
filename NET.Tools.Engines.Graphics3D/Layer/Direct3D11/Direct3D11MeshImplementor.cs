using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Layer.Direct3D11
{
    internal sealed class Direct3D11MeshImplementor : IMeshImplementor
    {
        private static Direct3D11MeshImplementor instance = null;
        public static Direct3D11MeshImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D11MeshImplementor();
            }

            return instance;
        }

        private Direct3D11MeshImplementor()
        {
        }

        public Common.Mesh CreateBoxMesh(float width, float height, float depth)
        {
            throw new NotImplementedException();
        }

        public Common.Mesh CreateCylinderMesh(float radius1, float radius2, float length, int slices, int stacks)
        {
            throw new NotImplementedException();
        }
    }
}
