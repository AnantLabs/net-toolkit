using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXViewport = SlimDX.Direct3D11.Viewport;

namespace NET.Tools.Engines.Graphics3D.Direct3D11
{
    internal sealed class Direct3D11ViewportImplementor : IViewportImplementor
    {
        private static Direct3D11ViewportImplementor instance = null;
        public static Direct3D11ViewportImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D11ViewportImplementor();
            }

            return instance;
        }

        private Direct3D11ViewportImplementor()
        {
        }

        public void SetViewport(Viewport vp)
        {
            DXViewport dxvp = Direct3DConverter11.ConvertToViewport(vp);
            GraphicsDirect3D11.Device.ImmediateContext.Rasterizer.SetViewports(dxvp);
        }
    }
}
