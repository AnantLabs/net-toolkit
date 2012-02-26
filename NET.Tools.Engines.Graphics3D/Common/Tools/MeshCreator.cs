using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Engines;

namespace NET.Tools.Engines.Graphics3D.Common.Tools
{
    public abstract class MeshCreator
    {
        #region Static 

        public static MeshBoxCreator CreateBox(float width, float height, float depth)
        {
            return new MeshBoxCreator(width, height, depth);
        }

        public static MeshCylinderCreator CreateCylinder(float radius1, float radius2, float length, int slices, int stacks)
        {
            return new MeshCylinderCreator(radius1, radius2, length, slices, stacks);
        }

        #endregion

        internal Mesh<Object> CreateMesh()
        {
            switch (Graphics3DDevice<Object>.CurrentDeviceType.Value)
            {
                case Graphics3DDeviceType.Direct3D9:
                    return CreateDirect3D9Mesh();
                case Graphics3DDeviceType.Direct3D11:
                    return CreateDirect3D11Mesh();
                case Graphics3DDeviceType.OpenGL:
                    return CreateOpenGLMesh();
                default:
                    throw new NotImplementedException(Graphics3DDevice<Object>.CurrentDeviceType.Value.ToString());
            }
        }

        protected abstract Mesh<Object> CreateDirect3D9Mesh();
        protected abstract Mesh<Object> CreateDirect3D11Mesh();
        protected abstract Mesh<Object> CreateOpenGLMesh();
    }
}
