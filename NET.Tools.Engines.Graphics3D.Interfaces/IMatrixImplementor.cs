using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D;
using SlimDX;

namespace NET.Tools.Engines.Graphics3D.Interfaces
{
    public interface IMatrixImplementor : IImplementor
    {
        void SetupCamera(ViewInformation view, ProjectionInformation projection);
        /// <summary>
        /// Setup the given matrix to the implemented device. Overwrite the old matrix
        /// </summary>
        /// <param name="matrix">The matrix to setup on device</param>
        /// <returns>The old matrix before setup the new matrix</returns>
        Matrix SetTransformation(Matrix matrix);
        /// <summary>
        /// Add the given matrix to the implemented device. Multiply the current matrix with the new matrix
        /// </summary>
        /// <param name="matrix">The matrix to setup on device</param>
        /// <returns>The old matrix before setup the new matrix</returns>
        Matrix AddTransformation(Matrix matrix);
    }
}
