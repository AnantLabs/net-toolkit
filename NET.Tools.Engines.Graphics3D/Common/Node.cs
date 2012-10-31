using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;

namespace NET.Tools.Engines.Graphics3D
{
    public abstract class Node
    {
        public Matrix Trandformation { get; set; }
        public IDictionary<String, Node> Nodes { get; private set; }

        protected Node()
        {
            Nodes = new Dictionary<String, Node>();
            Trandformation = Matrix.Identity;
        }

        internal void Render()
        {
            Matrix oldTransformation = Graphics3DSystem.Implementors.MatrixImplementor.AddTransformation(Trandformation);
            OnPreNodeRendering();

            OnSelfRendering();

            foreach (String nodeName in Nodes.Keys)
            {
                Nodes[nodeName].Render();
            }

            OnPostNodeRendering();
            Graphics3DSystem.Implementors.MatrixImplementor.SetTransformation(oldTransformation);
        }

        /// <summary>
        /// Is called if the node want to render itself (only itself, not the child nodes!)
        /// <code>
        ///    Matrix oldTransformation = Graphics3DSystem.Implementors.MatrixImplementor.AddTransformation(Trandformation);
        ///    OnPreNodeRendering();
        ///
        ///    OnSelfRendering(); //Here is the call
        ///
        ///    foreach (String nodeName in Nodes.Keys)
        ///    {
        ///        Nodes[nodeName].Render();
        ///    }
        ///
        ///    OnPostNodeRendering();
        ///    Graphics3DSystem.Implementors.MatrixImplementor.SetTransformation(oldTransformation);
        /// </code>
        /// </summary>
        protected abstract void OnSelfRendering();
        /// <summary>
        /// Is called if the node rendering routine will be started (after transformation, before OnSelfRendering())
        /// <code>
        ///    Matrix oldTransformation = Graphics3DSystem.Implementors.MatrixImplementor.AddTransformation(Trandformation);
        ///    OnPreNodeRendering(); //Here is the call
        ///
        ///    OnSelfRendering();
        ///
        ///    foreach (String nodeName in Nodes.Keys)
        ///    {
        ///        Nodes[nodeName].Render();
        ///    }
        ///
        ///    OnPostNodeRendering();
        ///    Graphics3DSystem.Implementors.MatrixImplementor.SetTransformation(oldTransformation);
        /// </code>
        /// </summary>
        protected virtual void OnPreNodeRendering()
        {
            //Empty
        }
        /// <summary>
        /// Is called if the node rendering routine will be finished (after child node renderings, before re-transformation)
        /// <code>
        ///    Matrix oldTransformation = Graphics3DSystem.Implementors.MatrixImplementor.AddTransformation(Trandformation);
        ///    OnPreNodeRendering();
        ///
        ///    OnSelfRendering(); //Here is the call
        ///
        ///    foreach (String nodeName in Nodes.Keys)
        ///    {
        ///        Nodes[nodeName].Render();
        ///    }
        ///
        ///    OnPostNodeRendering(); // Here is the call
        ///    Graphics3DSystem.Implementors.MatrixImplementor.SetTransformation(oldTransformation);
        /// </code>
        /// </summary>
        protected virtual void OnPostNodeRendering()
        {
            //Empty
        }

        public EntityNode AddEntityNode(String nodeName, Entity entity)
        {
            EntityNode node = new EntityNode(entity);
            Nodes.Add(nodeName, node);

            return node; 
        }

        public EntityNode AddEntityNode(String nodeName, String entityName)
        {
            return AddEntityNode(nodeName, EntityManager.GetEntity(entityName));
        }

        public TransformationNode AddTransformationNode(String nodeName)
        {
            TransformationNode node = new TransformationNode();
            Nodes.Add(nodeName, node);

            return node;
        }
    }
}
