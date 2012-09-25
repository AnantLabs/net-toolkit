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
    public abstract class Shape2D : FrameworkElement
    {
        public static readonly DependencyProperty HiddenLineStyleProperty =
            DependencyProperty.Register("HiddenLineStyle", typeof(HiddenLineStyle), typeof(Cube2D), new PropertyMetadata(HiddenLineStyle.Dash));

        [Browsable(true)]
        [Category("Shape 2D")]
        public HiddenLineStyle HiddenLineStyle
        {
            get { return (HiddenLineStyle)GetValue(HiddenLineStyleProperty); }
            set { SetValue(HiddenLineStyleProperty, value); }
        }

        public static readonly DependencyProperty CameraPositionProperty =
            DependencyProperty.Register("CameraPosition", typeof (Shape2DCameraPosition), typeof (Shape2D), new PropertyMetadata(Shape2DCameraPosition.TopLeft));

        [Browsable(true)]
        [Category("Shape 2D")]
        public Shape2DCameraPosition CameraPosition
        {
            get { return (Shape2DCameraPosition) GetValue(CameraPositionProperty); }
            set { SetValue(CameraPositionProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof (Brush), typeof (Shape2D), new PropertyMetadata(Brushes.White));

        [Browsable(true)]
        [Category("Shape 2D")]
        public Brush Fill
        {
            get { return (Brush) GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof (Brush), typeof (Shape2D), new PropertyMetadata(Brushes.Black));

        [Browsable(true)]
        [Category("Shape 2D")]
        public Brush Stroke
        {
            get { return (Brush) GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof (double), typeof (Shape2D), new PropertyMetadata(1d));

        [Browsable(true)]
        [Category("Shape 2D")]
        public double StrokeThickness
        {
            get { return (double) GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeLineCapProperty =
            DependencyProperty.Register("StrokeLineCap", typeof (PenLineCap), typeof (Shape2D), new PropertyMetadata(default(PenLineCap)));

        [Browsable(true)]
        [Category("Shape 2D")]
        public PenLineCap StrokeLineCap
        {
            get { return (PenLineCap) GetValue(StrokeLineCapProperty); }
            set { SetValue(StrokeLineCapProperty, value); }
        }

        protected abstract Drawing Drawing { get; }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawDrawing(Drawing);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == HiddenLineStyleProperty ||
                e.Property == FillProperty ||
                e.Property == StrokeLineCapProperty ||
                e.Property == StrokeProperty ||
                e.Property == StrokeThicknessProperty)
            {
                InvalidateVisual();
            }
        }
    }
}
