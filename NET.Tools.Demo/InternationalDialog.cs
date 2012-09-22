using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using NET.Tools;

namespace NET.Tools
{
    public partial class InternationalDialog : Form
    {
        public InternationalDialog()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            this.UpdateUICulture(new CultureInfo("en"));
        }

        private void btnGerman_Click(object sender, EventArgs e)
        {
            this.UpdateUICulture(new CultureInfo("de-DE"));
        }
    }
}
