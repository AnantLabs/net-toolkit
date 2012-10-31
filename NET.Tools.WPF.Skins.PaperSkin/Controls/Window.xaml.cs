using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NET.Tools.WPF.Skins
{
    internal partial class CommandManager
    {
        private void Label_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                GetHomeWindow(sender).DragMove();
        }

        private Window GetHomeWindow(object sender)
        {
            return ((sender as FrameworkElement).TemplatedParent as Window);
        }
    }
}
