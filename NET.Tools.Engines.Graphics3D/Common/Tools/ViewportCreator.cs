using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class ViewportCreator : Creator<Viewport>
    {
        public static ViewportCreator CreateViewport(int left, int top, int width, int height, float? nearestZ, float? farthestZ, Color background)
        {
            return new ViewportCreator(left, top, width, height, nearestZ, farthestZ, background);
        }

        public static ViewportCreator CreateViewport(int left, int top, int width, int height, Color background)
        {
            return CreateViewport(left, top, width, height, null, null, background);
        }

        public static ViewportCreator CreateViewport(int width, int height, Color background)
        {
            return CreateViewport(0, 0, width, height, background);
        }

        public static ViewportCreator CreateViewport(int left, int top, int width, int height, float? nearestZ, float? farthestZ)
        {
            return CreateViewport(left, top, width, height, nearestZ, farthestZ, Color.Black);
        }

        public static ViewportCreator CreateViewport(int width, int height, float? nearestZ, float? farthestZ)
        {
            return CreateViewport(0, 0, width, height, nearestZ, farthestZ);
        }

        public static ViewportCreator CreateViewport(int left, int top, int width, int height)
        {
            return CreateViewport(left, top, width, height, null, null);
        }

        public static ViewportCreator CreateViewport(int width, int height)
        {
            return CreateViewport(0, 0, width, height);
        }

        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public float? NearestZ { get; private set; }
        public float? FarthestZ { get; private set; }
        public Color Background { get; private set; }

        private ViewportCreator(int left, int top, int width, int height, float? nearestZ, float? farthestZ, Color background)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Background = background;
            NearestZ = nearestZ;
            FarthestZ = farthestZ;
        }

        internal override Viewport Create()
        {
            return new Viewport(Left, Top, Width, Height, NearestZ, FarthestZ, Background);
        }
    }
}
