using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using NET.Tools.Forms;


namespace NET.Tools.Forms
{
    public class UIBrushEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            e.Graphics.FillRectangle(e.Value as Brush, e.Bounds);
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            BrushEditor dlg = new BrushEditor();
            dlg.SelectedBrush = value as Brush;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return dlg.SelectedBrush;

            return value;
        }
    }
}
