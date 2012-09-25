using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using FontStyle = System.Windows.FontStyle;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;
using Size = System.Windows.Size;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class CanvasExtensions
    {
        #region Rectangle

        public static Rectangle AddRectangle(this Canvas canvas, double x, double y, double width, double height, ShapeStyle shapeStyle)
        {
            Rectangle rectangle = new Rectangle
                {
                    Width = width,
                    Height = height
                };
            rectangle.UpdateShape(shapeStyle);
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);

            canvas.Children.Add(rectangle);
            return rectangle;
        }

        public static Rectangle AddRectangle(this Canvas canvas, Point point, Size size, ShapeStyle shapeStyle)
        {
            return AddRectangle(canvas, new Rect(point, size), shapeStyle);
        }

        public static Rectangle AddRectangle(this Canvas canvas, Rect rect, ShapeStyle shapeStyle)
        {
            return AddRectangle(canvas, rect.Left, rect.Top, rect.Width, rect.Height, shapeStyle);
        }

        #endregion

        #region Ellipse

        public static Ellipse AddEllipse(this Canvas canvas, double x, double y, double width, double height, ShapeStyle shapeStyle)
        {
            Ellipse ellipse = new Ellipse
                {
                    Width = width,
                    Height = height
                };
            ellipse.UpdateShape(shapeStyle);
            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);

            canvas.Children.Add(ellipse);
            return ellipse;
        }

        public static Ellipse AddEllipse(this Canvas canvas, Point point, Size size, ShapeStyle shapeStyle)
        {
            return AddEllipse(canvas, new Rect(point, size), shapeStyle);
        }

        public static Ellipse AddEllipse(this Canvas canvas, Rect rect, ShapeStyle shapeStyle)
        {
            return AddEllipse(canvas, rect.Left, rect.Top, rect.Width, rect.Height, shapeStyle);
        }

        #endregion

        #region Line

        public static Line AddLine(this Canvas canvas, double x1, double y1, double x2, double y2, ShapeStyle shapeStyle)
        {
            Line line = new Line()
                {
                    X1 = x1,
                    Y1 = y1,
                    X2 = x2,
                    Y2 = y2
                };
            line.UpdateShape(shapeStyle);

            canvas.Children.Add(line);
            return line;
        }

        public static Line AddLine(this Canvas canvas, Point p1, Point p2, ShapeStyle shapeStyle)
        {
            return AddLine(canvas, p1.X, p1.Y, p2.X, p2.Y, shapeStyle);
        }

        #endregion

        #region Polygon

        public static Polygon AddPolygon(this Canvas canvas, ShapeStyle shapeStyle, params Point[] points)
        {
            Polygon polygon = new Polygon();
            foreach (var point in points)
            {
                polygon.Points.Add(point);
            }
            polygon.UpdateShape(shapeStyle);

            canvas.Children.Add(polygon);
            return polygon;
        }

        #endregion

        #region Polyline

        public static Polyline AddPolyline(this Canvas canvas, ShapeStyle shapeStyle, params Point[] points)
        {
            Polyline polyline = new Polyline();
            foreach (var point in points)
            {
                polyline.Points.Add(point);
            }
            polyline.UpdateShape(shapeStyle);

            canvas.Children.Add(polyline);
            return polyline;
        }

        #endregion

        #region Text

        public static TextBlock AddText(this Canvas canvas, double x, double y, double width, double height, String text, TextStyle textStyle)
        {
            TextBlock textBlock = new TextBlock()
                {
                    Width = width,
                    Height = height,
                    Text = text,
                    Foreground = textStyle.TextColor,
                    FontSize = textStyle.FontSize,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = textStyle.Alignment,
                    VerticalAlignment = VerticalAlignment.Center
                };
            if (textStyle.Bold)
            {
                textBlock.FontWeight = FontWeights.Bold;
            }
            if (textStyle.Italic)
            {
                textBlock.FontStyle = FontStyles.Italic;
            }
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);

            canvas.Children.Add(textBlock);
            return textBlock;
        }

        public static TextBlock AddText(this Canvas canvas, Point position, Size size, String text, TextStyle textStyle)
        {
            return AddText(canvas, position.X, position.Y, size.Width, size.Height, text, textStyle);
        }

        public static TextBlock AddText(this Canvas canvas, Rect rect, String text, TextStyle textStyle)
        {
            return AddText(canvas, rect.Left, rect.Top, rect.Width, rect.Height, text, textStyle);
        }

        #endregion

        #region UIElement

        public static void AddUIElement(this Canvas canvas, double x, double y, UIElement element)
        {
            Canvas.SetLeft(element, x);
            Canvas.SetTop(element, y);

            canvas.Children.Add(element);
        }

        public static void AddUIElement(this Canvas canvas, Point location, UIElement element)
        {
            AddUIElement(canvas, location.X, location.Y, element);
        }

        #endregion

        #region FrameworkElement

        public static void AddFrameworkElement(this Canvas canvas, double x, double y, double width, double height, FrameworkElement element)
        {
            element.Width = width;
            element.Height = height;
            Canvas.SetLeft(element, x);
            Canvas.SetTop(element, y);

            canvas.Children.Add(element);
        }

        public static void AddFrameworkElement(this Canvas canvas, Point location, Size size, FrameworkElement element)
        {
            AddFrameworkElement(canvas, location.X, location.Y, size.Width, size.Height, element);
        }

        public static void AddFrameworkElement(this Canvas canvas, Rect bounds, FrameworkElement element)
        {
            AddFrameworkElement(canvas, bounds.Location, bounds.Size, element);
        }

        #endregion

        #region Save

        public static void SaveAsImage(this Canvas canvas, Stream stream, BitmapEncoding encoding)
        {
            canvas.SaveAsImage(stream, encoding, (int) canvas.Width, (int) canvas.Height);
        }

        #endregion
    }

    /// @}
}
