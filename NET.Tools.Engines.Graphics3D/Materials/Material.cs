using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using DXMaterial = Microsoft.DirectX.Direct3D.Material;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Basic class for all materials
    /// </summary>
    public class Material : IGraphics3DObject
    {
        /// <summary>
        /// Diffuse color of material
        /// </summary>
        public Color Diffuse { get; set; }
        /// <summary>
        /// Ambient color of material
        /// </summary>
        public Color Ambient { get; set; }
        /// <summary>
        /// Specular color of material
        /// </summary>
        public Color Specular { get; set; }
        /// <summary>
        /// Emmesive color of material
        /// </summary>
        public Color Emmesive { get; set; }

        

        internal Material()
        {
            Diffuse = Color.White;
            Ambient = Color.White;
            Specular = Color.Gray;
            Emmesive = Color.Black;
        }

        internal virtual void SetMaterial(Graphics3D graphics)
        {
            DXMaterial mat = new DXMaterial();
            mat.AmbientColor = Ambient.ToColorValue();
            mat.DiffuseColor = Diffuse.ToColorValue();
            mat.EmissiveColor = Emmesive.ToColorValue();
            mat.SpecularColor = Specular.ToColorValue();

            graphics.D3DX9.Material = mat;
        }

        internal virtual void UnsetMaterial(Graphics3D graphics)
        {
            //Empty
        }

        #region IDisposable Member

        public virtual void Dispose()
        {
        }

        #endregion
    }

    /// @}
}
