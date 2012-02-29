using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using NET.Tools.Engines.Graphics3D.Engines;
using NET.Tools.Engines.Graphics3D.Common.Managers;

namespace NET.Tools.Engines.Graphics3D.Common
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
            Matrix oldTransformation = Graphics3DDevice.Implementors.MatrixImplementor.AddTransformation(Trandformation);

            OnRender();

            foreach (String nodeName in Nodes.Keys)
            {
                Nodes[nodeName].Render();
            }

            Graphics3DDevice.Implementors.MatrixImplementor.SetTransformation(oldTransformation);
        }

        protected abstract void OnRender();

        public EntityNode AddEntityNode(String nodeName, String entityName)
        {
            EntityNode node = new EntityNode(EntityManager.GetEntity(entityName));
            Nodes.Add(nodeName, node);

            return node; 
        }

        public TransformationNode AddTransformationNode(String nodeName)
        {
            TransformationNode node = new TransformationNode();
            Nodes.Add(nodeName, node);

            return node;
        }
    }
}
