using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools
{
    /// <summary>
    /// Represent a Form Temlate for culture forms to rebuild it if the language is changed
    /// </summary>
    public class CultureForm : Form
    {
        /// <summary>
        /// Default initialize component method for designer
        /// </summary>
        protected virtual void InitializeComponent() { }

        /// <summary>
        /// Change the UI to rebuild it for example in an other language
        /// </summary>
        public void ChangeUI()
        {
            this.Controls.Clear();
            InitializeComponent();
        }
    }
}
