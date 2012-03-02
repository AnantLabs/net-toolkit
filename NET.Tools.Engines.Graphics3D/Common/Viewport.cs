using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class Viewport
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float? NearestZ { get; set; }
        public float? FarthestZ { get; set; }
        public Color Background { get; set; }
        public Camera Camera { get; private set; }

        internal Viewport(int left, int top, int width, int height, float? nearestZ, float? farthestZ, Color background)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Background = background;
            NearestZ = nearestZ;
            FarthestZ = farthestZ;
            Camera = new Camera();
        }
    }
}
