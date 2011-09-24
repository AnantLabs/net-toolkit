using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXTexture = Microsoft.DirectX.Direct3D.BaseTexture;
using NET.Tools.Engines.Mathematica;
using Microsoft.DirectX;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a texture object
    /// </summary>
    public sealed class Texture : IGraphics3DObject
    {
        private DXTexture texture;
        private byte level = 0;

        internal byte Level
        {
            get { return level; }
            set
            {
                if ((value < 0) || (value >= 8))
                    throw new ArgumentOutOfRangeException("Texture-Level must be between 0 and 7!");

                level = value;
            }
        }

        /// <summary>
        /// Translation of texture
        /// </summary>
        public Vector2D Translation { get; set; }
        /// <summary>
        /// Border of texture
        /// </summary>
        public TextureBorder Border { get; set; }
        public TextureRenderParameters RenderParameters { get; set; }

        internal Texture(String key, String file, Graphics3D graphics)
        {
            texture = Microsoft.DirectX.Direct3D.TextureLoader.FromFile(
                graphics.D3DX9, file, 0, 0, 0, Microsoft.DirectX.Direct3D.Usage.None,
                Microsoft.DirectX.Direct3D.Format.Unknown, Microsoft.DirectX.Direct3D.Pool.Default,
                (Microsoft.DirectX.Direct3D.Filter)graphics.Configuration.TextureFilter, 
                (Microsoft.DirectX.Direct3D.Filter)graphics.Configuration.TextureFilter, 0);

            if (texture == null)
                throw new LoadTextureException("Cannot load texture from file <" + file + ">!");

            Border = new TextureBorder();
            RenderParameters = new TextureRenderParameters(graphics);
            Translation = new Vector2D();
        }

        internal void SetTexture(Graphics3D graphics)
        {
            graphics.D3DX9.SetTexture(level, texture);

            Matrix matrix = Matrix.Identity;
            matrix.M11 += (float)Translation.X;
            matrix.M21 += (float)Translation.Y;
            switch (level)
            {
                case 0:
                    graphics.D3DX9.Transform.Texture0 = matrix;
                    break;
                case 1:
                    graphics.D3DX9.Transform.Texture1 = matrix;
                    break;
                case 2:
                    graphics.D3DX9.Transform.Texture2 = matrix;
                    break;
                case 3:
                    graphics.D3DX9.Transform.Texture3 = matrix;
                    break;
                case 4:
                    graphics.D3DX9.Transform.Texture4 = matrix;
                    break;
                case 5:
                    graphics.D3DX9.Transform.Texture5 = matrix;
                    break;
                case 6:
                    graphics.D3DX9.Transform.Texture6 = matrix;
                    break;
                case 7:
                    graphics.D3DX9.Transform.Texture7 = matrix;
                    break;
                default:
                    throw new NotSupportedException();
            }

            graphics.D3DX9.SamplerState[level].AddressU = (Microsoft.DirectX.Direct3D.TextureAddress)Border.UBorderStyle;
            graphics.D3DX9.SamplerState[level].AddressV = (Microsoft.DirectX.Direct3D.TextureAddress)Border.VBorderStyle;
            graphics.D3DX9.SamplerState[level].AddressW = (Microsoft.DirectX.Direct3D.TextureAddress)Border.WBorderStyle;
            graphics.D3DX9.SamplerState[level].BorderColorValue = Border.BorderColor.ToColorValue().ToArgb();

            graphics.D3DX9.SamplerState[level].MagFilter = (Microsoft.DirectX.Direct3D.TextureFilter)RenderParameters.MagFilter;
            graphics.D3DX9.SamplerState[level].MinFilter = (Microsoft.DirectX.Direct3D.TextureFilter)RenderParameters.MinFilter;
            graphics.D3DX9.SamplerState[level].MipFilter = (Microsoft.DirectX.Direct3D.TextureFilter)RenderParameters.MipFilter;
            graphics.D3DX9.SamplerState[level].MaxMipLevel = RenderParameters.MaximumMipLevel;
            graphics.D3DX9.SamplerState[level].MaxAnisotropy = RenderParameters.MaximumAnisotropyLevel;
        }

        internal void UnsetTexture(Graphics3D graphics)
        {
            //Reset
            switch (level)
            {
                case 0:
                    graphics.D3DX9.Transform.Texture0 = Matrix.Identity;
                    break;
                case 1:
                    graphics.D3DX9.Transform.Texture1 = Matrix.Identity;
                    break;
                case 2:
                    graphics.D3DX9.Transform.Texture2 = Matrix.Identity;
                    break;
                case 3:
                    graphics.D3DX9.Transform.Texture3 = Matrix.Identity;
                    break;
                case 4:
                    graphics.D3DX9.Transform.Texture4 = Matrix.Identity;
                    break;
                case 5:
                    graphics.D3DX9.Transform.Texture5 = Matrix.Identity;
                    break;
                case 6:
                    graphics.D3DX9.Transform.Texture6 = Matrix.Identity;
                    break;
                case 7:
                    graphics.D3DX9.Transform.Texture7 = Matrix.Identity;
                    break;
                default:
                    throw new NotSupportedException();
            }

            graphics.D3DX9.SetTexture(level, null);
        }

        #region IDisposable Member

        public void Dispose()
        {
            if (texture != null)
                texture.Dispose();
        }

        #endregion
    }

    /// @}
}
