using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace NET.Tools.Forms
{
    [ToolboxItemFilter("NET Tools")]
    public class ImageComboBox : ComboBox
    {
        [Browsable(true)]
        [Category("Design")]
        [Description("Sets the image list to show on items")]
        public ImageList ImageList { get; set; }

        public ImageComboBox()
            : base()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0)
                return;

            if (ImageList != null)
            {
                if (ImageList.Images.Count > e.Index)
                {
                    ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, e.Index);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                        new SolidBrush(e.ForeColor), e.Bounds.Left + ImageList.ImageSize.Width,
                        e.Bounds.Top);
                    return;
                }
            }

            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                new SolidBrush(e.ForeColor), e.Bounds.Left,
                e.Bounds.Top);
        }
    }
}
