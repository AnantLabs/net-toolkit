using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using NET.Tools.Forms;



namespace NET.Tools.Forms
{
    public class UIHighLightingEditor : UITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            HighLightingEditor dlg = new HighLightingEditor();
            dlg.Records = (HighLightingRecord[])value;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return dlg.Records;

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
