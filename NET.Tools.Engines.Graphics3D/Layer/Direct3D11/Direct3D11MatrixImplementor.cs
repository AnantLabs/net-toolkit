using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Common;

namespace NET.Tools.Engines.Graphics3D.Layer.Direct3D11
{
    internal sealed class Direct3D11MatrixImplementor : IMatrixImplementor
    {
        private static Direct3D11MatrixImplementor instance = null;
        public static Direct3D11MatrixImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D11MatrixImplementor();
            }

            return instance;
        }

        private Direct3D11MatrixImplementor()
        {
        }

        public void SetupCamera(ViewInformation view, ProjectionInformation projection)
        {
            throw new NotImplementedException();
        }


        public SlimDX.Matrix SetTransformation(SlimDX.Matrix matrix)
        {
            throw new NotImplementedException();
        }


        public SlimDX.Matrix AddTransformation(SlimDX.Matrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
