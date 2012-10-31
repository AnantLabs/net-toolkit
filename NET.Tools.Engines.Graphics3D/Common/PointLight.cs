using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using System.Drawing;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class PointLight : Light
    {
        public Vector3 Position { get; set; }
        public Color Ambient { get; set; }
        public Color Diffuse { get; set; }
        public Color Specular { get; set; }
        public float Power { get; set; }

        internal PointLight()
        {
        }
    }
}
