using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class EntityNode : Node
    {
        private Entity entity;
        private Material oldMaterial = null; //Backup

        /// <summary>
        /// Gets or sets the material to use for this entity. If it is null no material changing will be done
        /// </summary>
        public Material Material { get; set; }

        internal EntityNode(Entity entity)
        {
            this.entity = entity;
        }

        protected override void OnPreNodeRendering()
        {
            if (Material != null)
            {
                oldMaterial = Graphics3DSystem.Implementors.MaterialImplementor.GetMaterial();
                Graphics3DSystem.Implementors.MaterialImplementor.SetMaterial(Material);
            }
        }

        protected override void OnPostNodeRendering()
        {
            if (oldMaterial != null)
            {
                Graphics3DSystem.Implementors.MaterialImplementor.SetMaterial(oldMaterial);
                oldMaterial = null;
            }
        }

        protected override void OnSelfRendering()
        {
            if (entity == null)
                return;

            entity.Render();
        }
    }
}
