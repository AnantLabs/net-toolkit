using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SlimDX;

namespace NET.Tools.Engines.Graphics3D
{
    internal sealed class PointLightCreator : LightCreator
    {
        public Color Diffuse { get; private set; }
        public Color Specular { get; private set; }
        public Color Ambient { get; private set; }
        public float Power { get; private set; }
        public Vector3 Position { get; private set; }

        internal PointLightCreator(Vector3 position, Color ambient, Color diffuse, Color specular, float power) 
        {
            Position = position;
            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;
            Power = power;
        }

        internal override Light Create()
        {
            PointLight light = new PointLight();
            light.Ambient = Ambient;
            light.Diffuse = Diffuse;
            light.Specular = Specular;
            light.Position = Position;
            light.Power = Power;

            return light;
        }
    }
}
