using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent the entity manager
    /// </summary>
    public static class MeshManager
    {
        private static IDictionary<String, Mesh> meshList = new Dictionary<String, Mesh>();

        /// <summary>
        /// Load an entity from mesh file
        /// </summary>
        /// <param name="key">Key for this entity</param>
        /// <param name="meshFile">Meshfile to search</param>
        /// <param name="graphics">The graphics object for rendering</param>
        /// <param name="handle">Handling for exist meshes</param>
        /// <returns>The new mesh</returns>
        public static Mesh LoadMesh(String key, String meshFile, Graphics3D graphics, ManagerCreateHandling handle)
        {
            if (meshList.ContainsKey(key))
            {
                if (handle == ManagerCreateHandling.DoNothingIfExists)
                {
                    return meshList[key];
                }
                else if (handle == ManagerCreateHandling.OverwriteIfExists)
                {
                    Mesh mesh = new Mesh(meshFile, graphics);
                    meshList[key].Dispose();
                    meshList[key] = mesh;
                    return mesh;
                }
                else if (handle == ManagerCreateHandling.ThrowExceptionIfExists)
                {
                    throw new ArgumentException("The key <" + key + "> cannot be found in mesh list!");
                }
                else
                    throw new NotImplementedException();
            }
            else
            {
                Mesh mesh = new Mesh(meshFile, graphics);
                meshList.Add(key, mesh);
                return mesh;
            }
        }

        /// <summary>
        /// Get the entity by its name
        /// </summary>
        /// <param name="key">The key of entity to search</param>
        /// <returns></returns>
        public static Mesh GetMesh(String key)
        {
            if (!meshList.ContainsKey(key))
                throw new ArgumentException("Cannot find mesh <" + key + ">!");

            return meshList[key];
        }

        public static bool ContainsMesh(String key)
        {
            return meshList.ContainsKey(key);
        }

        /// <summary>
        /// Remove an entity and free the memory
        /// </summary>
        /// <param name="key">The key of entity</param>
        public static void RemoveMesh(String key)
        {
            if (!meshList.ContainsKey(key))
                throw new ArgumentException("Cannot find mesh <" + key + ">!");

            meshList[key].Dispose();
            meshList.Remove(key);
        }
    }

    /// @}
}
