using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using SlimDX.Direct3D9;
using Viewport3D = NET.Tools.Engines.Graphics3D.Viewport;
using DXViewport = SlimDX.Direct3D9.Viewport;
using SlimDX;

namespace NET.Tools.Engines.Graphics3D
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

        public static Device Device { get; private set; }

        public override bool IsDisposed
        {
            get;
            protected set;
        }

        private GraphicsDirect3D9()
        {
            IsDisposed = false;
        }

        protected override void OnInitialization(Graphics3DConfiguration config)
        {
            if (GraphicsDirect3D9.Device != null)
                throw new Graphics3DStateException("Cannot do device initialization: Device already initialized!");

            GraphicsDirect3D9.Device = new Device(new Direct3D(), 0, DeviceType.Hardware, config.Target, CreateFlags.HardwareVertexProcessing, Direct3DConverter9.ConvertToPresentParameters(config));
        }

        public override void Dispose()
        {
            if (IsDisposed)
                throw new Graphics3DStateException("Cannot dispose device: Device already disposed!");

            GraphicsDirect3D9.Device.Dispose();
            GraphicsDirect3D9.Device = null;

            IsDisposed = true;
        }

        protected override void OnStartRendering()
        {
            GraphicsDirect3D9.Device.BeginScene();
        }

        protected override void OnEndRendering()
        {
            GraphicsDirect3D9.Device.EndScene();
            GraphicsDirect3D9.Device.Present();
        }

        protected override void OnClearScene(Viewport3D vp)
        {
            GraphicsDirect3D9.Device.Clear(ClearFlags.ZBuffer | ClearFlags.Target, vp.Background, 1.0f, 0);
        }
    }
}
