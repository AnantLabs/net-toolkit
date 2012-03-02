using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Engines.Graphics3D
{
    public abstract class Graphics3DDevice : IDisposable
    {
        public RootNode RootNode { get; private set; }

        public Graphics3DDevice()
        {
            RootNode = new RootNode();
            IsDisposed = false;
        }

        internal void Initialize(Graphics3DConfiguration config)
        {
            OnInitialization(config);
        }

        internal void Render()
        {
            OnStartRendering();

            foreach (Viewport vp in ViewportManager.Iterator)
            {
                Graphics3DSystem.Implementors.ViewportImplementor.SetViewport(vp);

                OnClearScene(vp);

                //Setup camera first
                vp.Camera.SetupCamera();

                //Render scene
                RootNode.Render();

            }

            OnEndRendering();
        }

        public abstract bool IsDisposed { get; protected set; }
        public abstract void Dispose();

        protected abstract void OnInitialization(Graphics3DConfiguration config);
        protected abstract void OnStartRendering();
        protected abstract void OnEndRendering();
        protected abstract void OnClearScene(Viewport vp);
    }
}
