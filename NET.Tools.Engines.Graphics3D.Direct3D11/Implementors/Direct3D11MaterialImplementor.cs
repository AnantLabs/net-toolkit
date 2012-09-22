using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Direct3D11
{
    internal sealed class Direct3D11MaterialImplementor : IMaterialImplementor
    {
        private static Direct3D11MaterialImplementor instance = null;
        public static Direct3D11MaterialImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D11MaterialImplementor();
            }

            return instance;
        }

        private Direct3D11MaterialImplementor()
        {
        }

        public void SetMaterial(Material material)
        {
            throw new NotImplementedException();
        }

        public Material GetMaterial()
        {
            throw new NotImplementedException();
        }
    }
}
