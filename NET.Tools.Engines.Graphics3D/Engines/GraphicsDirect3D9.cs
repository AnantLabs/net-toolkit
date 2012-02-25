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

namespace NET.Tools.Engines.Graphics3D.Engines
{
    public sealed class GraphicsDirect3D9 : Graphics3DDevice
    {
        #region Singleton

        private static GraphicsDirect3D9 instance = null;

        public static GraphicsDirect3D9 GetInstance()
        {
            if (instance == null)
            {
                instance = new GraphicsDirect3D9();
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
            if (device != null)
                throw new Graphics3DStateException("Cannot do device initialization: Device already initialized!");

            Configuration = config;

            device = new Device(new Direct3D(), 0, DeviceType.Hardware, config.Target, CreateFlags.HardwareVertexProcessing, Direct3DConverter9.Convert(config));
        }

        internal override void Render()
        {
            device.Clear(ClearFlags.ZBuffer | ClearFlags.Target, Color.Blue, 1.0f, 0);
            device.BeginScene();



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
