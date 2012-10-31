using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DXLight = SlimDX.Direct3D9.Light;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    internal sealed class Direct3D9LightImplementor : ILightImplementor
    {
        private static Direct3D9LightImplementor instance = null;
        public static Direct3D9LightImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D9LightImplementor();
            }

            return instance;
        }

        private Direct3D9LightImplementor()
        {
        }

        public void ActivateLight(Light light)
        {
            //TODO: Performance
            DXLight dxl = new DXLight();

            if (light is PointLight)
            {
                PointLight pointLight = light as PointLight;
                dxl.Type = SlimDX.Direct3D9.LightType.Point;
                dxl.Ambient = pointLight.Ambient;
                dxl.Diffuse = pointLight.Diffuse;
                dxl.Specular = pointLight.Specular;
                dxl.Position = pointLight.Position;
                dxl.Range = pointLight.Power;
                //TODO
                dxl.Attenuation0 = 0.0001f;
                dxl.Attenuation1 = 0.0001f;
                dxl.Attenuation2 = 0.0001f;
            }

            GraphicsDirect3D9.Device.SetLight(light.Index, dxl);
            GraphicsDirect3D9.Device.EnableLight(light.Index, true);
        }

        public void DeactivateLight(Light light)
        {
            GraphicsDirect3D9.Device.EnableLight(light.Index, false);
        }
    }
}
