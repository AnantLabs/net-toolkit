using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent the base for all runners
    /// </summary>
    public abstract class Runner : IRunner
    {
        /// <summary>
        /// The target ptr for rendering
        /// </summary>
        protected IntPtr targetPtr;

        public Runner(IntPtr targetPtr, IConfigurator config)
        {
            this.targetPtr = targetPtr;
            this.Graphics = new Graphics3D(targetPtr, config);
        }

        #region IRunner Member

        public abstract void Run();

        public Graphics3D Graphics { get; private set; }

        #endregion

        #region IDisposable Member

        /// <summary>
        /// Dispose graphics object
        /// </summary>
        public virtual void Dispose()
        {
            Graphics.Dispose();
        }

        #endregion
    }

    /// @}
}
