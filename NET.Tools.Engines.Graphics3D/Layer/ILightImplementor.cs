using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public interface ILightImplementor : IImplementor
    {
        void ActivateLight(Light light);
        void DeactivateLight(Light light);
    }
}
