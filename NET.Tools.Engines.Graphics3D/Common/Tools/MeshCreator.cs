using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Engines;

namespace NET.Tools.Engines.Graphics3D.Common.Tools
{
    public abstract class MeshCreator : Creator<Mesh>
    {
        #region Static 

        public static MeshCreator CreateBox(float width, float height, float depth)
        {
            return new MeshBoxCreator(width, height, depth);
        }

        public static MeshCreator CreateCylinder(float radius1, float radius2, float length, int slices, int stacks)
        {
            return new MeshCylinderCreator(radius1, radius2, length, slices, stacks);
        }

        #endregion

        internal override Mesh Create()
        {
            switch (Graphics3DDevice.CurrentDeviceType.Value)
            {
                case Graphics3DDeviceType.Direct3D9:
                    return CreateDirect3D9Mesh();
                case Graphics3DDeviceType.Direct3D11:
                    return CreateDirect3D11Mesh();
                case Graphics3DDeviceType.OpenGL:
                    return CreateOpenGLMesh();
                default:
                    throw new NotImplementedException(Graphics3DDevice.CurrentDeviceType.Value.ToString());
            }
        }

        protected abstract Mesh CreateDirect3D9Mesh();
        protected abstract Mesh CreateDirect3D11Mesh();
        protected abstract Mesh CreateOpenGLMesh();
    }
}
