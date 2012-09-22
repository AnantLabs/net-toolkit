using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Forms
{
    internal partial class FileFilterFrame : Form
    {
        public String FileFilterName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public String FileFilterFilter
        {
            get { return txtFilter.Text; }
            set { txtFilter.Text = value; }
        }

        public String FileFilterDefaultExt
        {
            get { return txtDefaultExt.Text; }
            set { txtDefaultExt.Text = value; }
        }

        public FileFilterFrame()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
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
