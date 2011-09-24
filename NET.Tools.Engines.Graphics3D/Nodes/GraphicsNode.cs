using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Mathematica;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Basic class for all graphical nodes
    /// </summary>
    public class GraphicsNode : Object3D
    {
        /// <summary>
        /// The name (and the key) for this node
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Children of this node (tree)
        /// </summary>
        public IList<GraphicsNode> Children { get; private set; }

        public GraphicsNode(String name, Vector3D position, Vector3D scaling, Quaternion3D rotation)
        {
            Name = name;
            Position = position;
            Scaling = scaling;
            Rotation = rotation;

            Children = new List<GraphicsNode>();
        }

        public GraphicsNode(String name)
            : this(name, new Vector3D(), new Vector3D(1, 1, 1), new Quaternion3D())
        {
        }

        public override void Render(Graphics3D graphics)
        {
            if (!IsVisible)
                return;

            RenderInternal(graphics);

            foreach (GraphicsNode node in Children)
                node.Render(graphics);
        }

        /// <summary>
        /// Internal renderer (template pattern)
        /// </summary>
        /// <param name="graphics">Graphics-Object to render</param>
        protected virtual void RenderInternal(Graphics3D graphics)
        {
            Matrix matrix = graphics.D3DX9.Transform.World;
            matrix *= Matrix.Translation(Position.ToVector3());
            matrix *= Matrix.RotationAxis(Rotation.Axis.ToVector3(), (float)Rotation.AngleRadian);
            matrix *= Matrix.Scaling(Scaling.ToVector3());

            graphics.D3DX9.Transform.World = matrix;
        }

        public override void Dispose()
        {
            foreach (GraphicsNode node in Children)
                node.Dispose();
        }
    }

    /// @}
}
