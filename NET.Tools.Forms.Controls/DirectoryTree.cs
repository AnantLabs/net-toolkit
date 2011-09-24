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
    [DefaultEvent("DirectoryChanged")]
    [DefaultProperty("SelectedDirectory")]
    public partial class DirectoryTree : UserControl
    {
        private const String EMPTYNODE = "?";

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
            get { return directory; }
            set
            {
                directory = value;
                InitializeTree();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the selection is shown or not if control is inactive")]
        [DefaultValue(false)]
        public bool HideSelection
        {
            get { return tvDirectories.HideSelection; }
            set { tvDirectories.HideSelection = value; }
        }

        [Browsable(true)]
        [Category("Design")]
        [Description("Sets that is shown icons on each node")]
        [DefaultValue(true)]
        public bool ShowIcons
        {
            get { return tvDirectories.ImageList != null; }
            set { if (value) tvDirectories.ImageList = imgList; else tvDirectories.ImageList = null; }
        }

        public DirectoryTree()
        {
            InitializeComponent();
            directory = new DirectoryInfo("C:\\");
            InitializeTree();
        }

        private void InitializeTree()
        {
            tvDirectories.Nodes.Clear();
            imgList.Images.Clear();

            imgList.Images.Add("Folder", Properties.Resources.Folder);
            TreeNode selectedNode = null;

            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                imgList.Images.Add(di.RootDirectory.Name, di.GetIcon());

                TreeNode node = null;
                try
                {
                    node = new TreeNode(di.RootDirectory.Name + " (" + di.VolumeLabel + ")");
                }
                catch (Exception)
                {
                    node = new TreeNode(di.RootDirectory.Name);
                }
                node.ImageKey = di.RootDirectory.Name;
                node.SelectedImageKey = di.RootDirectory.Name;
                node.Tag = di.RootDirectory;

                //If Drive the root drive of the selected directory, build tree
                if (di.RootDirectory.FullName[0] == directory.FullName[0])
                {
                    TreeNode activeNode = node;
                    List<DirectoryInfo> dirList = new List<DirectoryInfo>(directory.GetDirectoryParents());
                    dirList.Add(directory);
                    for (int i = 1; i < dirList.Count; i++ )
                    {
                        //Update active Node (first is root node)
                        UpdateNode(activeNode);
                        activeNode.Expand(); //Open Node

                        //Get next Directory (Child of root at first)
                        DirectoryInfo dir = dirList[i];
                        //Set next active node (Child of directory)
                        activeNode = activeNode.Nodes[dir.FullName];
                    }

                    if (directory.GetDirectories().Length > 0)
                        activeNode.Nodes.Add(EMPTYNODE);
                    selectedNode = activeNode;
                }
                else
                {
                    node.Nodes.Add(EMPTYNODE);
                }

                tvDirectories.Nodes.Add(node);
            }

            tvDirectories.SelectedNode = selectedNode;
        }

        private void tvDirectories_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //Is the node is not initialized?
            if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text.Equals(EMPTYNODE))
            {
                try
                {
                    UpdateNode(e.Node);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (e.Node.Nodes.Count <= 0)
                    {
                        e.Node.Nodes.Add(EMPTYNODE);
                        e.Node.Collapse();
                    }
                }
            }
        }

        private void UpdateNode(TreeNode node)
        {
            node.Nodes.Clear();
            DirectoryInfo di = node.Tag as DirectoryInfo;

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                TreeNode child = CreateDirectoryNode(dir);
                try
                {
                    if (dir.GetDirectories().Length > 0)
                        child.Nodes.Add(EMPTYNODE);
                }
                catch (Exception) { }

                node.Nodes.Add(child);
            }
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo di)
        {
            TreeNode child = new TreeNode(di.Name);
            child.Tag = di;
            child.Name = di.FullName;

            return child;
        }

        private void tvDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            directory = e.Node.Tag as DirectoryInfo;
            DoDirectoryChanged();
        }

        protected void DoDirectoryChanged()
        {
            if (DirectoryChanged != null)
                DirectoryChanged(this, new EventArgs());
        }
    }
}
