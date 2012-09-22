using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Engines.Graphics3D
{
    public static class Graphics3DApplication
    {
        public static event Action<Graphics3DDevice> Initialize;
        public static event Action<Graphics3DDevice> PreRender;
        public static event Action<Graphics3DDevice> PostRender;
        public static event Action<Graphics3DDevice> Dispose;

        public static void Run(Form form, Graphics3DDevice graphics3d)
        {
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

        public static void Run(Form form, Graphics3DConfiguration config, String systemName)
        {
            Run(form, Graphics3DSystem.InitializeSystem(config, systemName));
        }

        public static void Run(Graphics3DConfiguration config, String systemName)
        {
            Run(new Form(), config, systemName);
        }

        public static void Run(Graphics3DDevice graphics3d)
        {
            Run(new Form(), graphics3d);
        }
    }
}
