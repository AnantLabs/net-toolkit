using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public abstract class Light
    {
        public int Index { get; set; }

        internal void ActivateLight()
        {
            Graphics3DSystem.Implementors.LightImplementor.ActivateLight(this);
        }

        internal void DeactivateLight()
        {
            Graphics3DSystem.Implementors.LightImplementor.DeactivateLight(this);
        }
    }
}
