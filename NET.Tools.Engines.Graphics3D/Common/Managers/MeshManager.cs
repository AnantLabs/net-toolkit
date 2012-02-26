using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DXMesh = SlimDX.Direct3D9.Mesh;
using NET.Tools.Engines.Graphics3D.Common.Tools;

namespace NET.Tools.Engines.Graphics3D.Common.Managers
{
    public static class MeshManager
    {
        private static Dictionary<String, Mesh<Object>> meshes = new Dictionary<string, Mesh<Object>>();

        internal static Mesh<Object> GetMesh(String key)
        {
            return meshes[key];
        }

        public static void SetMesh(String key, MeshCreator creator)
        {
            SetMesh(key, creator.CreateMesh());
        }

        private static void SetMesh(String key, Mesh<Object> mesh)
        {
            if (meshes.ContainsKey(key))
            {
                meshes[key] = mesh;
            }
            else
            {
                meshes.Add(key, mesh);
            }
        }

        public static bool ContainsMesh(String key)
        {
            return meshes.ContainsKey(key);
        }

        public static void RemoveMesh(String key)
        {
            meshes.Remove(key);
        }

        public static int CountOfMeshes { get { return meshes.Count; } }

        internal static IEnumerable Iterator
        {
            get
            {
                return meshes.Values;
            }
        }
    }
}
