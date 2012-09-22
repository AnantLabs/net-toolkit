using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace NET.Tools.WPF.Skins
{
    internal partial class CommandManager
    {
        private void DragMoveAction(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Start DragMove!");
            if (e.LeftButton == MouseButtonState.Pressed)
                ((sender as FrameworkElement).TemplatedParent as Window).DragMove();
        }

        private void CloseAction(object sender, RoutedEventArgs e)
        {
            GetHomeWindow(sender).Close();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Maximize(GetHomeWindow(sender));
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            Maximize(GetHomeWindow(sender));
        }

        private void Maximize(Window win)
        {
            if ((win.ResizeMode == ResizeMode.CanResize) ||
                (win.ResizeMode == ResizeMode.CanResizeWithGrip))
            {
                if (win.WindowState == WindowState.Normal)
                    win.WindowState = WindowState.Maximized;
                else
                    win.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            GetHomeWindow(sender).WindowState = WindowState.Minimized;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as System.Windows.Controls.Button).ContextMenu.IsOpen = true;
        }

        private void MenuButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GetHomeWindow(sender).Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            GetHomeWindow(sender).Close();
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            Maximize(GetHomeWindow(sender));
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            GetHomeWindow(sender).WindowState = WindowState.Minimized;
        }

        private Window GetHomeWindow(object sender)
        {
            return ((sender as FrameworkElement).TemplatedParent as Window);
        }

        private void NS_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Window win = GetHomeWindow(sender);
            win.Height += e.VerticalChange;
        }

        private void WE_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Window win = GetHomeWindow(sender);
            win.Width += e.HorizontalChange;
        }
    }
}
