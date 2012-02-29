using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NET.Tools.Engines.Graphics3D.Configuration;
using NET.Tools.Engines.Graphics3D.Layer;
using NET.Tools.Engines.Graphics3D.Common;

namespace NET.Tools.Engines.Graphics3D.Engines
{
    public enum Graphics3DDeviceType
    {
        Direct3D9,
        Direct3D11,
        OpenGL
    }

    public abstract class Graphics3DDevice : IDisposable
    {
        public static Graphics3DDeviceType? CurrentDeviceType { get; protected set; }
        internal static ILayerImplementor Implementors { get; set; }
        /// <summary>
        /// Returns the initial configuration
        /// </summary>
        public static Graphics3DConfiguration Configuration { get; protected set; }

        static Graphics3DDevice()
        {
            CurrentDeviceType = null;
        }

        public RootNode RootNode { get; private set; }

        protected Graphics3DDevice()
        {
            RootNode = new RootNode();
        }

        internal abstract void Initialize(Graphics3DConfiguration config);
        internal abstract void Render();

        #region IDisposable Member

        public abstract void Dispose();
        public abstract bool IsDisposed { get; protected set; }

        #endregion
    }
}
