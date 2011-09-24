using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a configurator
    /// </summary>
    public interface IConfigurator
    {
        /// <summary>
        /// Load configuration from file
        /// </summary>
        /// <param name="fileName">source file</param>
        void Load(String fileName);
        /// <summary>
        /// Load configuration from stream
        /// </summary>
        /// <param name="stream">source stream</param>
        void Load(Stream stream);

        /// <summary>
        /// Save configuration to file
        /// </summary>
        /// <param name="fileName">destination file</param>
        void Save(String fileName);
        /// <summary>
        /// Save configuration to stream
        /// </summary>
        /// <param name="stream">destination stream</param>
        void Save(Stream stream);

        /// <summary>
        /// Gets the application runs in fullscreen mode
        /// </summary>
        bool FullScreen { get; set; }
        /// <summary>
        /// Activate or deactivate the anti alaising
        /// </summary>
        bool AntiAlaisingEnabled { get; set; }
        /// <summary>
        /// Gets or Sets the quality of anti alaising
        /// </summary>
        AntiAlaising AntiAlaisingQuality { get; set; }
        /// <summary>
        /// Activate or deactivate the stencil
        /// </summary>
        bool StencilEnabled { get; set; }
        /// <summary>
        /// Gets or sets the screen width
        /// </summary>
        uint ScreenWidth { get; set; }
        /// <summary>
        /// Gets or sets the screen height
        /// </summary>
        uint ScreenHeight { get; set; }
        /// <summary>
        /// Gets or sets the color depth
        /// </summary>
        ColorDepth ColorDepth { get; set; }
        /// <summary>
        /// Gets or sets the refresh interval
        /// </summary>
        RefreshInterval RefreshInterval { get; set; }

        //*************************************************

        /// <summary>
        /// Gets or sets the general filter for texture rendering
        /// </summary>
        RenderFilter RenderFilter { get; set; }
        /// <summary>
        /// Gets or sets the general filter for texture loading
        /// </summary>
        TextureFilter TextureFilter { get; set; }
        /// <summary>
        /// Gets or sets the general maximum width of a texture
        /// 
        /// Set it to 0 to ignore it
        /// </summary>
        uint MaximumTextureWidth { get; set; }
        /// <summary>
        /// Gets or sets the general maximum height of a texture
        /// 
        /// Set it to 0 to ignore it
        /// </summary>
        uint MaximumTextureHeight { get; set; }
        /// <summary>
        /// Maximum level of mip-mapping
        /// </summary>
        int MaximumMipLevel { get; set; }
        /// <summary>
        /// Maximum anisotropy-level
        /// </summary>
        int MaximumAnisotropyLevel { get; set; }
    }

    /// @}
}
