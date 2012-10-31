using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace NET.Tools
{
    public partial class MainWin : MainForm
    {
        public MainWin()
        {
            InitializeComponent();
        }

        public override void Initialize(SplashForm splash)
        {
            for (int i = 0; i < 100; i++)
            {
                (splash as SplashWin).Info = i + "%";
                Thread.Sleep(25);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
