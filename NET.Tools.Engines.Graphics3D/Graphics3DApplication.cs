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
        public static event Action<Graphics3DDevice<Object>> Initialize;
        public static event Action<Graphics3DDevice<Object>> PreRender;
        public static event Action<Graphics3DDevice<Object>> PostRender;
        public static event Action<Graphics3DDevice<Object>> Dispose;

        public static void Run(Form form, Graphics3DConfiguration config, Graphics3DDevice<Object> graphics3d)
        {
            graphics3d.Initialize(config);
            form.Show();
            if (Initialize != null) Initialize(graphics3d);

            while (form.Visible)
            {
                if (PreRender != null) PreRender(graphics3d);
                graphics3d.Render();
                if (PostRender != null) PostRender(graphics3d);
                Application.DoEvents();
            }

            if (Dispose != null) Dispose(graphics3d);
            graphics3d.Dispose();
            form.Dispose();
        }

        public static void Run(Graphics3DConfiguration config, Graphics3DDevice<Object> graphics3d)
        {
            Run(new Form(), config, graphics3d);
        }
    }
}
