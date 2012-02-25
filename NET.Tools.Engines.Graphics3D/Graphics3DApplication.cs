using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NET.Tools.Engines.Graphics3D.Configuration;
using NET.Tools.Engines.Graphics3D.Engines;
using NET.Tools.Engines.Graphics3D.Exceptions;

namespace NET.Tools.Engines.Graphics3D
{
    public static class Graphics3DApplication
    {
        public static void Run(Form form, Graphics3DConfiguration config, Graphics3DDevice graphics3d)
        {
            graphics3d.Initialize(config);
            form.Show();

            while (form.Visible)
            {
                graphics3d.Render();
                Application.DoEvents();
            }

            graphics3d.Dispose();
            form.Dispose();
        }
    }
}
