using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NET.Tools
{
    /// <summary>
    /// Form for all splashes
    /// </summary>
    public class SplashForm : Form
    {
        internal event EventHandler CreateAction;

        internal bool Done { get; private set; }

        public SplashForm()
            : base()
        {
            Done = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Thread thread = new Thread(() =>
            {
                if (CreateAction != null)
                    CreateAction(this, e);
                lock (this)
                {
                    Done = true;
                }
            });
            thread.Name = "Splash Initialize";
            thread.Start();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            
        }
    }
}
