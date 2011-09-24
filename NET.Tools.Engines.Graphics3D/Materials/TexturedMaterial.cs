using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a textures material
    /// </summary>
    public class TexturedMaterial : Material
    {
        private IList<Texture> textures = new List<Texture>(8);

        /// <summary>
        /// Texture of level 0
        /// </summary>
        public Texture TextureLevel0
        {
            get { return textures[0]; }
            set { textures[0] = value; textures[0].Level = 0; }
        }

        /// <summary>
        /// Texture of level 1
        /// </summary>
        public Texture TextureLevel1
        {
            get { return textures[1]; }
            set { textures[1] = value; textures[1].Level = 1; }
        }

        /// <summary>
        /// Texture of level 2
        /// </summary>
        public Texture TextureLevel2
        {
            get { return textures[2]; }
            set { textures[2] = value; textures[2].Level = 2; }
        }

        /// <summary>
        /// Texture of level 3
        /// </summary>
        public Texture TextureLevel3
        {
            get { return textures[3]; }
            set { textures[3] = value; textures[3].Level = 3; }
        }

        /// <summary>
        /// Texture of level 4
        /// </summary>
        public Texture TextureLevel4
        {
            get { return textures[4]; }
            set { textures[4] = value; textures[4].Level = 4; }
        }

        /// <summary>
        /// Texture of level 5
        /// </summary>
        public Texture TextureLevel5
        {
            get { return textures[5]; }
            set { textures[5] = value; textures[5].Level = 5; }
        }

        /// <summary>
        /// Texture of level 6
        /// </summary>
        public Texture TextureLevel6
        {
            get { return textures[6]; }
            set { textures[6] = value; textures[6].Level = 6; }
        }

        /// <summary>
        /// Texture of level 7
        /// </summary>
        public Texture TextureLevel7
        {
            get { return textures[7]; }
            set { textures[7] = value; textures[7].Level = 7; }
        }

        internal TexturedMaterial()
            : base()
        {
        }

        internal override void SetMaterial(Graphics3D graphics)
        {
            base.SetMaterial(graphics);

            foreach (Texture tex in textures)
                if (tex != null)
                    tex.SetTexture(graphics);
        }

        internal override void UnsetMaterial(Graphics3D graphics)
        {
            base.UnsetMaterial(graphics);

            foreach (Texture tex in textures)
                if (tex != null)
                    tex.UnsetTexture(graphics);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    /// @}
}
