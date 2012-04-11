using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace NET.Tools.Engines.Graphics3D
{
    public static class LightManager
    {
        private static IDictionary<String, Light> lights = new Dictionary<String, Light>();

        public static Light GetLight(String key)
        {
            return lights[key];
        }

        public static Light CreateLight(String key, LightCreator creator)
        {
            Light light = creator.Create();
            SetLight(key, light);

            return light;
        }

        private static void SetLight(String key, Light material)
        {
            if (lights.ContainsKey(key))
            {
                lights[key] = material;
            }
            else
            {
                lights.Add(key, material);
            }
        }

        public static bool ContainsLight(String key)
        {
            return lights.ContainsKey(key);
        }

        public static void RemoveLight(String key)
        {
            lights.Remove(key);
        }

        public static int CountOfLights { get { return lights.Count; } }

        public static void LoadFromFile(IContentLoaderFactory factory, FileInfo file)
        {
            IMaterialContentLoader materialContentLoader = factory.MaterialContentLoader;
            //TODO
        }

        internal static IEnumerable Iterator
        {
            get
            {
                return lights.Values;
            }
        }
    }
}
