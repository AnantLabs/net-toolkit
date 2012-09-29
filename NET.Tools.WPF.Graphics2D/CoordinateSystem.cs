using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NET.Tools;

namespace NET.Tools.WPF
{
    public class CoordinateSystem : FrameworkElement
    {
        #region Appearance

        public static readonly DependencyProperty GraphLinePen1Property =
            DependencyProperty.Register("GraphLinePen1", typeof (Pen), typeof (CoordinateSystem),
                                        new PropertyMetadata(new Pen(Brushes.Red, 1.5d)));

        [Browsable(true)]
        [Category("Appearance")]
        public Pen GraphLinePen1
        {
            get { return (Pen) GetValue(GraphLinePen1Property); }
            set { SetValue(GraphLinePen1Property, value); }
        }

        public static readonly DependencyProperty GraphLinePen2Property =
            DependencyProperty.Register("GraphLinePen2", typeof (Pen), typeof (CoordinateSystem),
                                        new PropertyMetadata(new Pen(Brushes.Blue, 1.5d)));

        [Browsable(true)]
        [Category("Appearance")]
        public Pen GraphLinePen2
        {
            get { return (Pen) GetValue(GraphLinePen2Property); }
            set { SetValue(GraphLinePen2Property, value); }
        }

        public static readonly DependencyProperty GraphLinePen3Property =
            DependencyProperty.Register("GraphLinePen3", typeof (Pen), typeof (CoordinateSystem),
                                        new PropertyMetadata(new Pen(Brushes.Green, 1.5d)));

        [Browsable(true)]
        [Category("Appearance")]
        public Pen GraphLinePen3
        {
            get { return (Pen) GetValue(GraphLinePen3Property); }
            set { SetValue(GraphLinePen3Property, value); }
        }

        public static readonly DependencyProperty GraphLinePen4Property =
            DependencyProperty.Register("GraphLinePen4", typeof (Pen), typeof (CoordinateSystem),
                                        new PropertyMetadata(new Pen(Brushes.Gold, 1.5d)));

        [Browsable(true)]
        [Category("Appearance")]
        public Pen GraphLinePen4
        {
            get { return (Pen) GetValue(GraphLinePen4Property); }
            set { SetValue(GraphLinePen4Property, value); }
        }

        public static readonly DependencyProperty GraphLinePen5Property =
            DependencyProperty.Register("GraphLinePen5", typeof (Pen), typeof (CoordinateSystem),
                                        new PropertyMetadata(new Pen(Brushes.Black, 1.5d)));

        [Browsable(true)]
        [Category("Appearance")]
        public Pen GraphLinePen5
        {
            get { return (Pen) GetValue(GraphLinePen5Property); }
            set { SetValue(GraphLinePen5Property, value); }
        }

        public static readonly DependencyProperty GridBrushProperty =
            DependencyProperty.Register("GridBrush", typeof (Brush), typeof (CoordinateSystem),
                                        new PropertyMetadata(Brushes.Silver));

        [Browsable(true)]
        [Category("Appearance")]
        public Brush GridBrush
        {
            get { return (Brush) GetValue(GridBrushProperty); }
            set { SetValue(GridBrushProperty, value); }
        }

        public static readonly DependencyProperty ShowGridLinesProperty =
            DependencyProperty.Register("ShowGridLines", typeof (bool), typeof (CoordinateSystem),
                                        new PropertyMetadata(false));

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGridLines
        {
            get { return (bool) GetValue(ShowGridLinesProperty); }
            set { SetValue(ShowGridLinesProperty, value); }
        }

        public static readonly DependencyProperty MainLineBrushProperty =
            DependencyProperty.Register("MainLineBrush", typeof (Brush), typeof (CoordinateSystem),
                                        new PropertyMetadata(Brushes.Black));

        [Browsable(true)]
        [Category("Appearance")]
        public Brush MainLineBrush
        {
            get { return (Brush) GetValue(MainLineBrushProperty); }
            set { SetValue(MainLineBrushProperty, value); }
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof (Brush), typeof (CoordinateSystem),
                                        new PropertyMetadata(Brushes.Black));

        [Browsable(true)]
        [Category("Appearance")]
        public Brush Foreground
        {
            get { return (Brush) GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof (Brush), typeof (CoordinateSystem),
                                        new PropertyMetadata(Brushes.White));

        [Browsable(true)]
        [Category("Appearance")]
        public Brush Background
        {
            get { return (Brush) GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public static readonly DependencyProperty ShowMainLinesProperty =
            DependencyProperty.Register("ShowMainLines", typeof (bool), typeof (CoordinateSystem),
                                        new PropertyMetadata(true));

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowMainLines
        {
            get { return (bool) GetValue(ShowMainLinesProperty); }
            set { SetValue(ShowMainLinesProperty, value); }
        }

        public static readonly DependencyProperty GridLineTickHorizontalProperty =
            DependencyProperty.Register("GridLineTickHorizontal", typeof (double), typeof (CoordinateSystem),
                                        new PropertyMetadata(1d));

        [Browsable(true)]
        [Category("Appearance")]
        public double GridLineTickHorizontal
        {
            get { return (double) GetValue(GridLineTickHorizontalProperty); }
            set { SetValue(GridLineTickHorizontalProperty, value); }
        }

        public static readonly DependencyProperty GridLineTickVerticalProperty =
            DependencyProperty.Register("GridLineTickVertical", typeof (double), typeof (CoordinateSystem),
                                        new PropertyMetadata(1d));

        [Browsable(true)]
        [Category("Appearance")]
        public double GridLineTickVertical
        {
            get { return (double) GetValue(GridLineTickVerticalProperty); }
            set { SetValue(GridLineTickVerticalProperty, value); }
        }

        public static readonly DependencyProperty ShowGraphLine1Property =
            DependencyProperty.Register("ShowGraphLine1", typeof (bool), typeof (CoordinateSystem), new PropertyMetadata(true));

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGraphLine1
        {
            get { return (bool) GetValue(ShowGraphLine1Property); }
            set { SetValue(ShowGraphLine1Property, value); }
        }

        public static readonly DependencyProperty ShowGraphLine2Property =
            DependencyProperty.Register("ShowGraphLine2", typeof (bool), typeof (CoordinateSystem), new PropertyMetadata(false));

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGraphLine2
        {
            get { return (bool) GetValue(ShowGraphLine2Property); }
            set { SetValue(ShowGraphLine2Property, value); }
        }

        public static readonly DependencyProperty ShowGraphLine3Property =
            DependencyProperty.Register("ShowGraphLine3", typeof (bool), typeof (CoordinateSystem), new PropertyMetadata(false));

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGraphLine3
        {
            get { return (bool) GetValue(ShowGraphLine3Property); }
            set { SetValue(ShowGraphLine3Property, value); }
        }

        public static readonly DependencyProperty ShowGraphLine4Property =
            DependencyProperty.Register("ShowGraphLine4", typeof (bool), typeof (CoordinateSystem), new PropertyMetadata(false));

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGraphLine4
        {
            get { return (bool) GetValue(ShowGraphLine4Property); }
            set { SetValue(ShowGraphLine4Property, value); }
        }

        public static readonly DependencyProperty ShowGraphLine5Property =
            DependencyProperty.Register("ShowGraphLine5", typeof (bool), typeof (CoordinateSystem), new PropertyMetadata(false));

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowGraphLine5
        {
            get { return (bool) GetValue(ShowGraphLine5Property); }
            set { SetValue(ShowGraphLine5Property, value); }
        }

        #endregion

        #region Math

        public static readonly DependencyProperty CalculationFormula1Property =
            DependencyProperty.Register("CalculationFormula1", typeof (String), typeof (CoordinateSystem),
                                        new PropertyMetadata("x"));

        [Browsable(true)]
        [Category("Math")]
        public String CalculationFormula1
        {
            get { return (String) GetValue(CalculationFormula1Property); }
            set { SetValue(CalculationFormula1Property, value); }
        }

        public static readonly DependencyProperty CalculationFormula2Property =
            DependencyProperty.Register("CalculationFormula2", typeof (String), typeof (CoordinateSystem),
                                        new PropertyMetadata("-x"));

        [Browsable(true)]
        [Category("Math")]
        public String CalculationFormula2
        {
            get { return (String) GetValue(CalculationFormula2Property); }
            set { SetValue(CalculationFormula2Property, value); }
        }

        public static readonly DependencyProperty CalculationFormula3Property =
            DependencyProperty.Register("CalculationFormula3", typeof (String), typeof (CoordinateSystem),
                                        new PropertyMetadata("x^2"));

        [Browsable(true)]
        [Category("Math")]
        public String CalculationFormula3
        {
            get { return (String) GetValue(CalculationFormula3Property); }
            set { SetValue(CalculationFormula3Property, value); }
        }

        public static readonly DependencyProperty CalculationFormula4Property =
            DependencyProperty.Register("CalculationFormula4", typeof (String), typeof (CoordinateSystem),
                                        new PropertyMetadata("-x^2"));

        [Browsable(true)]
        [Category("Math")]
        public String CalculationFormula4
        {
            get { return (String) GetValue(CalculationFormula4Property); }
            set { SetValue(CalculationFormula4Property, value); }
        }

        public static readonly DependencyProperty CalculationFormula5Property =
            DependencyProperty.Register("CalculationFormula5", typeof (String), typeof (CoordinateSystem),
                                        new PropertyMetadata("1"));

        [Browsable(true)]
        [Category("Math")]
        public String CalculationFormula5
        {
            get { return (String) GetValue(CalculationFormula5Property); }
            set { SetValue(CalculationFormula5Property, value); }
        }

        public static readonly DependencyProperty DimensionLeftProperty =
            DependencyProperty.Register("DimensionLeft", typeof (double), typeof (CoordinateSystem),
                                        new PropertyMetadata(-10d));

        [Browsable(true)]
        [Category("Math")]
        public double DimensionLeft
        {
            get { return (double) GetValue(DimensionLeftProperty); }
            set { SetValue(DimensionLeftProperty, value); }
        }

        public static readonly DependencyProperty DimensionTopProperty =
            DependencyProperty.Register("DimensionTop", typeof (double), typeof (CoordinateSystem),
                                        new PropertyMetadata(10d));

        [Browsable(true)]
        [Category("Math")]
        public double DimensionTop
        {
            get { return (double) GetValue(DimensionTopProperty); }
            set { SetValue(DimensionTopProperty, value); }
        }

        public static readonly DependencyProperty DimensionRightProperty =
            DependencyProperty.Register("DimensionRight", typeof (double), typeof (CoordinateSystem),
                                        new PropertyMetadata(10d));

        [Browsable(true)]
        [Category("Math")]
        public double DimensionRight
        {
            get { return (double) GetValue(DimensionRightProperty); }
            set { SetValue(DimensionRightProperty, value); }
        }

        public static readonly DependencyProperty DimensionBottomProperty =
            DependencyProperty.Register("DimensionBottom", typeof (double), typeof (CoordinateSystem),
                                        new PropertyMetadata(-10d));

        [Browsable(true)]
        [Category("Math")]
        public double DimensionBottom
        {
            get { return (double) GetValue(DimensionBottomProperty); }
            set { SetValue(DimensionBottomProperty, value); }
        }

        public static readonly DependencyProperty GraphLineTickProperty =
            DependencyProperty.Register("GraphLineTick", typeof (double), typeof (CoordinateSystem),
                                        new PropertyMetadata(0.1d));

        [Browsable(true)]
        [Category("Math")]
        public double GraphLineTick
        {
            get { return (double) GetValue(GraphLineTickProperty); }
            set { SetValue(GraphLineTickProperty, value); }
        }

        #endregion

        //***********************************************************************************************
        //***********************************************************************************************
        //***********************************************************************************************
        //***********************************************************************************************
        //***********************************************************************************************

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Background, null, new Rect(new Size(ActualWidth, ActualHeight)));
            drawingContext.PushClip(new RectangleGeometry(new Rect(new Size(ActualWidth, ActualHeight))));

            DrawMainLines(drawingContext);
            DrawGridLines(drawingContext);
            DrawAllGraphLines(drawingContext);
        }

        private void DrawAllGraphLines(DrawingContext drawingContext)
        {
            if (ShowGraphLine1)
            {
                DrawGraphLine(drawingContext, CalculationFormula1, GraphLinePen1);
            }
            if (ShowGraphLine2)
            {
                DrawGraphLine(drawingContext, CalculationFormula2, GraphLinePen2);
            }
            if (ShowGraphLine3)
            {
                DrawGraphLine(drawingContext, CalculationFormula3, GraphLinePen3);
            }
            if (ShowGraphLine4)
            {
                DrawGraphLine(drawingContext, CalculationFormula4, GraphLinePen4);
            }
            if (ShowGraphLine5)
            {
                DrawGraphLine(drawingContext, CalculationFormula5, GraphLinePen5);
            }
        }

        private void DrawMainLines(DrawingContext drawingContext)
        {
            if (ShowMainLines)
            {
                Pen pen = new Pen(MainLineBrush, 2.5d);

                double height = Calculate(DimensionBottom, DimensionTop, 0, ActualHeight);
                if (height >= 0 && height <= ActualHeight)
                {
                    drawingContext.DrawLine(pen, new Point(0, height),
                                            new Point(ActualWidth, height));
                }

                double width = Calculate(DimensionRight, DimensionLeft, 0, ActualWidth);
                if (width >= 0 && width <= ActualWidth)
                {
                    drawingContext.DrawLine(pen, new Point(width, 0),
                                            new Point(width, ActualHeight));
                }
            }
        }

        private void DrawGridLines(DrawingContext drawingContext)
        {
            if (ShowGridLines)
            {
                Pen pen = new Pen(GridBrush, 1d)
                    {
                        DashStyle = DashStyles.Dash
                    };

                for (double i = DimensionLeft; i <= DimensionRight; i += GridLineTickHorizontal)
                {
                    if (i == 0.0d)
                        continue;

                    double width = Calculate(DimensionRight, DimensionLeft, i, ActualWidth);
                    drawingContext.DrawLine(pen, new Point(width, 0), new Point(width, ActualHeight));
                }
                for (double i = DimensionBottom; i <= DimensionTop; i += GridLineTickVertical)
                {
                    if (i == 0.0d)
                        continue;

                    double height = Calculate(DimensionBottom, DimensionTop, i, ActualHeight);
                    drawingContext.DrawLine(pen, new Point(0, height), new Point(ActualWidth, height));
                }
            }
        }

        private void DrawGraphLine(DrawingContext drawingContext, String formula, Pen pen)
        {
            PathFigure funcLine = new PathFigure
                {
                    IsClosed = false,
                    IsFilled = false
                };
            bool first = true;
            for (double x = DimensionLeft; x <= DimensionRight; x += GraphLineTick)
            {
                IDictionary<string, double> numbers = new Dictionary<string, double>();
                numbers.Add("x", x);

                double y = formula.ParseCalculationString(numbers);
                double height = Calculate(DimensionBottom, DimensionTop, y, ActualHeight);
                double width = Calculate(DimensionRight, DimensionLeft, x, ActualWidth);

                if (first)
                    funcLine.StartPoint = new Point(width, height);
                else
                    funcLine.Segments.Add(new LineSegment(new Point(width, height), true));

                first = false;
            }
            drawingContext.DrawGeometry(null, pen, new PathGeometry {Figures = {funcLine}});
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == GraphLinePen1Property ||
                e.Property == GraphLinePen2Property ||
                e.Property == GraphLinePen3Property ||
                e.Property == GraphLinePen4Property ||
                e.Property == GraphLinePen5Property ||
                e.Property == ShowGraphLine1Property ||
                e.Property == ShowGraphLine2Property ||
                e.Property == ShowGraphLine3Property ||
                e.Property == ShowGraphLine4Property ||
                e.Property == ShowGraphLine5Property ||
                e.Property == GraphLineTickProperty ||
                e.Property == GridBrushProperty ||
                e.Property == GraphLineTickProperty ||
                e.Property == GridLineTickHorizontalProperty ||
                e.Property == GridLineTickVerticalProperty ||
                e.Property == ShowGridLinesProperty ||
                e.Property == ShowMainLinesProperty ||
                e.Property == MainLineBrushProperty ||
                e.Property == ForegroundProperty ||
                e.Property == BackgroundProperty ||
                e.Property == CalculationFormula1Property ||
                e.Property == CalculationFormula2Property ||
                e.Property == CalculationFormula3Property ||
                e.Property == CalculationFormula4Property ||
                e.Property == CalculationFormula5Property ||
                e.Property == DimensionLeftProperty ||
                e.Property == DimensionRightProperty ||
                e.Property == DimensionTopProperty ||
                e.Property == DimensionBottomProperty)
            {
                InvalidateVisual();
            }
        }

        private static double Calculate(double min, double max, double value, double pixelLength)
        {
            double dif = max - min;
            return pixelLength * (max - value) / dif;
        }
    }
}
