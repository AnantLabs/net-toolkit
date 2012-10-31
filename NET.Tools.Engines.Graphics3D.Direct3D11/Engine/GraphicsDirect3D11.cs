using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D;
using SlimDX.Direct3D11;
using SlimDX.DXGI;
using Device11 = SlimDX.Direct3D11.Device;
using Resource11 = SlimDX.Direct3D11.Resource;
using SlimDX;
using Viewport3D = NET.Tools.Engines.Graphics3D.Viewport;
using DXViewport = SlimDX.Direct3D11.Viewport;

namespace NET.Tools.Engines.Graphics3D.Direct3D11
{
    public sealed class GraphicsDirect3D11 : Graphics3DDevice
    {
        #region Singleton

        private static GraphicsDirect3D11 instance = null;

        public static GraphicsDirect3D11 GetInstance()
        {
            if (instance == null)
            {
                instance = new GraphicsDirect3D11();
            }

            return instance;
        }

        #endregion

        public static Device11 Device { get; private set; }

        private SwapChain swapChain = null;
        private RenderTargetView renderTarget = null;

        private GraphicsDirect3D11()
        {
        }

        protected override void OnInitialization(Graphics3DConfiguration config)
        {
            if (GraphicsDirect3D11.Device != null)
                throw new Graphics3DStateException("Cannot do device initialization: Device already initialized!");

            Device11 device = null;
            Device11.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, Direct3DConverter11.ConvertToSwapChainDescription(config), out device, out swapChain);
            //Setup device to main device
            GraphicsDirect3D11.Device = device;

            SetupRenderTarget();
        }

        private void SetupRenderTarget()
        {
            //Render this texture (from swap chain target) into the render target
            using (Texture2D texture = Resource11.FromSwapChain<Texture2D>(swapChain, 0))
            {
                renderTarget = new RenderTargetView(GraphicsDirect3D11.Device, texture);
            }
            GraphicsDirect3D11.Device.ImmediateContext.OutputMerger.SetTargets(renderTarget);
        }

        public override void Dispose()
        {
            if (IsDisposed)
                throw new Graphics3DStateException("Cannot dispose device: Device already disposed!");

            renderTarget.Dispose();
            //swapChain.Dispose(); //TODO
            GraphicsDirect3D11.Device.Dispose();
            GraphicsDirect3D11.Device = null;

            IsDisposed = true;
        }

        public override bool IsDisposed
        {
            get;
            protected set;
        }

        protected override void OnStartRendering()
        {
            //Empty
        }

        protected override void OnEndRendering()
        {
            swapChain.Present(0, PresentFlags.None);
        }

        protected override void OnClearScene(Viewport3D vp)
        {
            GraphicsDirect3D11.Device.ImmediateContext.ClearRenderTargetView(renderTarget, new Color4(vp.Background));
        }
    }
}
