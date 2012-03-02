using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    internal sealed class EntityObjectCreator : EntityCreator
    {
        private Mesh mesh;
        //TODO:Texture

        internal EntityObjectCreator(Mesh mesh)
        {
            this.mesh = mesh;
        }

        internal override Entity Create()
        {
            return new ObjectEntity(mesh);
        }
    }
}
