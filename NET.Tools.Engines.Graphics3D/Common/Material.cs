using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class Material
    {
        public Color Ambient { get; set; }
        public Color Diffuse { get; set; }
        public Color Specular { get; set; }
        public Color Emmesive { get; set; }

        internal Material()
        {
            Ambient = Color.White;
            Diffuse = Color.White;
            Specular = Color.Black;
            Emmesive = Color.Gray;
        }
    }
}
