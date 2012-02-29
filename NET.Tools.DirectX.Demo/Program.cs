using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NET.Tools.Engines.Graphics3D.Configuration;
using NET.Tools.Engines.Graphics3D;
using NET.Tools.Engines.Graphics3D.Engines;
using NET.Tools.Engines.Graphics3D.Common.Managers;
using NET.Tools.Engines.Graphics3D.Common;
using System.Drawing;
using NET.Tools.Engines.Graphics3D.Common.Tools;
using SlimDX;

namespace NET.Tools.DirectX.Demo
{
    static class Program
    {
        private const int G3D_WIDTH = 1920;
        private const int G3D_HEIGHT = 1080;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form win = new Form();
            win.KeyDown += ((sender, e) => { win.Close(); });
            win.Width = G3D_WIDTH;
            win.Height = G3D_HEIGHT;
            win.StartPosition = FormStartPosition.CenterScreen;
            win.Text = "Graphics 3D - Demo";

            Graphics3DConfiguration config = new Graphics3DConfiguration();
            config.Target = win.Handle;
            config.ScreenConfiguration.ColorMode = ColorMode.Bit32;
            config.ScreenConfiguration.FullScreen = false;
            config.ScreenConfiguration.Height = G3D_HEIGHT;
            config.ScreenConfiguration.Width = G3D_WIDTH;

            Graphics3DApplication.Initialize += new Action<Graphics3DDevice>(Graphics3DApplication_Initialize);
            Graphics3DApplication.Dispose += new Action<Graphics3DDevice>(Graphics3DApplication_Dispose);
            Graphics3DApplication.Run(win, config, GraphicsDirect3D9.GetInstance());
        }

        private static void Graphics3DApplication_Dispose(Graphics3DDevice obj)
        {
        }

        private static void Graphics3DApplication_Initialize(Graphics3DDevice obj)
        {
            Viewport vp1 = new Viewport(0, 0, Graphics3DDevice.Configuration.ScreenConfiguration.Width, Graphics3DDevice.Configuration.ScreenConfiguration.Height / 2, Color.Blue);
            vp1.Camera.ViewInformation.Position = new Vector3(2, 2, 2);
            Viewport vp2 = new Viewport(0, Graphics3DDevice.Configuration.ScreenConfiguration.Height / 2, Graphics3DDevice.Configuration.ScreenConfiguration.Width, Graphics3DDevice.Configuration.ScreenConfiguration.Height / 2, Color.Red);
            vp2.Camera.ViewInformation.Position = new Vector3(2, 2, 0);

            ViewportManager.SetViewport("main1", vp1);
            ViewportManager.SetViewport("main2", vp2);

            MeshManager.SetMesh("mesh1", MeshCreator.CreateBox(1, 1, 1));
            EntityManager.SetEntity("entity1", EntityCreator.CreateObjectEntity("mesh1"));

            obj.RootNode.AddEntityNode("node1", "entity1");
        }
    }
}
