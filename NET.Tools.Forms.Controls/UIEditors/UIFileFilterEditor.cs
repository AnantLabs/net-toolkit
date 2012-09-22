using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using NET.Tools.Forms;



namespace NET.Tools.Forms
{
    public class UIFileFilterEditor : UITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            FileFilterEditor dlg = new FileFilterEditor();
            dlg.FileFilterList = new List<FileFilter>(value as FileFilter[]);

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dlg.FileFilterList.ToArray();
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }
    }
}
