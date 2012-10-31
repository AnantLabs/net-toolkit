using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// <summary>
    /// Factory interface for all content loader
    /// </summary>
    public interface IContentLoaderFactory
    {
        /// <summary>
        /// Gets a content loader to load a mesh
        /// </summary>
        IMeshContentLoader MeshContentLoader { get; }
        /// <summary>
        /// Gets a content loader to load a texture
        /// </summary>
        ITextureContentLoader TextureContentLoader { get; }
        /// <summary>
        /// Gets a content loader to load an entity
        /// </summary>
        IEntityContentLoader EntityContentLoader { get; }
        /// <summary>
        /// Gets a content loader to load a material
        /// </summary>
        IMaterialContentLoader MaterialContentLoader { get; }
    }
}
