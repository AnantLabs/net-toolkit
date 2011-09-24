using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent all parameters for texture rendering
    /// </summary>
    public sealed class TextureRenderParameters
    {
        /// <summary>
        /// Gets or sets the mip filter
        /// </summary>
        public RenderFilter MipFilter { get; set; }
        /// <summary>
        /// Gets or sets the min filter
        /// </summary>
        public RenderFilter MinFilter { get; set; }
        /// <summary>
        /// Gets or sets the map filter
        /// </summary>
        public RenderFilter MagFilter { get; set; }

        /// <summary>
        /// Maximum level of mip-mapping
        /// </summary>
        public int MaximumMipLevel { get; set; }
        /// <summary>
        /// Maximum anisotropy-level
        /// </summary>
        public int MaximumAnisotropyLevel { get; set; }

        public TextureRenderParameters(RenderFilter mip, RenderFilter min, RenderFilter mag,
            int maxMip, int maxAnisotropy)
        {
            MipFilter = mip;
            MinFilter = min;
            MagFilter = mag;

            MaximumMipLevel = maxMip;
            MaximumAnisotropyLevel = maxAnisotropy;
        }

        public TextureRenderParameters(Graphics3D graphics)
            :this(graphics.Configuration.RenderFilter, graphics.Configuration.RenderFilter,
            graphics.Configuration.RenderFilter, graphics.Configuration.MaximumMipLevel,
            graphics.Configuration.MaximumAnisotropyLevel)
        {
        }
    }

    /// @}
}
