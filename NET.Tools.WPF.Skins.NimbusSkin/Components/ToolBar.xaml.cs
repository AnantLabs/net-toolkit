using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace NET.Tools.WPF.Skins
{
    internal partial class ToolBarCode : ResourceDictionary
    {
        private ToolBar GetHomeToolBar(object sender)
        {
            return ((sender as FrameworkElement).TemplatedParent as ToolBar);
        }

        private void Move_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            ToolBar tb = GetHomeToolBar(sender);
            tb.Margin = new Thickness(
                tb.Margin.Left + e.HorizontalChange, tb.Margin.Top, 
                tb.Margin.Right, tb.Margin.Bottom);
        }
    }
}
