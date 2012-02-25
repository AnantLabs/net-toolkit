using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NET.Tools.Engines.Graphics3D.Configuration;
using NET.Tools.Engines.Graphics3D;
using NET.Tools.Engines.Graphics3D.Engines;

namespace NET.Tools.DirectX.Demo
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainWindow win = new MainWindow();

            Graphics3DConfiguration config = new Graphics3DConfiguration();
            config.Target = win.Handle;
            config.ScreenConfiguration.ColorMode = ColorMode.Bit32;
            config.ScreenConfiguration.FullScreen = true;
            config.ScreenConfiguration.Height = 1080;
            config.ScreenConfiguration.Width = 1920;

            Graphics3DApplication.Run(win, config, GraphicsDirect3D11.GetInstance());
        }
    }
}
