using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Configuration;
using SlimDX.Direct3D9;

namespace NET.Tools.Engines.Graphics3D.Converter
{
    internal static class Direct3DConverter9
    {
        public static PresentParameters Convert(Graphics3DConfiguration configuration)
        {
            PresentParameters pp = new PresentParameters();
            pp.BackBufferCount = 1; //TODO
            pp.BackBufferFormat = Convert(configuration.ScreenConfiguration.ColorMode);
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

        public static Format Convert(ColorMode mode)
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
    }
}
