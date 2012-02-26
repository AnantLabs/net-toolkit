using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D.Configuration;
using SlimDX.Direct3D11;
using SlimDX.DXGI;
using Device11 = SlimDX.Direct3D11.Device;
using Resource11 = SlimDX.Direct3D11.Resource;
using NET.Tools.Engines.Graphics3D.Converter;
using SlimDX;
using NET.Tools.Engines.Graphics3D.Exceptions;
using Viewport3D = NET.Tools.Engines.Graphics3D.Common.Viewport;
using NET.Tools.Engines.Graphics3D.Common.Managers;

namespace NET.Tools.Engines.Graphics3D.Engines
{
    public sealed class GraphicsDirect3D11 : Graphics3DDevice<Device11>
    {
        #region Singleton

        private static GraphicsDirect3D11 instance = null;

        public static GraphicsDirect3D11 GetInstance()
        {
            if (GraphicsDirect3D11.CurrentDeviceType.HasValue &&
                GraphicsDirect3D11.CurrentDeviceType.Value != Graphics3DDeviceType.Direct3D11)
                throw new Graphics3DException("An other device is already initialized: " + GraphicsDirect3D11.CurrentDeviceType.Value.ToString());

            if (instance == null)
            {
                instance = new GraphicsDirect3D11();
                GraphicsDirect3D11.CurrentDeviceType = Graphics3DDeviceType.Direct3D11;
            }

            return instance;
        }

        #endregion

        private Device11 device = null;
        private SwapChain swapChain = null;
        private RenderTargetView renderTarget = null;

        public override Graphics3DConfiguration Configuration
        {
            get;
            protected set;
        }

        private GraphicsDirect3D11()
        {
        }

        internal override void Initialize(Graphics3DConfiguration config)
        {
            if (GraphicsDirect3D11.Device != null)
                throw new Graphics3DStateException("Cannot do device initialization: Device already initialized!");

            Configuration = config;

            Device11.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, Direct3DConverter11.ConvertToSwapChainDescription(config), out device, out swapChain);
            SetupRenderTarget();
            //SetupViewport();  
          
            //Setup device to main device
            GraphicsDirect3D11.Device = device;
        }

        private void SetupRenderTarget()
        {
            //Render this texture (from swap chain target) into the render target
            using (Texture2D texture = Resource11.FromSwapChain<Texture2D>(swapChain, 0))
            {
                renderTarget = new RenderTargetView(device, texture);
            }
            device.ImmediateContext.OutputMerger.SetTargets(renderTarget);
        }

        private void SetupViewport()
        {
            /// ???
            Viewport viewport = new Viewport(0, 0, Configuration.ScreenConfiguration.Width, Configuration.ScreenConfiguration.Height);
            device.ImmediateContext.Rasterizer.SetViewports(viewport);
        }

        internal override void Render()
        {
            foreach (Viewport3D vp in ViewportManager.Iterator)
            {
                device.ImmediateContext.Rasterizer.SetViewports(Direct3DConverter11.ConvertFromViewport(vp));

                device.ImmediateContext.ClearRenderTargetView(renderTarget, new Color4(vp.Background));
                swapChain.Present(0, PresentFlags.None);   
            }
        }

        public override void Dispose()
        {
            if (IsDisposed)
                throw new Graphics3DStateException("Cannot dispose device: Device already disposed!");

            renderTarget.Dispose();
            //swapChain.Dispose(); //TODO
            device.Dispose();
            device = null;

            IsDisposed = true;
        }

        public override bool IsDisposed
        {
            get;
            protected set;
        }
    }
}
