using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Mathematica;
using Microsoft.DirectX.Direct3D;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent an entoty graphical node
    /// 
    /// With this node will be render an entity
    /// </summary>
    public sealed class EntityGraphicsNode : GraphicsNode
    {
        /// <summary>
        /// Gets or sets the contained entity of this node
        /// </summary>
        public Entity Entity { get; set; }

        public EntityGraphicsNode(String name, Entity entity, Vector3D position, Vector3D scaling, Quaternion3D rotation)
            : base(name, position, scaling, rotation)
        {
            Entity = entity;
        }

        public EntityGraphicsNode(String name, Entity entity)
            : this(name, entity, new Vector3D(), new Vector3D(1, 1, 1), new Quaternion3D())
        {
        }

        protected override void RenderInternal(Graphics3D graphics)
        {
            base.RenderInternal(graphics);
            Entity.Render(graphics);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    /// @}
}
