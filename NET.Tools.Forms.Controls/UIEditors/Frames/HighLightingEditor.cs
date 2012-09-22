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
    internal partial class HighLightingEditor : Form
    {
        public HighLightingRecord[] Records
        {
            get
            {
                List<HighLightingRecord> res = new List<HighLightingRecord>();
                foreach (ListViewItem lvi in lvList.Items)
                    res.Add(lvi.Tag as HighLightingRecord);
                return res.ToArray();
            }
            set
            {
                foreach (HighLightingRecord rec in value)
                {
                    AddHighLighting(rec);
                }
            }
        }

        public HighLightingEditor()
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

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = lvList.SelectedItems.Count > 0;
            btnRemove.Enabled = lvList.SelectedItems.Count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HighLightingFrame dlg = new HighLightingFrame();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AddHighLighting(new HighLightingRecord(
                    new Regex(dlg.HighLighting_Regex), dlg.HighLighting_Foreground,
                    dlg.HighLighting_Background, dlg.HighLighting_FontStyle));
            }
        }

        private void AddHighLighting(HighLightingRecord record)
        {
            ListViewItem lvi = new ListViewItem(record.RegularExpression.ToString());
            lvi.Tag = record;
            lvi.UseItemStyleForSubItems = false;
            ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add("Example");
            lvsi.BackColor = record.BackColor;
            lvsi.ForeColor = record.ForeColor;
            lvsi.Font = new Font(lvsi.Font, record.FontStyle);

            lvList.Items.Add(lvi);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            HighLightingFrame dlg = new HighLightingFrame();
            HighLightingRecord record = 
                lvList.SelectedItems[0].Tag as HighLightingRecord;

            dlg.HighLighting_Background = record.BackColor;
            dlg.HighLighting_FontStyle = record.FontStyle;
            dlg.HighLighting_Foreground = record.ForeColor;
            dlg.HighLighting_Regex = record.RegularExpression.ToString();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lvList.RemoveSelected();
                AddHighLighting(new HighLightingRecord(
                    new Regex(dlg.HighLighting_Regex), dlg.HighLighting_Foreground,
                    dlg.HighLighting_Background, dlg.HighLighting_FontStyle));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lvList.RemoveSelected();
        }
    }
}
