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


using System.Diagnostics;
using System.Collections.Specialized;
using System.Threading;
using NET.Tools.Forms.Properties;

namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    //[ToolboxBitmap(@"Resources\\Toolbox\\Folder.png")]
    [DefaultEvent("DirectoryChanged")]
    [DefaultProperty("Directory")]
    public partial class FileSystemManager : UserControl
    {
        private String filter;
        private DirectoryInfo directory;
        private DirectoryComboBox linkedDirectoryBox = null;
        private FileFilterComboBox linkedFileFilterBox = null;
        private DirectoryTree linkedDirectoryTree = null;

        #region Events

        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler FilterChanged;
        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler DirectoryChanged;
        [Browsable(true)]
        [Category("Action")]
        public new event EventHandler DoubleClick;
        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler SelectedObjectChanged;

        #endregion

        #region Properties

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the filter for the file list")]
        [DefaultValue("*.*")]
        public String Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                UpdateList();
                DoFilterChanged();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the directory of files to list")]
        [Editor(typeof(UIDirectoryInfoEditor), typeof(UITypeEditor))]
        public DirectoryInfo Directory
        {
            get { return directory; }
            set
            {
                DirectoryInfo old = directory;

                try
                {
                    directory = value;
                    UpdateList();
                    backToolStripMenuItem.Enabled = directory.Parent != null;
                    DoDirectoryChanged();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Directory = old;
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that you can select more than on file in list")]
        [DefaultValue(true)]
        public bool MultiSelect
        {
            get { return lvFiles.MultiSelect; }
            set { lvFiles.MultiSelect = value; }
        }

        [Browsable(true)]
        [Category("WindowStyle")]
        [Description("Sets the view of the list")]
        [DefaultValue(View.LargeIcon)]
        public View View
        {
            get { return lvFiles.View; }
            set { lvFiles.View = value; UpdateViewMenu(); }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the groups are visible or not")]
        [DefaultValue(true)]
        public bool ShowGroups
        {
            get { return lvFiles.ShowGroups; }
            set { lvFiles.ShowGroups = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the selection is visible or not if the control is inactive")]
        [DefaultValue(false)]
        public bool HideSelection
        {
            get { return lvFiles.HideSelection; }
            set { lvFiles.HideSelection = value; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the action (doubleclick) is handled automaticly")]
        [DefaultValue(true)]
        public bool AutoFolderActionHandle { get; set; }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the action (doubleclick) on a file is handled automaticly (run it)")]
        [DefaultValue(true)]
        public bool AutoFileActionHandle { get; set; }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that a contextmenu for all objects (folders and files) is used")]
        [DefaultValue(true)]
        public bool HasObjectContextMenu { get; set; }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that a contextmenu in free room (no object selected) is used")]
        [DefaultValue(true)]
        public bool HasPlaceContextMenu { get; set; }

        [Browsable(false)]
        public List<DirectoryInfo> SelectedDirectories
        {
            get 
            {
                List<DirectoryInfo> res = new List<DirectoryInfo>();

                foreach (ListViewItem lvi in lvFiles.SelectedItems)
                    if (lvi.Tag is DirectoryInfo)
                        res.Add(lvi.Tag as DirectoryInfo);

                return res;
            }
        }

        [Browsable(false)]
        public List<FileInfo> SelectedFiles
        {
            get
            {
                List<FileInfo> res = new List<FileInfo>();

                foreach (ListViewItem lvi in lvFiles.SelectedItems)
                    if (lvi.Tag is FileInfo)
                        res.Add(lvi.Tag as FileInfo);

                return res;
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the linked DirectoryComboBox")]
        public DirectoryComboBox LinkedDirectoryBox
        {
            get { return linkedDirectoryBox; }
            set
            {
                if (linkedDirectoryBox != null)
                {
                    this.DirectoryChanged -= new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryBox);
                    linkedDirectoryBox.DirectoryChanged -= new EventHandler(linkedDirectoryBox_DirectoryChanged);
                }

                linkedDirectoryBox = value;

                this.DirectoryChanged += new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryBox);
                linkedDirectoryBox.DirectoryChanged += new EventHandler(linkedDirectoryBox_DirectoryChanged);
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the linked FileFilterBox")]
        public FileFilterComboBox LinkedFileFilterBox
        {
            get { return linkedFileFilterBox; }
            set
            {
                if (linkedFileFilterBox != null)
                {
                    linkedFileFilterBox.FileFilterChanged -= new EventHandler(linkedFileFilterBox_FileFilterChanged);
                }

                linkedFileFilterBox = value;

                linkedFileFilterBox.FileFilterChanged += new EventHandler(linkedFileFilterBox_FileFilterChanged);
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the linked DirectoryTree")]
        public DirectoryTree LinkedDirectoryTree
        {
            get { return linkedDirectoryTree; }
            set
            {
                if (linkedDirectoryTree != null)
                {
                    linkedDirectoryTree.DirectoryChanged -= new EventHandler(linkedDirectoryTree_DirectoryChanged);
                    this.DirectoryChanged -= new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryTree);
                }

                linkedDirectoryTree = value;

                linkedDirectoryTree.DirectoryChanged += new EventHandler(linkedDirectoryTree_DirectoryChanged);
                this.DirectoryChanged += new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryTree);
            }
        }

        #endregion

        public FileSystemManager()
        {
            InitializeComponent();
            filter = "*.*";
            directory = new DirectoryInfo("C:\\");

            AutoFileActionHandle = true;
            AutoFolderActionHandle = true;
            HasObjectContextMenu = true;
            HasPlaceContextMenu = true;

            UpdateList();
        }

        private void UpdateViewMenu()
        {
            detailsToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            listToolStripMenuItem.Checked = false;
            smallToolStripMenuItem.Checked = false;
            switch (lvFiles.View)
            {
                case View.Details:
                    detailsToolStripMenuItem.Checked = true;
                    break;
                case View.LargeIcon:
                    largeToolStripMenuItem.Checked = true;
                    break;
                case View.List:
                    listToolStripMenuItem.Checked = true;
                    break;
                case View.SmallIcon:
                    smallToolStripMenuItem.Checked = true;
                    break;
                case View.Tile:
                    lvFiles.View = View.List;
                    listToolStripMenuItem.Checked = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void UpdateList()
        {
            lvFiles.Items.Clear();

            //If folder icons not available
            if (!imgLarge.Images.ContainsKey("Folder"))
            {
                imgSmall.Images.Add("Folder", Properties.Resources.Folder);
                imgLarge.Images.Add("Folder", Properties.Resources.Folder);
            }

            foreach (DirectoryInfo di in directory.GetDirectories())
            {
                ListViewItem lvi = new ListViewItem(di.Name);
                lvi.Name = di.FullName;
                lvi.ImageKey = "Folder";
                lvi.Group = lvFiles.Groups["LVGFolders"];
                lvi.ToolTipText = di.FullName;
                lvi.Tag = di;

                lvi.SubItems.Add(di.CreationTime.ToShortDateString() + " " +
                    di.CreationTime.ToLongTimeString());
                lvi.SubItems.Add(di.LastAccessTime.ToShortDateString() + " " +
                    di.LastAccessTime.ToLongTimeString());
                lvi.SubItems.Add("-");

                lvFiles.Items.Add(lvi);
            }

            foreach (FileInfo fi in directory.GetFiles(filter))
            {
                Icon icon = Icon.ExtractAssociatedIcon(fi.FullName);

                //If icon not in lists
                if (!imgLarge.Images.ContainsKey(icon.ToBytes().GetCheckSum().ToString()))
                {
                    imgLarge.Images.Add(icon.ToBytes().GetCheckSum().ToString(), icon);
                    imgSmall.Images.Add(icon.ToBytes().GetCheckSum().ToString(), icon);
                }

                ListViewItem lvi = new ListViewItem(fi.Name);
                lvi.Name = fi.FullName;
                lvi.ImageKey = icon.ToBytes().GetCheckSum().ToString();
                lvi.Group = lvFiles.Groups["LVGFiles"];
                lvi.ToolTipText = fi.FullName;
                lvi.Tag = fi;

                lvi.SubItems.Add(fi.CreationTime.ToShortDateString() + " " +
                    fi.CreationTime.ToLongTimeString());
                lvi.SubItems.Add(fi.LastAccessTime.ToShortDateString() + " " +
                    fi.LastAccessTime.ToLongTimeString());
                lvi.SubItems.Add(fi.Length.ToByteSizeString());

                lvFiles.Items.Add(lvi);
            }
        }

        protected void DoFilterChanged()
        {
            if (FilterChanged != null)
                FilterChanged(this, new EventArgs());
        }

        protected void DoDirectoryChanged()
        {
            if (DirectoryChanged != null)
                DirectoryChanged(this, new EventArgs());
        }

        protected void DoDoubleClick()
        {
            if (DoubleClick != null)
                DoubleClick(this, new EventArgs());
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            DoDoubleClick();

            if (lvFiles.SelectedItems.Count <= 0)
                return;

            if (lvFiles.SelectedItems[0].Tag is DirectoryInfo)
            {
                if (!AutoFolderActionHandle)
                    return;

                Directory = lvFiles.SelectedItems[0].Tag as DirectoryInfo;
            }
            else if (lvFiles.SelectedItems[0].Tag is FileInfo)
            {
                if (!AutoFileActionHandle)
                    return;

                Process proc = new Process();
                proc.StartInfo.Arguments = "";
                proc.StartInfo.FileName = (lvFiles.SelectedItems[0].Tag as FileInfo).FullName;
                proc.StartInfo.WorkingDirectory = (lvFiles.SelectedItems[0].Tag as FileInfo).Directory.FullName;

                proc.Start();
            }
            else
                throw new NotImplementedException();
        }

        private void lvFiles_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvFiles.SelectedItems.Count > 0)
                {
                    if (HasObjectContextMenu)
                        cmsObject.Show(sender as Control, e.Location);
                }
                else
                {
                    if (HasPlaceContextMenu)
                        cmsFree.Show(sender as Control, e.Location);
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (directory.Parent != null)
                Directory = directory.Parent;
        }

        private void lvFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                if (lvFiles.Items[e.Item].Tag is DirectoryInfo)
                {
                    DirectoryInfo di = lvFiles.Items[e.Item].Tag as DirectoryInfo;
                    DirectoryInfo newDI = new DirectoryInfo(di.Parent.FullName + "\\" + e.Label);

                    if (di.FullName.EqualsIgnoreCase(newDI.FullName))
                        return;
                    System.IO.Directory.Move(di.FullName, newDI.FullName);

                    lvFiles.Items[e.Item].Tag = newDI;
                }
                else if (lvFiles.Items[e.Item].Tag is FileInfo)
                {
                    FileInfo fi = lvFiles.Items[e.Item].Tag as FileInfo;
                    FileInfo newFI = new FileInfo(fi.Directory.FullName + "\\" + e.Label);

                    if (fi.FullName.EqualsIgnoreCase(fi.FullName))
                        return;
                    File.Move(fi.FullName, newFI.FullName);

                    lvFiles.Items[e.Item].Tag = newFI;
                }
                else
                    throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvFiles.SelectedItems)
            {
                Process proc = new Process();
                proc.StartInfo.Arguments = lvi.ToolTipText;
                proc.StartInfo.FileName = "explorer.exe";
                proc.StartInfo.WorkingDirectory = lvi.ToolTipText;

                proc.Start();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringCollection files = new StringCollection();
            foreach (ListViewItem lvi in lvFiles.SelectedItems)
                files.Add(lvi.ToolTipText);

            Clipboard.SetFileDropList(files);
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFiles.View = View.Details;
            UpdateViewMenu();
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFiles.View = View.SmallIcon;
            UpdateViewMenu();
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFiles.View = View.LargeIcon;
            UpdateViewMenu();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFiles.View = View.List;
            UpdateViewMenu();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StringCollection files = Clipboard.GetFileDropList();
            foreach (String file in files)
            {
                FileInfo fi = new FileInfo(file);
                File.Copy(fi.FullName, directory.FullName + "\\" + fi.Name);
            }
            UpdateList();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count <= 0)
                return;

            foreach (ListViewItem lvi in lvFiles.SelectedItems)
            {
                if (lvi.Tag is DirectoryInfo)
                {
                    if (!AutoFolderActionHandle)
                        return;

                    Directory = lvi.Tag as DirectoryInfo;
                }
                else if (lvi.Tag is FileInfo)
                {
                    if (!AutoFileActionHandle)
                        return;

                    Process proc = new Process();
                    proc.StartInfo.Arguments = "";
                    proc.StartInfo.FileName = (lvi.Tag as FileInfo).FullName;
                    proc.StartInfo.WorkingDirectory = (lvi.Tag as FileInfo).Directory.FullName;

                    proc.Start();
                }
                else
                    throw new NotImplementedException();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                TextManager.Dialog.Question.Delete.Message, 
                TextManager.Dialog.Question.Delete.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lvFiles.SelectedItems)
                {
                    if (lvi.Tag is DirectoryInfo)
                        System.IO.Directory.Delete((lvi.Tag as DirectoryInfo).FullName, true);
                    else if (lvi.Tag is FileInfo)
                        System.IO.File.Delete((lvi.Tag as FileInfo).FullName);
                    else
                        throw new NotImplementedException();
                }

                UpdateList();
            }
        }

        #region EventHandling LinkedDirectoryBox

        private void linkedDirectoryBox_DirectoryChanged(object sender, EventArgs e)
        {
            this.DirectoryChanged -= new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryBox);
            this.Directory = linkedDirectoryBox.SelectedDirectory;
            this.DirectoryChanged += new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryBox);
        }

        private void FileSystemManager_DirectoryChanged_LinkedDirectoryBox(object sender, EventArgs e)
        {
            linkedDirectoryBox.DirectoryChanged -= new EventHandler(linkedDirectoryBox_DirectoryChanged);
            linkedDirectoryBox.SelectedDirectory = this.directory;
            linkedDirectoryBox.DirectoryChanged += new EventHandler(linkedDirectoryBox_DirectoryChanged);
        }

        #endregion

        #region EventHanling LinkedFileFilterBox

        private void linkedFileFilterBox_FileFilterChanged(object sender, EventArgs e)
        {
            this.Filter = linkedFileFilterBox.SelectedFilter.Filter;
        }

        #endregion

        #region EventHandling LinkedDirectoryTree

        private void FileSystemManager_DirectoryChanged_LinkedDirectoryTree(object sender, EventArgs e)
        {
            linkedDirectoryTree.DirectoryChanged -= new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryTree);
            linkedDirectoryTree.SelectedDirectory = directory;
            linkedDirectoryTree.DirectoryChanged += new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryTree);
        }

        private void linkedDirectoryTree_DirectoryChanged(object sender, EventArgs e)
        {
            this.DirectoryChanged -= new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryTree);
            Directory = linkedDirectoryTree.SelectedDirectory;
            this.DirectoryChanged += new EventHandler(FileSystemManager_DirectoryChanged_LinkedDirectoryTree);
        }

        #endregion

        protected void DoSelectedObjectChanged()
        {
            if (SelectedObjectChanged != null)
                SelectedObjectChanged(this, new EventArgs());
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoSelectedObjectChanged();
        }

        private void FileSystemManager_Enter(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsData(DataFormats.FileDrop);
        }
    }
}
