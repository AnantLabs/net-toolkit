using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Direct3D11
{
    internal sealed class Direct3D11LightImplementor : ILightImplementor
    {
        private static Direct3D11LightImplementor instance = null;
        public static Direct3D11LightImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D11LightImplementor();
            }

            return instance;
        }

        private Direct3D11LightImplementor()
        {
        }

        public void ActivateLight(Light light)
        {
            throw new NotImplementedException();
        }

        public void DeactivateLight(Light light)
        {
            throw new NotImplementedException();
        }
    }
}
