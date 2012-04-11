using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class MaterialCreator : Creator<Material>
    {
        public static MaterialCreator CreateMaterial(Color ambient, Color diffuse, Color emissive, Color specular, float power)
        {
            MaterialCreator creator = new MaterialCreator();
            creator.Ambient = ambient;
            creator.Diffuse = diffuse;
            creator.Emissive = emissive;
            creator.Specular = specular;
            creator.Power = power;

            return creator;
        }

        /// <summary>
        /// Create a default material with a plastic white look
        /// </summary>
        /// <returns></returns>
        public static MaterialCreator CreateDefaultMaterial()
        {
            return CreateMaterial(Color.White, Color.White, Color.Gray, Color.Black, 100);
        }

        public Color Ambient { get; private set; }
        public Color Diffuse { get; private set; }
        public Color Emissive { get; private set; }
        public Color Specular { get; private set; }
        public float Power { get; private set; }

        private MaterialCreator() 
        {
        }

        internal override Material Create()
        {
            Material material = new Material();
            material.Ambient = Ambient;
            material.Diffuse = Diffuse;
            material.Emissive = Emissive;
            material.Specular = Specular;
            material.Power = Power;

            return material;
        }
    }
}
