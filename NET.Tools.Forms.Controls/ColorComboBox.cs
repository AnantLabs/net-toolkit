using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    public partial class ColorComboBox : UserControl
    {
        private bool useSystemColors = false;

        [Browsable(true)]
        [Category("WindowStyle")]
        [Description("Sets the selected color")]
        public Color SelectedColor
        {
            get { return Color.FromName(cmbColors.SelectedItem.ToString()); }
            set { cmbColors.SelectedItem = value.Name; }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Sets that the system colors are used in combo box")]
        [DefaultValue(false)]
        public bool UseSystemColors
        {
            get { return useSystemColors; }
            set { useSystemColors = value; UpdateList(); }
        }

        public ColorComboBox()
        {
            InitializeComponent();
            this.Height = cmbColors.Height;

            UpdateList();
        }

        private void ColorComboBox_Resize(object sender, EventArgs e)
        {
            this.Height = cmbColors.Height;
        }

        private void UpdateList()
        {
            cmbColors.Items.Clear();
            imgList.Images.Clear();

            SearchColors(typeof(Color));
            if (useSystemColors)
                SearchColors(typeof(SystemColors));

            cmbColors.SelectedIndex = 0;
        }

        private void SearchColors(Type type)
        {
            PropertyInfo[] piList = type.GetProperties(
                BindingFlags.Public | BindingFlags.Static);
            foreach (PropertyInfo pi in piList)
            {
                if (pi.PropertyType.Equals(typeof(Color)))
                {
                    Color color = (Color)pi.GetValue(null, null);
                    Bitmap bmp = new Bitmap(16, 16);
                    Graphics g = Graphics.FromImage(bmp);
                    g.FillRectangle(color.ToSolidBrush(), new Rectangle(0, 0, 16, 16));
                    g.Dispose();

                    cmbColors.Items.Add(pi.Name);
                    imgList.Images.Add(bmp);
                }
            }
        }
    }
}
