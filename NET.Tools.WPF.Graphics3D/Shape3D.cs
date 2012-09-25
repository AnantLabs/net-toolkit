using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace NET.Tools.WPF
{
    public abstract class Shape3D : UserControl
    {
        public static readonly DependencyProperty CameraPositionProperty =
            DependencyProperty.Register("CameraPosition", typeof(Point3D), typeof(Shape3D),
                                        new PropertyMetadata(new Point3D(0.5d, 0.5d, 4d)));

        public Point3D CameraPosition
        {
            get { return (Point3D) GetValue(CameraPositionProperty); }
            set { SetValue(CameraPositionProperty, value); }
        }

        public static readonly DependencyProperty LightingProperty =
            DependencyProperty.Register("Lighting", typeof (bool), typeof (Shape3D), new PropertyMetadata(true));

        public bool Lighting
        {
            get { return (bool) GetValue(LightingProperty); }
            set { SetValue(LightingProperty, value); }
        }

        public static readonly DependencyProperty DiffuseBrushProperty =
            DependencyProperty.Register("DiffuseBrush", typeof (Brush), typeof (Shape3D), new PropertyMetadata(Brushes.White));

        public Brush DiffuseBrush
        {
            get { return (Brush) GetValue(DiffuseBrushProperty); }
            set { SetValue(DiffuseBrushProperty, value); }
        }

        public static readonly DependencyProperty ObjectTransformationProperty =
            DependencyProperty.Register("ObjectTransformation", typeof (Transform3D), typeof (Shape3D), new PropertyMetadata(Transform3D.Identity));

        public Transform3D ObjectTransformation
        {
            get { return (Transform3D) GetValue(ObjectTransformationProperty); }
            set { SetValue(ObjectTransformationProperty, value); }
        }

        private Viewport3D viewport;
        private ModelVisual3D light;

        protected Shape3D()
        {
            viewport = new Viewport3D
                {
                    Camera = new PerspectiveCamera()
                        {
                            Position = CameraPosition,
                            LookDirection = new Vector3D(0,0,-1)
                        }
                };

            light = new ModelVisual3D
            {
                Content = new DirectionalLight(Colors.White, new Vector3D(0,0,-1))
            };
            viewport.Children.Add(light);

            foreach (Visual3D visual in Visuals)
            {
                viewport.Children.Add(visual);
            }

            Content = viewport;
        }

        protected abstract IList<Visual3D> Visuals { get; }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == CameraPositionProperty)
            {
                viewport.Camera = new PerspectiveCamera(CameraPosition, new Vector3D(0, 0, 0), new Vector3D(0, 1, 0),
                                                        Math.PI/4d);
                InvalidateVisual();
            }
            else if (e.Property == LightingProperty)
            {
                if (e.NewValue == e.OldValue)
                    return;

                if (Lighting)
                {
                    viewport.Children.Add(light);
                }
                else
                {
                    viewport.Children.Remove(light);
                }

                InvalidateVisual();
            }
        }
    }
}
