using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    internal sealed class Direct3D9LayerImplementor : ILayerImplementor
    {
        private static Direct3D9LayerImplementor instance = null;
        public static Direct3D9LayerImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D9LayerImplementor();
            }

            return instance;
        }

        private Direct3D9LayerImplementor()
        {
        }

        public IMeshImplementor MeshImplementor
        {
            get { return Direct3D9MeshImplementor.GetInstance(); }
        }


        public IMatrixImplementor MatrixImplementor
        {
            get { return Direct3D9MatrixImplementor.GetInstance(); }
        }

        public IViewportImplementor ViewportImplementor
        {
            get { return Direct3D9ViewportImplementor.GetInstance(); }
        }


        public IMaterialImplementor MaterialImplementor
        {
            get { return Direct3D9MaterialImplementor.GetInstance(); }
        }


        public ILightImplementor LightImplementor
        {
            get { return Direct3D9LightImplementor.GetInstance(); }
        }
    }
}
