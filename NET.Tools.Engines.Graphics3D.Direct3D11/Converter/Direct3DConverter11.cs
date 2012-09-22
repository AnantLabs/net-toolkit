using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.DXGI;
using SlimDX;
using Viewport3D = NET.Tools.Engines.Graphics3D.Viewport;
using DXViewport = SlimDX.Direct3D11.Viewport;
using SlimDX.Direct3D11;

namespace NET.Tools.Engines.Graphics3D.Direct3D11
{
    internal static class Direct3DConverter11
    {
        public static SwapChainDescription ConvertToSwapChainDescription(Graphics3DConfiguration configuration)
        {
            SwapChainDescription description = new SwapChainDescription();
            description.BufferCount = 1; //TODO
            description.IsWindowed = !configuration.ScreenConfiguration.FullScreen;
            description.OutputHandle = configuration.Target;
            description.SwapEffect = SlimDX.DXGI.SwapEffect.Discard;
            description.Usage = SlimDX.DXGI.Usage.RenderTargetOutput;
            description.ModeDescription = new ModeDescription(
                configuration.ScreenConfiguration.Width,
                configuration.ScreenConfiguration.Height, 
                new Rational(60, 1), //TODO Hz
                ConvertToFormat(configuration.ScreenConfiguration.ColorMode));
            description.SampleDescription = new SampleDescription(
                1, //TODO
                0);
            description.Flags = SwapChainFlags.AllowModeSwitch;

            return description;
        }

        public static Format ConvertToFormat(ColorMode mode)
        {
            switch (mode)
            {
                case ColorMode.Bit16:
                    throw new NotSupportedException();
                case ColorMode.Bit32:
                    return Format.R8G8B8A8_UNorm;
                default:
                    throw new NotImplementedException(mode.ToString());
            }
        }

        public static DXViewport ConvertToViewport(Viewport3D vp)
        {
            DXViewport viewport = new DXViewport();
            viewport.X = vp.Left;
            viewport.Y = vp.Top;
            viewport.Width = vp.Width;
            viewport.Height = vp.Height;

            return viewport;
        }
    }
}
