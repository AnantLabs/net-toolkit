using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Configuration;
using SlimDX.Direct3D9;
using Viewport3D = NET.Tools.Engines.Graphics3D.Common.Viewport;

namespace NET.Tools.Engines.Graphics3D.Converter
{
    internal static class Direct3DConverter9
    {
        public static PresentParameters ConvertToPresentParameters(Graphics3DConfiguration configuration)
        {
            PresentParameters pp = new PresentParameters();
            pp.BackBufferCount = 1; //TODO
            pp.BackBufferFormat = ConvertToFormat(configuration.ScreenConfiguration.ColorMode);
            pp.BackBufferHeight = configuration.ScreenConfiguration.Height;
            pp.BackBufferWidth = configuration.ScreenConfiguration.Width;
            pp.EnableAutoDepthStencil = true;
            pp.FullScreenRefreshRateInHertz = 0; //TODO
            pp.Multisample = MultisampleType.None; //TODO
            pp.MultisampleQuality = 0;
            pp.PresentationInterval = PresentInterval.One; //TODO
            pp.SwapEffect = SwapEffect.Discard;
            pp.Windowed = !configuration.ScreenConfiguration.FullScreen;
            pp.DeviceWindowHandle = configuration.Target;
            pp.AutoDepthStencilFormat = Format.D24S8;

            return pp;
        }

        public static Format ConvertToFormat(ColorMode mode)
        {
            switch (mode)
            {
                case ColorMode.Bit16:
                    return Format.A4R4G4B4;
                case ColorMode.Bit32:
                    return Format.A8R8G8B8;
                default:
                    throw new NotImplementedException(mode.ToString());
            }
        }

        public static Viewport ConvertToViewport(Viewport3D vp)
        {
            Viewport viewport = new Viewport();
            viewport.X = vp.Left;
            viewport.Y = vp.Top;
            viewport.Width = vp.Width;
            viewport.Height = vp.Height;

            return viewport;
        }
    }
}
