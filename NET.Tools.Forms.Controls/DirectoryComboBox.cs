using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using System.Drawing.Design;


namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    [DefaultEvent("SelectedDirectory")]
    [DefaultProperty("SelectedDirectory")]
    public partial class DirectoryComboBox : UserControl
    {
        private DirectoryInfo directory;

        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler DirectoryChanged;

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the selected directory")]
        [Editor(typeof(UIDirectoryInfoEditor), typeof(UITypeEditor))]
        public DirectoryInfo SelectedDirectory
        {
            get
            {
                return directory;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("The selected directory cannot be null!");

                directory = value;
                UpdateList();
            }
        }

        public DirectoryComboBox()
        {
            InitializeComponent();
            this.Height = cmbDirectory.Height;

            SelectedDirectory = new DirectoryInfo("C:\\");
        }

        private void UpdateList()
        {
            cmbDirectory.Items.Clear();
            imgList.Images.Clear();

            DirectoryInfo parent = directory.Parent;

            cmbDirectory.Items.Add(directory);
            imgList.Images.Add(Properties.Resources.Folder);
            while (parent != null)
            {
                cmbDirectory.Items.Insert(0, parent);
                imgList.Images.Add(Properties.Resources.Folder);

                parent = parent.Parent;
            }

            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.RootDirectory.FullName[0] != directory.FullName[0])
                    cmbDirectory.Items.Insert(0, di.RootDirectory);
            }

            cmbDirectory.SelectedIndexChanged -= new EventHandler(cmbDirectory_SelectedIndexChanged);
            cmbDirectory.SelectedIndex = cmbDirectory.Items.Count - 1;
            cmbDirectory.SelectedIndexChanged += new EventHandler(cmbDirectory_SelectedIndexChanged);
        }

        private void DirectoryComboBox_Resize(object sender, EventArgs e)
        {
            this.Height = cmbDirectory.Height;
        }

        private void cmbDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDirectory.SelectedIndex < 0)
                return;

            SelectedDirectory = cmbDirectory.SelectedItem as DirectoryInfo;

            DoDirectoryChanged();
        }

        protected void DoDirectoryChanged()
        {
            if (DirectoryChanged != null)
                DirectoryChanged(this, new EventArgs());
        }
    }
}
