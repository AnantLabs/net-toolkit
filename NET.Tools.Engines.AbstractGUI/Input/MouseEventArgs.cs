using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    public enum MouseButton
    {
        None,
        Left,
        Middle,
        Right,
        X1,
        X2
    }

    public class MouseEventArgs : EventArgs
    {
        public Point Position { get; private set; }
        public int MouseWheel { get; private set; }
        public MouseButton MouseButton { get; private set; }

        public MouseEventArgs(Point position, int mouseWheel, MouseButton mouseButton)
        {
            Position = position;
            MouseWheel = mouseWheel;
            MouseButton = mouseButton;
        }

        public MouseEventArgs(Point position) : this(position, 0, MouseButton.None)
        {
        }

        public MouseEventArgs(int mouseWheel) : this(Point.Empty, mouseWheel, MouseButton.None)
        {
        }

        public MouseEventArgs(Point position, MouseButton mouseButton) : this(position, 0, mouseButton)
        {
        }
    }

    public delegate void MouseEventHandler(object sender, MouseEventArgs e);

    /// @}
}
