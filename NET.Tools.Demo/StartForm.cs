using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            new ControlsForm().ShowDialog();
        }

        private void btnDialogs_Click(object sender, EventArgs e)
        {
            new DialogForm().ShowDialog();
        }

        private void btnDrawing_Click(object sender, EventArgs e)
        {
            new DrawingForm().ShowDialog();
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            new InternationalDialog().ShowDialog();
        }
    }
}
