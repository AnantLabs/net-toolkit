using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Engines;
using NET.Tools.Engines.Graphics3D.Common.Managers;

namespace NET.Tools.Engines.Graphics3D.Common.Tools
{
    public abstract class EntityCreator : Creator<Entity>
    {
        public static EntityCreator CreateObjectEntity(String meshKey)
        {
            return new EntityObjectCreator(MeshManager.GetMesh(meshKey));
        }
    }
}
