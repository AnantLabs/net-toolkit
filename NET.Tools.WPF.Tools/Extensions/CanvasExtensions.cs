using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Brush = System.Windows.Media.Brush;
using FontStyle = System.Windows.FontStyle;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;
using Size = System.Windows.Size;

namespace NET.Tools
{
    public static class CanvasExtensions
    {
        #region Rectangle

        public static Rectangle AddRectangle(this Canvas canvas, double x, double y, double width, double height, Brush fill, Brush stroke)
        {
            Rectangle rectangle = new Rectangle {Width = width, Height = height};
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

        #endregion

        #region Ellipse

        public static Ellipse AddEllipse(this Canvas canvas, double x, double y, double width, double height, Brush fill, Brush stroke)
        {
            Ellipse ellipse = new Ellipse { Width = width, Height = height };
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);
            if (fill != null)
                ellipse.Fill = fill;
            if (stroke != null)
                ellipse.Stroke = stroke;

            canvas.Children.Add(ellipse);
            return ellipse;
        }

        public static Ellipse AddEllipse(this Canvas canvas, Point point, Size size, Brush fill, Brush stroke)
        {
            return AddEllipse(canvas, new Rect(point, size), fill, stroke);
        }

        public static Ellipse AddEllipse(this Canvas canvas, Rect rect, Brush fill, Brush stroke)
        {
            return AddEllipse(canvas, rect.Left, rect.Top, rect.Width, rect.Height, fill, stroke);
        }

        public static Ellipse AddFilledEllipse(this Canvas canvas, double x, double y, double width, double height, Brush fill)
        {
            return AddEllipse(canvas, x, y, width, height, fill, null);
        }

        public static Ellipse AddFilledEllipse(this Canvas canvas, Point point, Size size, Brush fill)
        {
            return AddFilledEllipse(canvas, new Rect(point, size), fill);
        }

        public static Ellipse AddFilledEllipse(this Canvas canvas, Rect rect, Brush fill)
        {
            return AddFilledEllipse(canvas, rect.Left, rect.Top, rect.Width, rect.Height, fill);
        }

        public static Ellipse AddStrokedEllipse(this Canvas canvas, double x, double y, double width, double height, Brush stroke)
        {
            return AddEllipse(canvas, x, y, width, height, null, stroke);
        }

        public static Ellipse AddStrokedEllipse(this Canvas canvas, Point point, Size size, Brush stroke)
        {
            return AddStrokedEllipse(canvas, new Rect(point, size), stroke);
        }

        public static Ellipse AddStrokedEllipse(this Canvas canvas, Rect rect, Brush stroke)
        {
            return AddStrokedEllipse(canvas, rect.Left, rect.Top, rect.Width, rect.Height, stroke);
        }

        #endregion

        #region Text

        public static TextBlock AddText(this Canvas canvas, double x, double y, double width, double height, String text, double fontSize, bool bold, TextAlignment alignment, Brush fill)
        {
            TextBlock textBlock = new TextBlock()
                {
                    Width = width,
                    Height = height,
                    Text = text,
                    Foreground = fill,
                    FontSize = fontSize,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = alignment,
                    VerticalAlignment = VerticalAlignment.Center
                };
            if (bold)
            {
                textBlock.FontWeight = FontWeights.Bold;
            }
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);

            canvas.Children.Add(textBlock);
            return textBlock;
        }

        public static TextBlock AddText(this Canvas canvas, Point position, Size size, String text, double fontSize, bool bold, TextAlignment alignment, Brush fill)
        {
            return AddText(canvas, position.X, position.Y, size.Width, size.Height, text, fontSize, bold, alignment, fill);
        }

        public static TextBlock AddText(this Canvas canvas, Rect rect, String text, double fontSize, bool bold, TextAlignment alignment, Brush fill)
        {
            return AddText(canvas, rect.Left, rect.Top, rect.Width, rect.Height, text, fontSize, bold, alignment, fill);
        }

        #endregion
    }
}
