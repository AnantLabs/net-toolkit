/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NET.Tools.Engines.Graphics3D.Common;
using OpenTK.Graphics;
using NET.Tools.Engines.Graphics3D.Configuration;
using OpenTK;

namespace NET.Tools.Engines.Graphics3D.Engines.Converter
{
    internal static class OpenGLConverter
    {
        public static Rectangle ConvertFromViewport(Viewport vp)
        {
            return new Rectangle(vp.Left, vp.Top, vp.Width, vp.Height);
        }

        public static ColorFormat ConvertFromColorMode(ColorMode mode)
        {
            switch (mode)
            {
                case ColorMode.Bit16:
                    return new ColorFormat(4, 4, 4, 4);
                case ColorMode.Bit32:
                    return new ColorFormat(8, 8, 8, 8);
                default:
                    throw new NotImplementedException(mode.ToString());
            }
        }

        public static GameWindowFlags ConvertFromFullScreen(bool fullscreen)
        {
            return (fullscreen ? GameWindowFlags.Fullscreen : GameWindowFlags.Default);
        }
    }
}*/
