using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXMesh = Microsoft.DirectX.Direct3D.Mesh;
using DXMaterial = Microsoft.DirectX.Direct3D.ExtendedMaterial;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a original mesh object
    /// </summary>
    public sealed class Mesh : IRenderableObject
    {
        private DXMesh mesh;
        private DXMaterial[] materialList = null;

        internal Mesh(String meshFile, Graphics3D graphics)
        {
            mesh = DXMesh.FromFile(
                meshFile, 
                Microsoft.DirectX.Direct3D.MeshFlags.Managed, 
                graphics.D3DX9,
                out materialList);
        }

        public void Render(Graphics3D graphics)
        {
            if (!IsVisible)
                return;

            for (int i = 0; i < materialList.Length; i++)
            {
                mesh.DrawSubset(i);
            }
        }

        #region IDisposable Member

        public void Dispose()
        {
            mesh.Dispose();
        }

        #endregion

        #region IGraphics3DObject Member

        public bool IsVisible
        {
            get;
            set;
        }

        #endregion
    }

    /// @}
}
