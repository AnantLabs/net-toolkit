using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class EntityNode : Node
    {
        private Entity entity;

        internal EntityNode(Entity entity)
        {
            this.entity = entity;
        }

        protected override void OnRender()
        {
            if (entity == null)
                return;

            entity.Render();
        }
    }
}
