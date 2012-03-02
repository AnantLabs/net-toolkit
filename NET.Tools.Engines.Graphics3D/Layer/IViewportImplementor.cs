using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public interface IViewportImplementor : IImplementor
    {
        void SetViewport(Viewport vp);
    }
}
