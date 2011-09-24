using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Filter for rendered textures
    /// </summary>
    public enum RenderFilter
    {
        None = 0,
        Point = 1,
        Linear = 2,
        Anisotropic = 3,
        PyramidalQuad = 6,
        GaussianQuad = 7,
    }

    /// <summary>
    /// Filter for texture loading
    /// </summary>
    public enum TextureFilter
    {
        None = 1,
        Point = 2,
        Linear = 3,
        Triangle = 4,
        Box = 5,
        MirrorU = 65536,
        MirrorV = 131072,
        MirrorW = 262144,
        Mirror = 458752,
        Dither = 524288,
        DitherDiffusion = 1048576,
        SrgbIn = 2097152,
        SrgbOut = 4194304,
        Srgb = 6291456,
    }

    /// @}
}
