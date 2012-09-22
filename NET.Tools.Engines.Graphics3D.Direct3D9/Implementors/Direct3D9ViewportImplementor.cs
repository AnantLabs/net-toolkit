using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXViewport = SlimDX.Direct3D9.Viewport;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    internal sealed class Direct3D9ViewportImplementor : IViewportImplementor
    {
        private static Direct3D9ViewportImplementor instance = null;
        public static Direct3D9ViewportImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D9ViewportImplementor();
            }

            return instance;
        }

        private Direct3D9ViewportImplementor()
        {
        }

        public void SetViewport(Viewport vp)
        {
            DXViewport dxvp = Direct3DConverter9.ConvertToViewport(vp);
            GraphicsDirect3D9.Device.Viewport = dxvp;
        }
    }
}
