using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NET.Tools.Engines.Graphics3D.Configuration;

namespace NET.Tools.Engines.Graphics3D.Engines
{
    public abstract class Graphics3DDevice : IDisposable
    {
        /// <summary>
        /// Returns the initial configuration
        /// </summary>
        public abstract Graphics3DConfiguration Configuration { get; protected set; }

        internal abstract void Initialize(Graphics3DConfiguration config);
        internal abstract void Render();

        #region IDisposable Member

        public abstract void Dispose();
        public abstract bool IsDisposed { get; protected set; }

        #endregion
    }
}
