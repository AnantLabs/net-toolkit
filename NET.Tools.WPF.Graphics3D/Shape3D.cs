using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using NET.Tools.Extensions;

namespace NET.Tools.WPF
{
    public abstract class Shape3D : UserControl
    {
        public static readonly DependencyProperty ScaleProperty =
            DependencyProperty.Register("Scale", typeof (Vector3D), typeof (Shape3D), new PropertyMetadata(new Vector3D(1,1,1)));

        [Browsable(true)]
        [Category("Transform 3D")]
        public Vector3D Scale
        {
            get { return (Vector3D) GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        public static readonly DependencyProperty TextureCoordinationMultiplyFactorProperty =
            DependencyProperty.Register("TextureCoordinationMultiplyFactor", typeof (Point), typeof (Shape3D), new PropertyMetadata(new Point(1,1)));

        [Browsable(true)]
        [Category("Material 3D")]
        public Point TextureCoordinationMultiplyFactor
        {
            get { return (Point) GetValue(TextureCoordinationMultiplyFactorProperty); }
            set { SetValue(TextureCoordinationMultiplyFactorProperty, value); }
        }

        public static readonly DependencyProperty TextureCoordinationTransformFactorProperty =
            DependencyProperty.Register("TextureCoordinationTransformFactor", typeof (Point), typeof (Shape3D), new PropertyMetadata(new Point(0,0)));

        [Browsable(true)]
        [Category("Material 3D")]
        public Point TextureCoordinationTransformFactor
        {
            get { return (Point) GetValue(TextureCoordinationTransformFactorProperty); }
            set { SetValue(TextureCoordinationTransformFactorProperty, value); }
        }

        public static readonly DependencyProperty CameraPositionProperty =
            DependencyProperty.Register("CameraPosition", typeof(Point3D), typeof(Shape3D),
                                        new PropertyMetadata(new Point3D(0d, 0d, 4d)));

        [Browsable(true)]
        [Category("Camera 3D")]
        public Point3D CameraPosition
        {
            get { return (Point3D) GetValue(CameraPositionProperty); }
            set { SetValue(CameraPositionProperty, value); }
        }

        public static readonly DependencyProperty CameraLookAtPositionProperty =
            DependencyProperty.Register("CameraLookAtPosition", typeof (Point3D), typeof (Shape3D), new PropertyMetadata(new Point3D(0,0,0)));

        [Browsable(true)]
        [Category("Camera 3D")]
        public Point3D CameraLookAtPosition
        {
            get { return (Point3D) GetValue(CameraLookAtPositionProperty); }
            set { SetValue(CameraLookAtPositionProperty, value); }
        }

        public static readonly DependencyProperty LightingProperty =
            DependencyProperty.Register("Lighting", typeof (bool), typeof (Shape3D), new PropertyMetadata(true));

        [Browsable(true)]
        [Category("Light 3D")]
        public bool Lighting
        {
            get { return (bool) GetValue(LightingProperty); }
            set { SetValue(LightingProperty, value); }
        }

        public static readonly DependencyProperty DiffuseBrushProperty =
            DependencyProperty.Register("DiffuseBrush", typeof (Brush), typeof (Shape3D), new PropertyMetadata(Brushes.White));

        [Browsable(true)]
        [Category("Material 3D")]
        public Brush DiffuseBrush
        {
            get { return (Brush) GetValue(DiffuseBrushProperty); }
            set { SetValue(DiffuseBrushProperty, value); }
        }

        public static readonly DependencyProperty EmissiveBrushProperty =
            DependencyProperty.Register("EmissiveBrush", typeof (Brush), typeof (Shape3D), new PropertyMetadata(null));

        [Browsable(true)]
        [Category("Material 3D")]
        public Brush EmissiveBrush
        {
            get { return (Brush) GetValue(EmissiveBrushProperty); }
            set { SetValue(EmissiveBrushProperty, value); }
        }

        public static readonly DependencyProperty SpecularBrushProperty =
            DependencyProperty.Register("SpecularBrush", typeof (Brush), typeof (Shape3D), new PropertyMetadata(null));

        [Browsable(true)]
        [Category("Material 3D")]
        public Brush SpecularBrush
        {
            get { return (Brush) GetValue(SpecularBrushProperty); }
            set { SetValue(SpecularBrushProperty, value); }
        }

        public static readonly DependencyProperty SpecularPowerProperty =
            DependencyProperty.Register("SpecularPower", typeof (double), typeof (Shape3D), new PropertyMetadata(1d));

        [Browsable(true)]
        [Category("Material 3D")]
        public double SpecularPower
        {
            get { return (double) GetValue(SpecularPowerProperty); }
            set { SetValue(SpecularPowerProperty, value); }
        }

        public static readonly DependencyProperty LightDirectionProperty =
            DependencyProperty.Register("LightDirection", typeof (Vector3D), typeof (Shape3D), new PropertyMetadata(new Vector3D(0,0,-1)));

        [Browsable(true)]
        [Category("Light 3D")]
        public Vector3D LightDirection
        {
            get { return (Vector3D) GetValue(LightDirectionProperty); }
            set { SetValue(LightDirectionProperty, value); }
        }

        public static readonly DependencyProperty LightColorProperty =
            DependencyProperty.Register("LightColor", typeof (Color), typeof (Shape3D), new PropertyMetadata(Colors.White));

        [Browsable(true)]
        [Category("Light 3D")]
        public Color LightColor
        {
            get { return (Color) GetValue(LightColorProperty); }
            set { SetValue(LightColorProperty, value); }
        }

        public static readonly DependencyProperty RotationAxisVectorProperty =
            DependencyProperty.Register("RotationAxisVector", typeof (Vector3D), typeof (Shape3D), new PropertyMetadata(new Vector3D(0,1,0)));

        [Browsable(true)]
        [Category("Transform 3D")]
        public Vector3D RotationAxisVector
        {
            get { return (Vector3D) GetValue(RotationAxisVectorProperty); }
            set { SetValue(RotationAxisVectorProperty, value); }
        }

        public static readonly DependencyProperty RotationAngleProperty =
            DependencyProperty.Register("RotationAngle", typeof (double), typeof (Shape3D), new PropertyMetadata(0d));

        [Browsable(true)]
        [Category("Transform 3D")]
        public double RotationAngle
        {
            get { return (double) GetValue(RotationAngleProperty); }
            set { SetValue(RotationAngleProperty, value); }
        }

        public static readonly DependencyProperty TranslationProperty =
            DependencyProperty.Register("Translation", typeof (Vector3D), typeof (Shape3D), new PropertyMetadata(new Vector3D(0,0,0)));

        [Browsable(true)]
        [Category("Transform 3D")]
        public Vector3D Translation
        {
            get { return (Vector3D) GetValue(TranslationProperty); }
            set { SetValue(TranslationProperty, value); }
        }

        private Viewport3D viewport;
        private ModelVisual3D light;
        private IList<ModelVisual3D> models = new List<ModelVisual3D>(); 

        protected Shape3D()
        {
            PerspectiveCamera camera = new PerspectiveCamera
                {
                    Position = CameraPosition
                };
            camera.SetLookAtPosition(CameraLookAtPosition);

            viewport = new Viewport3D
                {
                    Camera = camera
                };

            light = new ModelVisual3D
            {
                Content = new DirectionalLight(LightColor, LightDirection)
            };
            viewport.Children.Add(light);

            RebuildModel();

            Content = viewport;
        }

        protected abstract IList<MeshGeometry3D> Meshes { get; }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == CameraPositionProperty ||
                e.Property == CameraLookAtPositionProperty)
            {
                viewport.Camera = new PerspectiveCamera
                    {
                        Position = CameraPosition
                    };
                (viewport.Camera as PerspectiveCamera).SetLookAtPosition(CameraLookAtPosition);

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
            else if (e.Property == RotationAngleProperty ||
                e.Property == RotationAxisVectorProperty ||
                e.Property == ScaleProperty ||
                e.Property == TranslationProperty)
            {
                Transform3DGroup transform3DGroup = new Transform3DGroup();
                transform3DGroup.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(RotationAxisVector, RotationAngle)));
                transform3DGroup.Children.Add(new ScaleTransform3D(Scale));
                transform3DGroup.Children.Add(new TranslateTransform3D(Translation));

                foreach (ModelVisual3D model in models)
                {
                    model.Transform = transform3DGroup;
                }

                InvalidateVisual();
            }
            else if (e.Property == DiffuseBrushProperty ||
                e.Property == EmissiveBrushProperty ||
                e.Property == SpecularBrushProperty ||
                e.Property == SpecularPowerProperty)
            {
                foreach (ModelVisual3D model in models)
                {
                    MaterialGroup material = new MaterialGroup();
                    if (DiffuseBrush != null)
                    {
                        material.Children.Add(new DiffuseMaterial(DiffuseBrush));
                    }
                    if (EmissiveBrush != null)
                    {
                        material.Children.Add(new EmissiveMaterial(EmissiveBrush));
                    }
                    if (SpecularBrush != null)
                    {
                        material.Children.Add(new SpecularMaterial(SpecularBrush, SpecularPower));
                    }

                    (model.Content as GeometryModel3D).Material = material;
                }

                InvalidateVisual();
            }
            else if (e.Property == LightColorProperty ||
                e.Property == LightDirectionProperty)
            {
                light.Content = new DirectionalLight(LightColor, LightDirection);
                InvalidateVisual();
            }
            else if (e.Property == TextureCoordinationMultiplyFactorProperty ||
                e.Property == TextureCoordinationTransformFactorProperty)
            {
                RebuildModel();
                InvalidateVisual();
            }
        }

        protected void RebuildModel()
        {
            foreach (ModelVisual3D model in models)
            {
                viewport.Children.Remove(model);
            }
            models.Clear();

            foreach (MeshGeometry3D mesh in Meshes)
            {
                Transform3DGroup transform3DGroup = new Transform3DGroup();
                transform3DGroup.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(RotationAxisVector, RotationAngle)));
                transform3DGroup.Children.Add(new ScaleTransform3D(Scale));
                transform3DGroup.Children.Add(new TranslateTransform3D(Translation));


                GeometryModel3D geometryModel = new GeometryModel3D(mesh, new DiffuseMaterial(DiffuseBrush));
                ModelVisual3D visualModel = new ModelVisual3D
                {
                    Content = geometryModel,
                    Transform = transform3DGroup
                };

                models.Add(visualModel);
                viewport.Children.Add(visualModel);
            }
        }
    }
}
