using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NET.Tools.Forms
{
    internal partial class HighLightingFrame : Form
    {
        public String HighLighting_Regex
        {
            get { return txtRegex.Text; }
            set { txtRegex.Text = value; }
        }

        public Color HighLighting_Foreground
        {
            get { return pnlForeground.BackColor; }
            set { pnlForeground.BackColor = value; lblExample.ForeColor = value; }
        }

        public Color HighLighting_Background
        {
            get { return pnlBackground.BackColor; }
            set { pnlBackground.BackColor = value; lblExample.BackColor = value; }
        }

        public FontStyle HighLighting_FontStyle
        {
            get { return (FontStyle)cmbFontStyle.SelectedItem; }
            set { cmbFontStyle.SelectedItem = value; lblExample.Font = new Font(lblExample.Font, value); }
        }

        public HighLightingFrame()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            foreach(FontStyle value in Enum.GetValues(typeof(FontStyle)))
                cmbFontStyle.Items.Add(value);
            cmbFontStyle.SelectedItem = FontStyle.Regular;
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

        private void txtRegex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                new Regex(txtRegex.Text);
                errProv.SetError(txtRegex, "");
            }
            catch (ArgumentException)
            {
                errProv.SetError(txtRegex, TextManager.Dialog.Message.Error.Regex.Message);
            }
        }

        private void cmbFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExample.Font = new Font(lblExample.Font, (FontStyle)cmbFontStyle.SelectedItem);
        }

        private void pnlForeground_Click(object sender, EventArgs e)
        {
            colorDlg.Color = pnlForeground.BackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                pnlForeground.BackColor = colorDlg.Color;
                lblExample.ForeColor = colorDlg.Color;
            }
        }

        private void pnlBackground_Click(object sender, EventArgs e)
        {
            colorDlg.Color = pnlBackground.BackColor;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                pnlBackground.BackColor = colorDlg.Color;
                lblExample.BackColor = colorDlg.Color;
            }
        }
    }
}
