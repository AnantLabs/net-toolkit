using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace NET.Tools.Engines.Graphics3D
{
    public static class EntityManager
    {
        private static Dictionary<String, Entity> entities = new Dictionary<string, Entity>();

        public static Entity GetEntity(String key)
        {
            return entities[key];
        }

        public static Entity CreateEntity(String key, EntityCreator creator)
        {
            Entity entity = creator.Create();
            SetEntity(key, entity);

            return entity;
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
