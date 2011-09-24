using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Basic class for all entities
    /// </summary>
    public abstract class Entity : Object3D
    {
        /// <summary>
        /// Gets or sets the material for this entity
        /// </summary>
        public Material Material { get; set; }
        /// <summary>
        /// The object that represent this entity
        /// </summary>
        public IRenderableObject RenderableObject { get; private set; }

        public Entity(IRenderableObject rendObj)
        {
            RenderableObject = rendObj;
            Material = null;
        }

        public override void Render(Graphics3D graphics)
        {
            if (!IsVisible)
                return;

            Material.SetMaterial(graphics);
            RenderableObject.Render(graphics);
        }

        public override void Dispose()
        {
            RenderableObject.Dispose();
        }
    }

    /// @}
}
