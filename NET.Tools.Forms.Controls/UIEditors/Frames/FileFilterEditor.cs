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
    internal partial class FileFilterEditor : Form
    {
        public List<FileFilter> FileFilterList
        {
            get
            {
                List<FileFilter> res = new List<FileFilter>();
                foreach (ListViewItem lvi in lvFilters.Items)
                    res.Add(lvi.Tag as FileFilter);

                return res;
            }
            set
            {
                lvFilters.Items.Clear();
                foreach (FileFilter ff in value)
                {
                    AddFileFilter(ff);
                }
            }
        }

        public FileFilterEditor()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void AddFileFilter(FileFilter ff)
        {
            ListViewItem lvi = new ListViewItem(ff.Name);
            lvi.SubItems.Add(ff.Filter);
            lvi.SubItems.Add(ff.DefaultExt);
            lvi.Tag = ff;

            lvFilters.Items.Add(lvi);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = lvFilters.SelectedItems.Count > 0;
            btnRemove.Enabled = lvFilters.SelectedItems.Count > 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lvFilters.RemoveSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FileFilterFrame dlg = new FileFilterFrame();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AddFileFilter(new FileFilter(
                    dlg.FileFilterName, dlg.FileFilterFilter, dlg.FileFilterDefaultExt));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FileFilterFrame dlg = new FileFilterFrame();
            ListViewItem lvi = lvFilters.SelectedItems[0];
            FileFilter ff = lvi.Tag as FileFilter;

            dlg.FileFilterDefaultExt = ff.DefaultExt;
            dlg.FileFilterFilter = ff.Filter;
            dlg.FileFilterName = ff.Name;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lvFilters.Items.Remove(lvi);
                AddFileFilter(new FileFilter(
                    dlg.FileFilterName, dlg.FileFilterFilter, dlg.FileFilterDefaultExt));
            }
        }
    }
}
