using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;



namespace NET.Tools.Forms
{
    internal sealed class FolderComboBox : ComboBox
    {
        public FolderComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DoubleBuffered = true;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0)
                return;

            if ((e.State & DrawItemState.ComboBoxEdit) != 0)
            {
                DirectoryInfo di = (this.Items[e.Index] as DirectoryInfo);
                Image image = Properties.Resources.Folder.ToBitmap();
                String text = di.Name;
                if (di.GetParents().Length == 0)
                {
                    image = di.ToRootDriveInfo().GetIcon().ToBitmap();
                    try
                    {
                        text += " (" + di.ToRootDriveInfo().VolumeLabel + ")";
                    }
                    catch (Exception) { }
                }

                e.Graphics.DrawImage(image, new Rectangle(
                        e.Bounds.Left, 
                        e.Bounds.Top, 
                        16, 16));
                e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor),
                    e.Bounds.Left + 16, e.Bounds.Top);
            }
            else
            {
                DirectoryInfo di = (this.Items[e.Index] as DirectoryInfo);
                int level = di.GetParents().Length;
                Image image = Properties.Resources.Folder.ToBitmap();
                String text = di.Name;
                if (di.GetParents().Length == 0)
                {
                    image = di.ToRootDriveInfo().GetIcon().ToBitmap();
                    try
                    {
                        text += " (" + di.ToRootDriveInfo().VolumeLabel + ")";
                    }
                    catch (Exception) { }
                }

                e.Graphics.DrawImage(image, new Rectangle(
                        e.Bounds.Left + level * 10, 
                        e.Bounds.Top, 
                        16, 16));
                e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor),
                    e.Bounds.Left + level * 10 + 16, e.Bounds.Top);
            }
        }
    }
}
