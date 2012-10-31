using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SlimDX;

namespace NET.Tools.Engines.Graphics3D
{
    public abstract class LightCreator : Creator<Light>
    {
        public static LightCreator CreatePointLight(Vector3 position, Color ambient, Color diffuse, Color specular, float power)
        {
            return new PointLightCreator(position, ambient, diffuse, specular, power);
        }
    }
}
