using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public abstract class EntityCreator : Creator<Entity>
    {
        public static EntityCreator CreateObjectEntity(Mesh mesh)
        {
            return new EntityObjectCreator(mesh);
        }

        public static EntityCreator CreateObjectEntity(String meshKey)
        {
            return CreateObjectEntity(MeshManager.GetMesh(meshKey));
        }
    }
}
