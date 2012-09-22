using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public abstract class Mesh
    {
        internal void Render()
        {
            OnRender();
        }

        protected abstract void OnRender();
    }
}
