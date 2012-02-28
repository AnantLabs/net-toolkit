using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Common.Tools;
using System.Collections;
using NET.Tools.Engines.Graphics3D.IO;
using System.IO;

namespace NET.Tools.Engines.Graphics3D.Common.Managers
{
    public static class EntityManager
    {
        private static Dictionary<String, Entity> entities = new Dictionary<string, Entity>();

        internal static Entity GetEntity(String key)
        {
            return entities[key];
        }

        public static void SetEntity(String key, EntityCreator creator)
        {
            SetEntity(key, creator.Create());
        }

        private static void SetEntity(String key, Entity mesh)
        {
            if (entities.ContainsKey(key))
            {
                entities[key] = mesh;
            }
            else
            {
                entities.Add(key, mesh);
            }
        }

        public static bool ContainsEntity(String key)
        {
            return entities.ContainsKey(key);
        }

        public static void RemoveEntity(String key)
        {
            entities.Remove(key);
        }

        public static int CountOfEntities { get { return entities.Count; } }

        public static void LoadFromFile(IContentLoaderFactory factory, FileInfo file)
        {
            IEntityContentLoader entityContentLoader = factory.EntityContentLoader;
            //TODO
        }

        internal static IEnumerable Iterator
        {
            get
            {
                return entities.Values;
            }
        }
    }
}
