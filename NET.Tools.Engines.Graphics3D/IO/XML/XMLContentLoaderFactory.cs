using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// <summary>
    /// Represent a loader factory for XML files. Initialization with LoaderFactory!
    /// </summary>
    internal sealed class XMLContentLoaderFactory : IContentLoaderFactory
    {
        private static XMLContentLoaderFactory instance = null;
        public static XMLContentLoaderFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new XMLContentLoaderFactory();
            }

            return instance;
        }

        private XMLContentLoaderFactory()
        {
        }

        public IMeshContentLoader MeshContentLoader
        {
            get { throw new NotImplementedException(); }
        }

        public ITextureContentLoader TextureContentLoader
        {
            get { throw new NotImplementedException(); }
        }

        public IEntityContentLoader EntityContentLoader
        {
            get { throw new NotImplementedException(); }
        }

        public IMaterialContentLoader MaterialContentLoader
        {
            get { throw new NotImplementedException(); }
        }
    }
}
