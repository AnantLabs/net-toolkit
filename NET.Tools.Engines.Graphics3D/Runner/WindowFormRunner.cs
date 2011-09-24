using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a window form runner
    /// 
    /// With this class you can run the rendering on window form controls
    /// </summary>
    public sealed class WindowFormRunner : Runner
    {
        /// <summary>
        /// Gets the target window for rendering
        /// </summary>
        public Form TargetForm { get { return (Form)Control.FromHandle(targetPtr); } }

        public WindowFormRunner(Form targetForm, IConfigurator config)
            : base(targetForm.Handle, config)
        {            
        }

        public override void Run()
        {
            if (!TargetForm.Visible)
                TargetForm.Show();

            while (TargetForm.Created)
            {
                Graphics.Render();
                Application.DoEvents();
            }
        }
    }

    /// @}
}
