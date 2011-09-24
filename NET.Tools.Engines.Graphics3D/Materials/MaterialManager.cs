using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a manager for materials
    /// </summary>
    public static class MaterialManager
    {
        private static IDictionary<String, Material> materials = new Dictionary<String, Material>();

        /// <summary>
        /// Creates a new easy material
        /// 
        /// This is a only colored material
        /// </summary>
        /// <remarks>Please note that you can only create a new material. The key must be new</remarks>
        /// <param name="key">Key for material</param>
        /// <param name="handle">Descripe the handling for this creating</param>
        /// <returns></returns>
        public static Material CreateEasyMaterial(String key, ManagerCreateHandling handle)
        {
            if (materials.ContainsKey(key))
            {
                if (handle == ManagerCreateHandling.ThrowExceptionIfExists)
                {
                    throw new ArgumentException("The given key <" + key + " already exists in material list!");
                }
                else if (handle == ManagerCreateHandling.OverwriteIfExists)
                {
                    Material material = new Material();
                    materials[key].Dispose();
                    materials[key] = material;
                    return material;
                }
                else if (handle == ManagerCreateHandling.DoNothingIfExists)
                {
                    return materials[key];
                }
                else
                    throw new NotImplementedException();
            }
            else
            {
                Material material = new Material();
                materials.Add(key, material);

                return material;
            }
        }

        /// <summary>
        /// Creates a new easy material
        /// 
        /// This is a only colored material
        /// </summary>
        /// <remarks>ManagerCreateHandling is ThrowExceptionIfExists</remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Material CreateEasyMaterial(String key)
        {
            return CreateEasyMaterial(key, ManagerCreateHandling.ThrowExceptionIfExists);
        }

        /// <summary>
        /// Gets the material by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Material GetMaterial(String key)
        {
            if (!materials.ContainsKey(key))
                throw new ArgumentException("The given key <" + key + "> cannot be found in material list!");

            return materials[key];        
        }

        public static bool ContainsMaterial(String key)
        {
            return materials.ContainsKey(key);
        }

        public static void RemoveMaterial(String key)
        {
            if (!materials.ContainsKey(key))
                throw new ArgumentException("The key <" + key + "> cannot be found in material list!");

            Material material = materials[key];
            material.Dispose();
            materials.Remove(key);
        }
    }

    /// @}
}
