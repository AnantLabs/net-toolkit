using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace NET.Tools.Engines.Graphics3D
{
    public static class MaterialManager
    {
        private static IDictionary<String, Material> materials = new Dictionary<String, Material>();

        public static Material GetMaterial(String key)
        {
            return materials[key];
        }

        public static Material CreateMaterial(String key, MaterialCreator creator)
        {
            Material material = creator.Create();
            SetMaterial(key, material);

            return material;
        }

        private static void SetMaterial(String key, Material material)
        {
            if (materials.ContainsKey(key))
            {
                materials[key] = material;
            }
            else
            {
                materials.Add(key, material);
            }
        }

        public static bool ContainsMaterial(String key)
        {
            return materials.ContainsKey(key);
        }

        public static void RemoveMaterial(String key)
        {
            materials.Remove(key);
        }

        public static int CountOfMaterials { get { return materials.Count; } }

        public static void LoadFromFile(IContentLoaderFactory factory, FileInfo file)
        {
            IMaterialContentLoader materialContentLoader = factory.MaterialContentLoader;
            //TODO
        }

        internal static IEnumerable Iterator
        {
            get
            {
                return materials.Values;
            }
        }
    }
}
