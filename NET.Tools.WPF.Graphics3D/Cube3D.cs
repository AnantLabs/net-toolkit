using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;

namespace NET.Tools.WPF
{
    public sealed class Cube3D : Shape3D
    {
        public static readonly DependencyProperty CubeWidthProperty =
            DependencyProperty.Register("CubeWidth", typeof (double), typeof (Cube3D), new PropertyMetadata(2d));

        public double CubeWidth
        {
            get { return (double) GetValue(CubeWidthProperty); }
            set { SetValue(CubeWidthProperty, value); }
        }

        public static readonly DependencyProperty CubeHeightProperty =
            DependencyProperty.Register("CubeHeight", typeof (double), typeof (Cube3D), new PropertyMetadata(2d));

        public double CubeHeight
        {
            get { return (double) GetValue(CubeHeightProperty); }
            set { SetValue(CubeHeightProperty, value); }
        }

        public static readonly DependencyProperty CubeDepthProperty =
            DependencyProperty.Register("CubeDepth", typeof (double), typeof (Cube3D), new PropertyMetadata(2d));

        public double CubeDepth
        {
            get { return (double) GetValue(CubeDepthProperty); }
            set { SetValue(CubeDepthProperty, value); }
        }

        private ModelVisual3D cubeModel;

        protected override IList<Visual3D> Visuals
        {
            get
            {
                IList<Visual3D> result = new List<Visual3D>();

                MeshGeometry3D cubeMesh = new MeshGeometry3D();
                cubeMesh.Positions.Add(new Point3D(0, 0, 1));
                cubeMesh.Positions.Add(new Point3D(1, 0, 1));
                cubeMesh.Positions.Add(new Point3D(1, 1, 1));
                cubeMesh.Positions.Add(new Point3D(0, 1, 1));
                cubeMesh.Positions.Add(new Point3D(1, 0, 0));
                cubeMesh.Positions.Add(new Point3D(0, 0, 0));
                cubeMesh.Positions.Add(new Point3D(0, 1, 0));
                cubeMesh.Positions.Add(new Point3D(1, 1, 0));
                cubeMesh.Positions.Add(new Point3D(1, 0, 1));
                cubeMesh.Positions.Add(new Point3D(1, 0, 0));
                cubeMesh.Positions.Add(new Point3D(1, 1, 0));
                cubeMesh.Positions.Add(new Point3D(1, 1, 1));
                cubeMesh.Positions.Add(new Point3D(0, 0, 0));
                cubeMesh.Positions.Add(new Point3D(0, 0, 1));
                cubeMesh.Positions.Add(new Point3D(0, 1, 1));
                cubeMesh.Positions.Add(new Point3D(0, 1, 0));
                cubeMesh.Positions.Add(new Point3D(0, 1, 1));
                cubeMesh.Positions.Add(new Point3D(1, 1, 1));
                cubeMesh.Positions.Add(new Point3D(1, 1, 0));
                cubeMesh.Positions.Add(new Point3D(0, 1, 0));
                cubeMesh.Positions.Add(new Point3D(1, 0, 1));
                cubeMesh.Positions.Add(new Point3D(0, 0, 1));
                cubeMesh.Positions.Add(new Point3D(0, 0, 0));
                cubeMesh.Positions.Add(new Point3D(1, 0, 0));
                //Indices
                cubeMesh.TriangleIndices.Add(0);
                cubeMesh.TriangleIndices.Add(1);
                cubeMesh.TriangleIndices.Add(2);
                //
                cubeMesh.TriangleIndices.Add(2);
                cubeMesh.TriangleIndices.Add(3);
                cubeMesh.TriangleIndices.Add(0);
                //
                cubeMesh.TriangleIndices.Add(4);
                cubeMesh.TriangleIndices.Add(5);
                cubeMesh.TriangleIndices.Add(6);
                //
                cubeMesh.TriangleIndices.Add(6);
                cubeMesh.TriangleIndices.Add(7);
                cubeMesh.TriangleIndices.Add(4);
                //
                cubeMesh.TriangleIndices.Add(8);
                cubeMesh.TriangleIndices.Add(9);
                cubeMesh.TriangleIndices.Add(10);
                //
                cubeMesh.TriangleIndices.Add(10);
                cubeMesh.TriangleIndices.Add(11);
                cubeMesh.TriangleIndices.Add(8);
                //
                cubeMesh.TriangleIndices.Add(12);
                cubeMesh.TriangleIndices.Add(13);
                cubeMesh.TriangleIndices.Add(14);
                //
                cubeMesh.TriangleIndices.Add(14);
                cubeMesh.TriangleIndices.Add(15);
                cubeMesh.TriangleIndices.Add(12);
                //
                cubeMesh.TriangleIndices.Add(16);
                cubeMesh.TriangleIndices.Add(17);
                cubeMesh.TriangleIndices.Add(18);
                //
                cubeMesh.TriangleIndices.Add(18);
                cubeMesh.TriangleIndices.Add(19);
                cubeMesh.TriangleIndices.Add(16);
                //
                cubeMesh.TriangleIndices.Add(20);
                cubeMesh.TriangleIndices.Add(21);
                cubeMesh.TriangleIndices.Add(22);
                //
                cubeMesh.TriangleIndices.Add(22);
                cubeMesh.TriangleIndices.Add(23);
                cubeMesh.TriangleIndices.Add(20);

                Material material = null;
                if (DiffuseBrush != null)
                {
                    material = new DiffuseMaterial(DiffuseBrush);
                }

                GeometryModel3D cubeGeo = new GeometryModel3D(cubeMesh, material);
                cubeModel = new ModelVisual3D
                    {
                        Content = cubeGeo,
                        Transform = ObjectTransformation
                    };
                result.Add(cubeModel);

                return result;
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == DiffuseBrushProperty)
            {
                if (cubeModel == null)
                    return;

                (cubeModel.Content as GeometryModel3D).Material = new DiffuseMaterial(DiffuseBrush);
                InvalidateVisual();
            }
            else if (e.Property == ObjectTransformationProperty)
            {
                if (cubeModel == null)
                    return;

                cubeModel.Transform = ObjectTransformation;
            }
        }
    }
}
