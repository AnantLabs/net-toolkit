using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NET.Tools.Forms
{
    internal partial class DriveInfoSelector : Form
    {
        public DriveInfo SelectedDriveInfo { get { return lblDrives.SelectedItem as DriveInfo; } }

        public DriveInfoSelector()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            foreach (DriveInfo di in DriveInfo.GetDrives())
                lblDrives.Items.Add(di);
        }

        private void lblDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lblDrives.SelectedIndex >= 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
