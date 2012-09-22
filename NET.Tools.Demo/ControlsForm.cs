using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NET.Tools.Properties;
using NET.Tools.OS;




namespace NET.Tools
{
    public partial class ControlsForm : Form
    {
        private ulong counter = 0;
        private TaskBarManager manager;

        public ControlsForm()
        {
            InitializeComponent();
            manager = new TaskBarManager(this);

            //manager.ProgressMaximum = 100;
            //manager.ProgressStyle = TaskbarProgressBarStyle.Indeterminate;
            TaskbarTimer.Enabled = true;
            TaskbarTimer.Start();

            ThumbnailButton btn = manager.AddThumbnailButton(
                Resources.File001, "Bla Blub");
            btn.Click += (s, e) => { Console.WriteLine("CLICKED!"); };
            ThumbnailTab tab = manager.AddTab(this.fileSystemManager1);
            ThumbnailTab tab2 = manager.AddTab(this);
        }

        private void TaskbarTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter > 100)
                counter = 0;

            //manager.ProgressValue = counter;
        }
    }
}
