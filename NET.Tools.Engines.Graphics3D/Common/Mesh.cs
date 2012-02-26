using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Common
{
    public abstract class Mesh<T>
    {
        protected T mesh;

        protected Mesh(T mesh)
        {
            this.mesh = mesh;
        }

        internal abstract void Render();
    }
}
