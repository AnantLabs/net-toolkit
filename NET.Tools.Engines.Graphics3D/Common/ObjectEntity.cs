using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Common
{
    internal sealed class ObjectEntity : Entity
    {
        private Mesh mesh;
        //TODO:Texture

        internal ObjectEntity(Mesh mesh)
        {
            this.mesh = mesh;
        }

        internal override void Render()
        {
            //TODO: Texture
            mesh.Render();
        }
    }
}
