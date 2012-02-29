using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Graphics3D.Common
{
    public sealed class Viewport
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Background { get; set; }
        public Camera Camera { get; private set; }

        public Viewport(int left, int top, int width, int height, Color background)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Background = background;
            Camera = new Camera();
        }

        public Viewport(int left, int top, int width, int height)
            : this(left, top, width, height, Color.Black)
        {
        }
    }
}
