using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using NET.Tools.Forms;


namespace NET.Tools.Forms
{
    public class UIDriveInfoEditor : UITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            DriveInfoSelector dlg = new DriveInfoSelector();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return dlg.SelectedDriveInfo;

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

        public override void PaintValue(PaintValueEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
