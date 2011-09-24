using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NET.Tools.WPF.Skins
{
    internal partial class CommandManager
    {
        private Window GetHomeWindow(object sender)
        {
            return ((sender as FrameworkElement).TemplatedParent as Window);
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GetHomeWindow(sender).DragMove();
        }
    }
}
