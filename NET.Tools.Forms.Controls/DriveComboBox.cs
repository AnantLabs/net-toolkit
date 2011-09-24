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
    [ToolboxBitmap(typeof(DriveComboBox), "DriveCMB")]
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("SelectedDrive")]
    public partial class DriveComboBox : UserControl
    {
        #region Internal Classes

        private class DriveItem
        {
            public DriveInfo DriveInfo { get; private set; }

            public DriveItem(DriveInfo di)
            {
                DriveInfo = di;
            }

            public override string ToString()
            {
                try
                {
                    return DriveInfo.RootDirectory.FullName + " (" +
                        DriveInfo.VolumeLabel + ")";
                }
                catch (Exception)
                {
                    return DriveInfo.RootDirectory.FullName;
                }
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                else if (!(obj is DriveItem))
                    return false;
                else if (Object.ReferenceEquals(this, obj))
                    return true;

                return DriveInfo.Equals((obj as DriveItem).DriveInfo);
            }

            public override int GetHashCode()
            {
                return DriveInfo.GetHashCode();
            }
        }

        #endregion

        private bool searchCDDVD = true, searchNetwork = true, searchFixed = true, 
            searchRemovable = true, searchOthers = false;

        [Browsable(true)]
        [Category("Behavior")]
        public event EventHandler DriveChanged;

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Include all CD/DVD/Blueray drives ")]
        [DefaultValue(true)]
        public bool SearchCDDVD { get { return searchCDDVD; } set { searchCDDVD = value; UpdateList(); } }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Include all Network drives ")]
        [DefaultValue(true)]
        public bool SearchNetwork { get { return searchNetwork; } set { searchNetwork = value; UpdateList(); } }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Include all Fixed drives ")]
        [DefaultValue(true)]
        public bool SearchFixed { get { return searchFixed; } set { searchFixed = value; UpdateList(); } }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Include all Removable drives ")]
        [DefaultValue(true)]
        public bool SearchRemovable { get { return searchRemovable; } set { searchRemovable = value; UpdateList(); } }
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Include all Unknown drives ")]
        [DefaultValue(false)]
        public bool SearchOthers { get { return searchOthers; } set { searchOthers = value; UpdateList(); } }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets the selected drive")]
        [Editor(typeof(UIDriveInfoEditor), typeof(UITypeEditor))]
        public DriveInfo SelectedDrive
        {
            get 
            {
                if (cmbDrives.SelectedIndex < 0)
                    return null;
                else
                    return (cmbDrives.SelectedItem as DriveItem).DriveInfo;
            }
            set 
            {
                try
                {
                    foreach (Object obj in cmbDrives.Items)
                    {
                        DriveInfo di = (obj as DriveItem).DriveInfo;
                        if (di.RootDirectory.FullName.Equals(value.RootDirectory.FullName))
                        {
                            cmbDrives.SelectedItem = obj;
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Fehler: " + e.Message + " (" + e.GetType().Name + ")\n" + e.StackTrace);
                }
            }
        }

        public DriveComboBox()
        {
            InitializeComponent();
            this.Height = cmbDrives.Height;

            this.cmbDrives.SelectedIndexChanged += (s, e) =>
            {
                DoDriveChanged();
            };

            UpdateList();
        }

        protected void DoDriveChanged()
        {
            if (DriveChanged != null)
                DriveChanged(this, new EventArgs());
        }

        private void DriveComboBox_Resize(object sender, EventArgs e)
        {
            this.Height = cmbDrives.Height;
        }

        private void UpdateList()
        {
            cmbDrives.Items.Clear();
            imgList.Images.Clear();
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                switch (di.DriveType)
                {
                    case DriveType.CDRom:
                        if (!searchCDDVD)
                            continue;
                        imgList.Images.Add(Properties.Resources.CDDVD);
                        break;
                    case DriveType.Fixed:
                        if (!searchFixed)
                            continue;
                        imgList.Images.Add(Properties.Resources.HDD);
                        break;
                    case DriveType.Network:
                        if (!searchNetwork)
                            continue;
                        imgList.Images.Add(Properties.Resources.Network);
                        break;
                    case DriveType.NoRootDirectory:
                        if (!searchOthers)
                            continue;
                        imgList.Images.Add(Properties.Resources.HDD);
                        break;
                    case DriveType.Ram:
                        if (!searchFixed)
                            continue;
                        imgList.Images.Add(Properties.Resources.HDD);
                        break;
                    case DriveType.Removable:
                        if (!searchRemovable)
                            continue;
                        imgList.Images.Add(Properties.Resources.Stick);
                        break;
                    case DriveType.Unknown:
                        if (!searchOthers)
                            continue;
                        imgList.Images.Add(Properties.Resources.HDD);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                cmbDrives.Items.Add(new DriveItem(di));                
            }
            cmbDrives.SelectedIndex = 0;
        }
    }
}
