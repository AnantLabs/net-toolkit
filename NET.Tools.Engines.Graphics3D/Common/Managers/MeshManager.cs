using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DXMesh = SlimDX.Direct3D9.Mesh;
using System.IO;

namespace NET.Tools.Engines.Graphics3D
{
    public static class MeshManager
    {
        private static Dictionary<String, Mesh> meshes = new Dictionary<string, Mesh>();

        public static Mesh GetMesh(String key)
        {
            return meshes[key];
        }

        public static Mesh CreateMesh(String key, MeshCreator creator)
        {
            Mesh mesh = creator.Create();
            SetMesh(key, mesh);

            return mesh;
        }

        private static void SetMesh(String key, Mesh mesh)
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

        public static void LoadFromFile(IContentLoaderFactory factory, FileInfo file)
        {
            IMeshContentLoader meshContentLoader = factory.MeshContentLoader;
            //TODO
        }

        internal static IEnumerable Iterator
        {
            get
            {
                return meshes.Values;
            }
        }
    }
}
