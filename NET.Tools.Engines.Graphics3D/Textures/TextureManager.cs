using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Managed all dx textures
    /// </summary>
    public static class TextureManager
    {
        private static IDictionary<String, Texture> textures = new Dictionary<String, Texture>();

        /// <summary>
        /// Load a new texture from file
        /// </summary>
        /// <param name="key">Key for new texture</param>
        /// <param name="file">File with an image</param>
        /// <param name="graphics">Graphics3D-Object for rendering</param>
        /// <param name="handle">Handle for existing textures</param>
        /// <returns>New Texture</returns>
        public static Texture LoadTexture(String key, String file, Graphics3D graphics, ManagerCreateHandling handle)
        {
            if (textures.ContainsKey(key))
            {
                if (handle == ManagerCreateHandling.DoNothingIfExists)
                {
                    return textures[key];
                }
                else if (handle == ManagerCreateHandling.OverwriteIfExists)
                {
                    Texture texture = new Texture(key, file, graphics);
                    textures[key].Dispose();
                    textures[key] = texture;
                    return texture;
                }
                else if (handle == ManagerCreateHandling.ThrowExceptionIfExists)
                {
                    throw new ArgumentException("Cannot found key <" + key + "> in texture list!");
                }
                else
                    throw new NotImplementedException();
            }
            else
            {
                Texture texture = new Texture(key, file, graphics);
                textures.Add(key, texture);
                return texture;
            }
        }

        /// <summary>
        /// Load a new texture from file
        /// </summary>
        /// <param name="key">Key for new texture</param>
        /// <param name="file">File with an image</param>
        /// <param name="graphics">Graphics3D-Object for rendering</param>
        /// <returns>New Texture</returns>
        /// <remarks>Use ManagerCreateHandling.ThrowExceptionIfExists</remarks>
        public static Texture LoadTexture(String key, String file, Graphics3D graphics)
        {
            return LoadTexture(key, file, graphics, ManagerCreateHandling.ThrowExceptionIfExists);
        }

        public static Texture GetTexture(String key)
        {
            if (!textures.ContainsKey(key))
                throw new ArgumentException("Key <" + key + "> is unknown in texture manager!");

            return textures[key];
        }

        public static bool ContainsTexture(String key)
        {
            return textures.ContainsKey(key);
        }

        public static void RemoveTexture(String key)
        {
            if (!textures.ContainsKey(key))
                throw new ArgumentException("Key <" + key + "> is unknown in texture manager!");

            Texture texture = textures[key];
            texture.Dispose();
            textures.Remove(key);
        }
    }

    /// @}
}
