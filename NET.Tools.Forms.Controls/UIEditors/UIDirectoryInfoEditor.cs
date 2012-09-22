using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.ComponentModel;


namespace NET.Tools.Forms
{
    public class UIDirectoryInfoEditor : UITypeEditor
    {
        public UIDirectoryInfoEditor()
        {
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            if ((e.Value as DirectoryInfo).Exists)
                e.Graphics.DrawImage(Properties.Resources.Folder.ToBitmap(),
                    e.Bounds);
            else
                e.Graphics.DrawImage(Properties.Resources.FolderBad.ToBitmap(),
                    e.Bounds);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = value.ToString();
            dlg.Description = TextManager.Dialog.Input.Path.Message;
            if (dlg.ShowDialog() == DialogResult.OK)
                return new DirectoryInfo(dlg.SelectedPath);

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
