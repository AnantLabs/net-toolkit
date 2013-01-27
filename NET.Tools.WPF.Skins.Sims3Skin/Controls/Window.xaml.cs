using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace NET.Tools.WPF.Skins
{
    internal partial class CommandManager
    {
        public void DragDropCaption(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                GetHomeWindow(sender).DragMove();
        }

        public void MaximizeCaption(object sender, MouseEventArgs e)
        {
            if ((GetHomeWindow(sender).ResizeMode == ResizeMode.CanResize) ||
                (GetHomeWindow(sender).ResizeMode == ResizeMode.CanResizeWithGrip))
            {
                if (GetHomeWindow(sender).WindowState == WindowState.Maximized)
                    GetHomeWindow(sender).WindowState = WindowState.Normal;
                else
                    GetHomeWindow(sender).WindowState = WindowState.Maximized;
            }
        }

        public void CloseClick(object sender, RoutedEventArgs e)
        {
            GetHomeWindow(sender).Close();
        }

        public void MinimizeClick(object sender, RoutedEventArgs e)
        {
            GetHomeWindow(sender).WindowState = WindowState.Minimized;
        }

        private Window GetHomeWindow(object sender)
        {
            return ((sender as FrameworkElement).TemplatedParent as Window);
        }
    }
}
