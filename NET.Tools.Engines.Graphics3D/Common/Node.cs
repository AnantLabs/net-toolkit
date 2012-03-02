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

            OnRender();

            foreach (String nodeName in Nodes.Keys)
            {
                Nodes[nodeName].Render();
            }

            Graphics3DSystem.Implementors.MatrixImplementor.SetTransformation(oldTransformation);
        }

        protected abstract void OnRender();

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
