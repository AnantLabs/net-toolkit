using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using NET.Tools.Engines.Graphics3D.Configuration;
using NET.Tools.Engines.Graphics3D.Exceptions;
using SlimDX.Direct3D9;
using Viewport3D = NET.Tools.Engines.Graphics3D.Common.Viewport;
using DXViewport = SlimDX.Direct3D9.Viewport;
using NET.Tools.Engines.Graphics3D.Common.Managers;
using NET.Tools.Engines.Graphics3D.Engines.Converter;
using NET.Tools.Engines.Graphics3D.Common;
using SlimDX;
using NET.Tools.Engines.Graphics3D.Layer;

namespace NET.Tools.Engines.Graphics3D.Engines
{
    public sealed class GraphicsDirect3D9 : Graphics3DDevice
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

        public static Device Device { get; protected set; }

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

            GraphicsDirect3D9.Device = new Device(new Direct3D(), 0, DeviceType.Hardware, config.Target, CreateFlags.HardwareVertexProcessing, Direct3DConverter9.ConvertToPresentParameters(config));
            GraphicsDirect3D9.Implementors = LayerImplementorFactory.Direct3D9Implementor;
        }

        internal override void Render()
        {
            GraphicsDirect3D9.Device.BeginScene();

            foreach (Viewport3D vp in ViewportManager.Iterator)
            {
                //Setup viewport
                DXViewport viewport = Direct3DConverter9.ConvertToViewport(vp);
                GraphicsDirect3D9.Device.Viewport = viewport;

                GraphicsDirect3D9.Device.Clear(ClearFlags.ZBuffer | ClearFlags.Target, vp.Background, 1.0f, 0);

                //Setup camera first
                vp.Camera.SetupCamera();

                //Render scene
                RootNode.Render();
                                               
            }

            GraphicsDirect3D9.Device.EndScene();
            GraphicsDirect3D9.Device.Present();
        }

        public override void Dispose()
        {
            if (IsDisposed)
                throw new Graphics3DStateException("Cannot dispose device: Device already disposed!");

            GraphicsDirect3D9.Device.Dispose();
            GraphicsDirect3D9.Device = null;

            IsDisposed = true;
        }
    }
}
