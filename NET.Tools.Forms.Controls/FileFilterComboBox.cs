using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Design;

namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    [DefaultEvent("FileFilterChanged")]
    [DefaultProperty("FileFilterList")]
    public partial class FileFilterComboBox : UserControl
    {
        private List<FileFilter> filters;

        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler FileFilterChanged;

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the file filters")]
        [Editor(typeof(UIFileFilterEditor), typeof(UITypeEditor))]
        [DesignOnly(false)]
        public FileFilter[] FileFilterList {
            get { return filters.ToArray(); }
            set { filters.Clear(); filters.AddRange(value); UpdateList(); }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the file filter index to select")]
        [DefaultValue(0)]
        public int SelectedFilterIndex
        {
            get { return cmbFilter.SelectedIndex; }
            set { cmbFilter.SelectedIndex = value; }
        }

        [Browsable(false)]
        public FileFilter SelectedFilter
        {
            get
            {
                if (cmbFilter.SelectedIndex < 0)
                    return null;
                else
                    return cmbFilter.SelectedItem as FileFilter;
            }
            set
            {
                cmbFilter.SelectedItem = value;
            }
        }

        [Browsable(false)]
        public String SelectedFilterString
        {
            get
            {
                if (cmbFilter.SelectedIndex < 0)
                    return null;
                else
                    return (cmbFilter.SelectedItem as FileFilter).Filter;
            }
            set
            {
                foreach (Object item in cmbFilter.Items)
                {
                    FileFilter ff = item as FileFilter;
                    if (ff.Filter.Equals(value))
                    {
                        cmbFilter.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public FileFilterComboBox()
        {
            InitializeComponent();
            this.Height = cmbFilter.Height;

            filters = new List<FileFilter>();

            UpdateList();
        }

        private void FilterComboBox_Resize(object sender, EventArgs e)
        {
            this.Height = cmbFilter.Height;
        }

        private void UpdateList()
        {
            cmbFilter.Items.Clear();

            foreach (FileFilter ff in filters)
                cmbFilter.Items.Add(ff);

            if (cmbFilter.Items.Count > 0)
                cmbFilter.SelectedIndex = 0;
        }

        protected void DoFileFilterChanged()
        {
            if (FileFilterChanged != null)
                FileFilterChanged(this, new EventArgs());
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoFileFilterChanged();
        }
    }
}
