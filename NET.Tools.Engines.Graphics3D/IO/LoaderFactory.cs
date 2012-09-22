using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public static class LoaderFactory
    {
        public static IContentLoaderFactory XMLContentLoaderFactory { get { return NET.Tools.Engines.Graphics3D.XMLContentLoaderFactory.GetInstance(); } }
    }
}
