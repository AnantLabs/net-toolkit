using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NET.Tools
{
    public static class SplashApplication
    {
        public static void Run(SplashForm splash, MainForm form)
        {
            splash.CreateAction += (s, e) => { form.Initialize(splash); };
            form.Load += (s, e) => { splash.Close(); };

            splash.Show();
            while (!splash.Done)
                Application.DoEvents();

            //Application.Run(form);
            form.Show();
            while (form.Created)
                Application.DoEvents();
        }
    }
}
