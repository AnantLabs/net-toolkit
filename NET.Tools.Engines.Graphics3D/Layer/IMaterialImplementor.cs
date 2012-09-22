using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public interface IMaterialImplementor : IImplementor
    {
        /// <summary>
        /// Sets the given material on graphics device
        /// </summary>
        /// <param name="material"></param>
        void SetMaterial(Material material);
        /// <summary>
        /// Gets the current material on graphics device
        /// </summary>
        /// <returns></returns>
        Material GetMaterial();
    }
}
