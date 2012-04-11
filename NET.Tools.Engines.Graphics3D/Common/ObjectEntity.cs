using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    internal sealed class ObjectEntity : Entity
    {
        private Mesh mesh;        

        internal ObjectEntity(Mesh mesh)
        {
            this.mesh = mesh;
        }

        internal override void Render()
        {
            mesh.Render();
        }
    }
}
