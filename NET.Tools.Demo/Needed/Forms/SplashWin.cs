using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using NET.Tools.Properties;



namespace NET.Tools
{
    public partial class SplashWin : SplashForm
    {
        private const int IMAGES = 12;

        private List<Bitmap> bmpList = new List<Bitmap>();
        private int counter = 0;
        private Thread thread;

        public String Info { get; set; }

        public SplashWin()
        {
            InitializeComponent();
            for (int i = 1; i <= IMAGES; i++)
            {
                bmpList.Add((Bitmap)Resources.ResourceManager.GetObject("loading51_frame_" +
                    i.ToString().PadLeft(4, '0')));
            }

            thread = new Thread(thread_Tick);
            thread.Priority = ThreadPriority.Lowest;
        }

        private void thread_Tick()
        {
            while (thread.IsAlive)
            {
                this.Invoke(new Action(() =>
                {
                    pbImage.Image = bmpList[counter];
                    counter++;
                    if (counter >= IMAGES)
                        counter = 0;

                    Refresh();
                    Thread.Sleep(100);
                }));
            }
        }

        private void SplashWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }

        private void SplashWin_Shown(object sender, EventArgs e)
        {
            thread.Start();
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(Info, Font, ForeColor.ToSolidBrush(),
                e.ClipRectangle, ContentAlignment.MiddleCenter);
        }
    }
}
