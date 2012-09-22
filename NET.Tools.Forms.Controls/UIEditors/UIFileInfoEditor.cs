using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.IO;

namespace NET.Tools.Forms
{
    public class UIFileInfoEditor : UITypeEditor
    {
        public override void PaintValue(PaintValueEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = (value as FileInfo).Name;
            dlg.InitialDirectory = (value as FileInfo).Directory.FullName;

            if (dlg.ShowDialog() == DialogResult.OK)
                return new FileInfo(dlg.FileName);

            return value;
        }
    }
}
