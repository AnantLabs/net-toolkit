using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using SlimDX;
using NET.Tools.Engines.Graphics3D;

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
            Graphics3DApplication.Run(win, Graphics3DSystem.InitializeSystem(config, "Direct3D9"));
        }

        private static void Graphics3DApplication_Dispose(Graphics3DDevice obj)
        {
        }

        private static void Graphics3DApplication_Initialize(Graphics3DDevice obj)
        {
            Viewport vp1 = ViewportManager.CreateViewport("main1", ViewportCreator.CreateViewport(
                0, 0, Graphics3DSystem.Configuration.ScreenConfiguration.Width, Graphics3DSystem.Configuration.ScreenConfiguration.Height / 2, Color.Blue));
            vp1.Camera.ViewInformation.Position = new Vector3(2, 2, 2);
            Viewport vp2 = ViewportManager.CreateViewport("main2", ViewportCreator.CreateViewport(
                0, Graphics3DSystem.Configuration.ScreenConfiguration.Height / 2, Graphics3DSystem.Configuration.ScreenConfiguration.Width, Graphics3DSystem.Configuration.ScreenConfiguration.Height / 2, Color.Red));
            vp2.Camera.ViewInformation.Position = new Vector3(2, 2, 0);

            Mesh mesh = MeshManager.CreateMesh("mesh1", MeshCreator.CreateBox(1, 1, 1));
            EntityManager.CreateEntity("entity1", EntityCreator.CreateObjectEntity(mesh));

            obj.RootNode.AddEntityNode("node1", "entity1");
        }
    }
}
