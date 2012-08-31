using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NET.Tools
{
    public static class CanvasExtensions
    {
        public static Rectangle AddRectangle(this Canvas canvas, double x, double y, double width, double height, Brush fill, Brush stroke)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            if (fill != null)
                rectangle.Fill = fill;
            if (stroke != null)
                rectangle.Stroke = stroke;

            canvas.Children.Add(rectangle);
            return rectangle;
        }

        public static Rectangle AddRectangle(this Canvas canvas, Point point, Size size, Brush fill, Brush stroke)
        {
            return AddRectangle(canvas, new Rect(point, size), fill, stroke);
        }

        public static Rectangle AddRectangle(this Canvas canvas, Rect rect, Brush fill, Brush stroke)
        {
            return AddRectangle(canvas, rect.Left, rect.Top, rect.Width, rect.Height, fill, stroke);
        }

        public static Rectangle AddFilledRectangle(this Canvas canvas, double x, double y, double width, double height, Brush fill)
        {
            return AddRectangle(canvas, x, y, width, height, fill, null);
        }

        public static Rectangle AddFilledRectangle(this Canvas canvas, Point point, Size size, Brush fill)
        {
            return AddFilledRectangle(canvas, new Rect(point, size), fill);
        }

        public static Rectangle AddFilledRectangle(this Canvas canvas, Rect rect, Brush fill)
        {
            return AddFilledRectangle(canvas, rect.Left, rect.Top, rect.Width, rect.Height, fill);
        }

        public static Rectangle AddStrokedRectangle(this Canvas canvas, double x, double y, double width, double height, Brush stroke)
        {
            return AddRectangle(canvas, x, y, width, height, null, stroke);
        }

        public static Rectangle AddStrokedRectangle(this Canvas canvas, Point point, Size size, Brush stroke)
        {
            return AddStrokedRectangle(canvas, new Rect(point, size), stroke);
        }

        public static Rectangle AddStrokedRectangle(this Canvas canvas, Rect rect, Brush stroke)
        {
            return AddStrokedRectangle(canvas, rect.Left, rect.Top, rect.Width, rect.Height, stroke);
        }
    }
}
