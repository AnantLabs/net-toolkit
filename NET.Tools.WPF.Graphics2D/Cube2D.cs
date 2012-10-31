using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NET.Tools.WPF
{
    public sealed class Cube2D : Shape2D
    {
        public static readonly DependencyProperty DepthProperty =
            DependencyProperty.Register("Depth", typeof (double), typeof (Cube2D), new PropertyMetadata(25d));

        [Browsable(true)]
        [Category("Shape 2D")]
        public double Depth
        {
            get { return (double) GetValue(DepthProperty); }
            set { SetValue(DepthProperty, value); }
        }

        public static readonly DependencyProperty HorizontalFillProperty =
            DependencyProperty.Register("HorizontalFill", typeof (Brush), typeof (Cube2D), new PropertyMetadata(null));

        [Browsable(true)]
        [Category("Shape 2D")]
        public Brush HorizontalFill
        {
            get { return (Brush) GetValue(HorizontalFillProperty); }
            set { SetValue(HorizontalFillProperty, value); }
        }

        public static readonly DependencyProperty VerticalFillProperty =
            DependencyProperty.Register("VerticalFill", typeof (Brush), typeof (Cube2D), new PropertyMetadata(null));

        [Browsable(true)]
        [Category("Shape 2D")]
        public Brush VerticalFill
        {
            get { return (Brush) GetValue(VerticalFillProperty); }
            set { SetValue(VerticalFillProperty, value); }
        }

        protected override Drawing Drawing
        {
            get
            {
                DrawingGroup drawingGroup = new DrawingGroup();

                CreateBasicRectangle(drawingGroup);
                CreateHorizontalArea(drawingGroup);
                CreateVerticalArea(drawingGroup);
                CreateInvisibleLines(drawingGroup);

                return drawingGroup;
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == DepthProperty ||
                e.Property == HorizontalFillProperty ||
                e.Property == VerticalFillProperty)
            {
                InvalidateVisual();
            }
        }

        private void CreateInvisibleLines(DrawingGroup drawingGroup)
        {
            if (HiddenLineStyle == HiddenLineStyle.Invisible)
                return;

            Pen pen = null;
            if (Stroke != null)
            {
                pen = new Pen(Stroke, StrokeThickness)
                {
                    DashCap = StrokeLineCap,
                    StartLineCap = StrokeLineCap,
                    EndLineCap = StrokeLineCap
                };
                if (HiddenLineStyle == HiddenLineStyle.Dash)
                {
                    pen.DashStyle = DashStyles.Dash;
                }
            }

            GeometryGroup geometryGroup = new GeometryGroup();
            geometryGroup.Children.Add(new LineGeometry(new Point(0, Height), new Point(Depth/2, Height - Depth/2)));
            geometryGroup.Children.Add(new LineGeometry(new Point(Depth/2, Height - Depth/2), new Point(Depth/2, 0)));
            geometryGroup.Children.Add(new LineGeometry(new Point(Depth / 2, Height - Depth / 2), new Point(Width, Height - Depth / 2)));

            GeometryDrawing geometryDrawing = new GeometryDrawing(null, pen, geometryGroup);
            drawingGroup.Children.Add(geometryDrawing);
        }

        private void CreateHorizontalArea(DrawingGroup drawingGroup)
        {
            Pen pen = null;
            if (Stroke != null)
            {
                pen = new Pen(Stroke, StrokeThickness)
                {
                    DashCap = StrokeLineCap,
                    StartLineCap = StrokeLineCap,
                    EndLineCap = StrokeLineCap
                };
            }

            PathFigure pathFigure = new PathFigure
                {
                    IsClosed = true,
                    IsFilled = true,
                    StartPoint = new Point(0,Depth/2)
                };
            pathFigure.Segments.Add(new LineSegment(new Point(Depth/2, 0), true));
            pathFigure.Segments.Add(new LineSegment(new Point(Width, 0), true));
            pathFigure.Segments.Add(new LineSegment(new Point(Width - Depth/2, Depth/2), true));

            PathGeometry geometry = new PathGeometry();
            geometry.Figures.Add(pathFigure);

            GeometryDrawing geoDraw = new GeometryDrawing(HorizontalFill ?? Fill, pen, geometry);
            drawingGroup.Children.Add(geoDraw);
        }

        private void CreateVerticalArea(DrawingGroup drawingGroup)
        {
            Pen pen = null;
            if (Stroke != null)
            {
                pen = new Pen(Stroke, StrokeThickness)
                {
                    DashCap = StrokeLineCap,
                    StartLineCap = StrokeLineCap,
                    EndLineCap = StrokeLineCap
                };
            }

            PathFigure pathFigure = new PathFigure
            {
                IsClosed = true,
                IsFilled = true,
                StartPoint = new Point(Width - Depth / 2, Depth / 2)
            };
            pathFigure.Segments.Add(new LineSegment(new Point(Width, 0), true));
            pathFigure.Segments.Add(new LineSegment(new Point(Width, Height - Depth / 2), true));
            pathFigure.Segments.Add(new LineSegment(new Point(Width - Depth / 2, Height), true));

            PathGeometry geometry = new PathGeometry();
            geometry.Figures.Add(pathFigure);

            GeometryDrawing geoDraw = new GeometryDrawing(VerticalFill ?? Fill, pen, geometry);
            drawingGroup.Children.Add(geoDraw);
        }

        private void CreateBasicRectangle(DrawingGroup drawingGroup)
        {
            Pen pen = null;
            if (Stroke != null)
            {
                pen = new Pen(Stroke, StrokeThickness)
                    {
                        DashCap = StrokeLineCap,
                        StartLineCap = StrokeLineCap,
                        EndLineCap = StrokeLineCap
                    };
            }
            RectangleGeometry rectGeo = new RectangleGeometry(new Rect(0, Depth / 2, Width - Depth / 2, Height - Depth / 2));
            GeometryDrawing rectDraw = new GeometryDrawing(Fill, pen, rectGeo);
            drawingGroup.Children.Add(rectDraw);
        }
    }
}
