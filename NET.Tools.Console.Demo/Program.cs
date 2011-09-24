using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.CommandLine;
using System.Threading;
using System.Drawing;

namespace NET.Tools.Console.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CMDApplication.Run(new CMDDesktop());

            CMDWindow window = new CMDWindow();
            window.Show();

            CMDDialog dlg = new CMDDialog();
            dlg.Show();

            CMDButton btn = new CMDButton();
            btn.Text = "&Close";
            btn.Bounds = new Rectangle(0, 0, 20, 1);
            btn.Click += (s, e) => { dlg.Close(); };
            dlg.Children.Add(btn);
        }
    }
}
