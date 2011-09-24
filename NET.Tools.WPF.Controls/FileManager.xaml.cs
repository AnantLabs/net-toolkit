using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

namespace NET.Tools.WPF
{
    /// <summary>
    /// Interaktionslogik für FileManager.xaml
    /// </summary>
    public partial class FileManager : UserControl
    {
        #region Static Members

        private static Dictionary<long, System.Drawing.Icon> images = new Dictionary<long, System.Drawing.Icon>();

        private static System.Drawing.Icon CreateImage(System.Drawing.Icon icon)
        {
            long checkSum = icon.ToBytes().GetCheckSum();

            if (images.ContainsKey(checkSum))
                return images[checkSum];

            images.Add(checkSum, icon);
            return icon;
        }

        #endregion

        /// <summary>
        /// Is called if an exception is thrown (to handle with own e. g. message dialog)
        /// </summary>
        [Browsable(true)]
        public event ExceptionEventHandler ExceptionIsThrown;

        private DirectoryInfo directory;

        [Browsable(true)]
        [TypeConverter(typeof(DirectoryInfoConverter))]
        [Category("Behavior")]
        public DirectoryInfo Directory
        {
            get { return directory; }
            set
            {
                DirectoryInfo old = directory;
                try
                {
                    directory = value;
                    miBack.IsEnabled = Directory.Parent != null;
                    UpdateList();
                }
                catch (Exception e)
                {
                    if (ExceptionIsThrown != null)
                        ExceptionIsThrown(this,
                            new NET.Tools.ExceptionEventArgs("Cannot change directory!", e));
                    directory = old;
                    UpdateList();
                }
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AutoFileReaction { get; set; }
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AutoDirectoryReaction { get; set; }
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AutoContextMenu
        {
            get { return this.ContextMenu != null; }
            set
            {
                if (value)
                    this.ContextMenu = cmDefault;
                else
                    this.ContextMenu = null;
            }
        }

        public FileManager()
        {
            InitializeComponent();

            Directory = new DirectoryInfo("C:\\");
            AutoDirectoryReaction = true;
            AutoFileReaction = true;
            AutoContextMenu = true;
        }

        private void UpdateList()
        {
            lvFiles.Items.Clear();

            foreach (DirectoryInfo di in directory.GetDirectories())
            {
                lvFiles.Items.Add(CreateListViewItem(di));
            }

            foreach (FileInfo fi in directory.GetFiles())
            {
                lvFiles.Items.Add(CreateListViewItem(fi));
            }
        }

        private ListViewItem CreateListViewItem(DirectoryInfo di)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Width = 125;
            panel.Height = Double.NaN;
            panel.Margin = new Thickness(5);
            panel.Children.Add(CreateImage(di.GetIcon()).ToWPFImage(32, 32));
            TextBlock label = new TextBlock();
            label.TextAlignment = TextAlignment.Center;
            label.Text = di.Name;
            panel.Children.Add(label);

            ListViewItem lvi = new ListViewItem();
            lvi.Content = panel;
            lvi.Tag = di;

            return lvi;
        }

        private ListViewItem CreateListViewItem(FileInfo fi)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Width = 125;
            panel.Height = Double.NaN;
            panel.Margin = new Thickness(5);
            panel.Children.Add(CreateImage(fi.GetIcon()).ToWPFImage(32, 32));
            TextBlock label = new TextBlock();
            label.TextAlignment = TextAlignment.Center;
            label.Text = fi.Name;
            panel.Children.Add(label);

            ListViewItem lvi = new ListViewItem();
            lvi.Content = panel;
            lvi.Tag = fi;

            return lvi;
        }

        private void lvFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvFiles.SelectedItems.Count <= 0)
                return;

            if ((lvFiles.SelectedItem as ListViewItem).Tag is DirectoryInfo)
            {
                if (!AutoDirectoryReaction)
                    return;

                Directory = (lvFiles.SelectedItem as ListViewItem).Tag as DirectoryInfo;
            }
            else if ((lvFiles.SelectedItem as ListViewItem).Tag is FileInfo)
            {
                if (!AutoFileReaction)
                    return;

                FileInfo fi = (lvFiles.SelectedItem as ListViewItem).Tag as FileInfo;

                Process proc = new Process();
                proc.StartInfo.Arguments = "";
                proc.StartInfo.FileName = fi.FullName;
                proc.StartInfo.WorkingDirectory = fi.Directory.FullName;
                proc.Start();
            }
            else
                throw new NotImplementedException();
        }

        private void miBack_Click(object sender, RoutedEventArgs e)
        {
            Directory = Directory.Parent;
        }
    }
}
