/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using NET.Tools.Engines.Graphics3D.Common;
using NET.Tools.Engines.Graphics3D.Common.Managers;
using NET.Tools.Engines.Graphics3D.Converter;
using NET.Tools.Engines.Graphics3D.Exceptions;
using OpenTK.Graphics;
using System.Drawing;

namespace NET.Tools.Engines.Graphics3D.Engines
{
    public sealed class GraphicsOpenGL : Graphics3DDevice<GameWindow>
    {
        #region Singleton

        private static GraphicsOpenGL instance = null;

        public static GraphicsOpenGL GetInstance()
        {
            if (GraphicsOpenGL.CurrentDeviceType.HasValue &&
                GraphicsOpenGL.CurrentDeviceType.Value != DeviceType.OpenGL)
                throw new Graphics3DException("An other device is already initialized: " + GraphicsOpenGL.CurrentDeviceType.Value.ToString()); 

            if (instance == null)
            {
                instance = new GraphicsOpenGL();
                GraphicsOpenGL.CurrentDeviceType = DeviceType.OpenGL;
            }

            return instance;
        }

        #endregion

        private GameWindow device = null;

        public override NET.Tools.Engines.Graphics3D.Configuration.Graphics3DConfiguration Configuration
        {
            get;
            protected set;
        }

        internal override void Initialize(NET.Tools.Engines.Graphics3D.Configuration.Graphics3DConfiguration config)
        {
            if (GraphicsOpenGL.Device != null)
                throw new Graphics3DStateException("Cannot do device initialization: Device already initialized!");

            device = new GameWindow(
                config.ScreenConfiguration.Width,
                config.ScreenConfiguration.Height,
                new GraphicsMode(
                    OpenGLConverter.ConvertFromColorMode(config.ScreenConfiguration.ColorMode),
                    16),
                "Open GL", 0, DisplayDevice.Default, 3, 1, GraphicsContextFlags.Debug);
            device.Run();

            Configuration = config;
  
            //Setup device to main device
            GraphicsOpenGL.Device = device;
        }

        internal override void Render()
        {
            foreach (Viewport vp in ViewportManager.Iterator)
            {
                GL.Viewport(OpenGLConverter.ConvertFromViewport(vp));
                GL.ClearColor(vp.Background);



                GL.Flush();
                device.SwapBuffers();
            }
        }

        public override void Dispose()
        {
            if (IsDisposed)
                throw new Graphics3DStateException("Cannot dispose device: Device already disposed!");

            device.Dispose();
            IsDisposed = true;
        }

        public override bool IsDisposed
        {
            get;
            protected set;
        }
    }
}*/
