using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXMaterial = SlimDX.Direct3D9.Material;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    internal sealed class Direct3D9MaterialImplementor : IMaterialImplementor
    {
        private static Direct3D9MaterialImplementor instance = null;
        public static Direct3D9MaterialImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D9MaterialImplementor();
            }

            return instance;
        }

        private Direct3D9MaterialImplementor()
        {
        }

        public void SetMaterial(Material material)
        {
            DXMaterial dxm = new DXMaterial();
            dxm.Ambient = material.Ambient;
            dxm.Diffuse = material.Diffuse;
            dxm.Emissive = material.Emissive;
            dxm.Specular = material.Specular;
            dxm.Power = material.Power;

            GraphicsDirect3D9.Device.Material = dxm;
        }

        public Material GetMaterial()
        {
            Material material = new Material();
            DXMaterial dxm = GraphicsDirect3D9.Device.Material;

            material.Ambient = dxm.Ambient.ToColor();
            material.Diffuse = dxm.Diffuse.ToColor();
            material.Emissive = dxm.Emissive.ToColor();
            material.Specular = dxm.Specular.ToColor();
            material.Power = dxm.Power;

            return material;
        }
    }
}
