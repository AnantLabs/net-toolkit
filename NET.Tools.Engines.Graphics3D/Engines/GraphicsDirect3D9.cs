using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using NET.Tools.Engines.Graphics3D.Configuration;
using NET.Tools.Engines.Graphics3D.Exceptions;
using NET.Tools.Engines.Graphics3D.Converter;
using SlimDX.Direct3D9;
using Viewport3D = NET.Tools.Engines.Graphics3D.Common.Viewport;
using NET.Tools.Engines.Graphics3D.Common.Managers;

namespace NET.Tools.Engines.Graphics3D.Engines
{
    public sealed class GraphicsDirect3D9 : Graphics3DDevice<Device>
    {
        #region Singleton

        private static GraphicsDirect3D9 instance = null;

        public static GraphicsDirect3D9 GetInstance()
        {
            if (GraphicsDirect3D9.CurrentDeviceType.HasValue &&
                GraphicsDirect3D9.CurrentDeviceType.Value != Graphics3DDeviceType.Direct3D9)
                throw new Graphics3DException("An other device is already initialized: " + GraphicsDirect3D9.CurrentDeviceType.Value.ToString());

            if (instance == null)
            {
                instance = new GraphicsDirect3D9();
                GraphicsDirect3D9.CurrentDeviceType = Graphics3DDeviceType.Direct3D9;
            }

            return instance;
        }

        #endregion

        private Device device = null;

        public override Graphics3DConfiguration Configuration
        {
            get;
            protected set;
        }

        public override bool IsDisposed
        {
            get;
            protected set;
        }

        private GraphicsDirect3D9()
        {
            IsDisposed = false;
        }

        internal override void Initialize(Graphics3DConfiguration config)
        {
            if (GraphicsDirect3D9.Device != null)
                throw new Graphics3DStateException("Cannot do device initialization: Device already initialized!");

            Configuration = config;

            device = new Device(new Direct3D(), 0, DeviceType.Hardware, config.Target, CreateFlags.HardwareVertexProcessing, Direct3DConverter9.ConvertToPresentParameters(config));

            //Setup device to main device
            GraphicsDirect3D9.Device = device;
        }

        internal override void Render()
        {
            device.BeginScene();

            foreach (Viewport3D vp in ViewportManager.Iterator)
            {
                //Setup viewport
                Viewport viewport = Direct3DConverter9.ConvertToViewport(vp);
                device.Viewport = viewport;

                device.Clear(ClearFlags.ZBuffer | ClearFlags.Target, vp.Background, 1.0f, 0);
                                               
            }

            device.EndScene();
            device.Present();
        }

        public override void Dispose()
        {
            if (IsDisposed)
                throw new Graphics3DStateException("Cannot dispose device: Device already disposed!");

            device.Dispose();
            device = null;

            IsDisposed = true;
        }
    }
}
