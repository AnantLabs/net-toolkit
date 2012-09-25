using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Browsable(true)]
        [Category("Shape 3D")]
        public double CubeWidth
        {
            get { return (double) GetValue(CubeWidthProperty); }
            set { SetValue(CubeWidthProperty, value); }
        }

        public static readonly DependencyProperty CubeHeightProperty =
            DependencyProperty.Register("CubeHeight", typeof (double), typeof (Cube3D), new PropertyMetadata(2d));

        [Browsable(true)]
        [Category("Shape 3D")]
        public double CubeHeight
        {
            get { return (double) GetValue(CubeHeightProperty); }
            set { SetValue(CubeHeightProperty, value); }
        }

        public static readonly DependencyProperty CubeDepthProperty =
            DependencyProperty.Register("CubeDepth", typeof (double), typeof (Cube3D), new PropertyMetadata(2d));

        [Browsable(true)]
        [Category("Shape 3D")]
        public double CubeDepth
        {
            get { return (double) GetValue(CubeDepthProperty); }
            set { SetValue(CubeDepthProperty, value); }
        }

        protected override IList<MeshGeometry3D> Meshes
        {
            get
            {
                IList<MeshGeometry3D> result = new List<MeshGeometry3D>();

                MeshGeometry3D cubeMesh = new MeshGeometry3D();
                //Vertices
                cubeMesh.Positions.Add(new Point3D(-(CubeWidth / 2), -(CubeHeight / 2), +(CubeDepth / 2)));//00 //0, 0, 1
                cubeMesh.Positions.Add(new Point3D(+(CubeWidth / 2), -(CubeHeight / 2), +(CubeDepth / 2)));//01 //1, 0, 1
                cubeMesh.Positions.Add(new Point3D(+(CubeWidth / 2), +(CubeHeight / 2), +(CubeDepth / 2)));//02 //1, 1, 1
                cubeMesh.Positions.Add(new Point3D(-(CubeWidth / 2), +(CubeHeight / 2), +(CubeDepth / 2)));//03 //0, 1, 1
                cubeMesh.Positions.Add(new Point3D(+(CubeWidth / 2), -(CubeHeight / 2), -(CubeDepth / 2)));//04 //1, 0, 0
                cubeMesh.Positions.Add(new Point3D(-(CubeWidth / 2), -(CubeHeight / 2), -(CubeDepth / 2)));//05 //0, 0, 0
                cubeMesh.Positions.Add(new Point3D(-(CubeWidth / 2), +(CubeHeight / 2), -(CubeDepth / 2)));//06 //0, 1, 0
                cubeMesh.Positions.Add(new Point3D(+(CubeWidth / 2), +(CubeHeight / 2), -(CubeDepth / 2)));//07 //1, 1, 0
                //Indices
                cubeMesh.TriangleIndices.Add(0);//0, 0, 1
                cubeMesh.TriangleIndices.Add(1);//1, 0, 1
                cubeMesh.TriangleIndices.Add(2);//1, 1, 1
                //
                cubeMesh.TriangleIndices.Add(2);//1, 1, 1
                cubeMesh.TriangleIndices.Add(3);//0, 1, 1
                cubeMesh.TriangleIndices.Add(0);//0, 0, 1
                //
                cubeMesh.TriangleIndices.Add(4);//1, 0, 0
                cubeMesh.TriangleIndices.Add(5);//0, 0, 0
                cubeMesh.TriangleIndices.Add(6);//0, 1, 0
                //
                cubeMesh.TriangleIndices.Add(6);//0, 1, 0
                cubeMesh.TriangleIndices.Add(7);//1, 1, 0
                cubeMesh.TriangleIndices.Add(4);//1, 0, 0
                //
                cubeMesh.TriangleIndices.Add(1);//1, 0, 1
                cubeMesh.TriangleIndices.Add(4);//1, 0, 0
                cubeMesh.TriangleIndices.Add(7);//1, 1, 0
                //
                cubeMesh.TriangleIndices.Add(7);//1, 1, 0
                cubeMesh.TriangleIndices.Add(2);//1, 1, 1
                cubeMesh.TriangleIndices.Add(1);//1, 0, 1
                //
                cubeMesh.TriangleIndices.Add(5);//0, 0, 0
                cubeMesh.TriangleIndices.Add(0);//0, 0, 1
                cubeMesh.TriangleIndices.Add(3);//0, 1, 1
                //
                cubeMesh.TriangleIndices.Add(3);//0, 1, 1
                cubeMesh.TriangleIndices.Add(6);//0, 1, 0
                cubeMesh.TriangleIndices.Add(5);//0, 0, 0
                //
                cubeMesh.TriangleIndices.Add(3);//0, 1, 1
                cubeMesh.TriangleIndices.Add(2);//1, 1, 1
                cubeMesh.TriangleIndices.Add(7);//1, 1, 0
                //
                cubeMesh.TriangleIndices.Add(7);//1, 1, 0
                cubeMesh.TriangleIndices.Add(6);//0, 1, 0
                cubeMesh.TriangleIndices.Add(3);//0, 1, 1
                //
                cubeMesh.TriangleIndices.Add(1);//1, 0, 1
                cubeMesh.TriangleIndices.Add(0);//0, 0, 1
                cubeMesh.TriangleIndices.Add(5);//0, 0, 0
                //
                cubeMesh.TriangleIndices.Add(5);//0, 0, 0
                cubeMesh.TriangleIndices.Add(4);//1, 0, 0
                cubeMesh.TriangleIndices.Add(1);//1, 0, 1
                //Tex Coords
                cubeMesh.TextureCoordinates.Add(new Point(0, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 0));
                cubeMesh.TextureCoordinates.Add(new Point(0, 0));
                //
                cubeMesh.TextureCoordinates.Add(new Point(0, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 0));
                cubeMesh.TextureCoordinates.Add(new Point(0, 0));
                //
                cubeMesh.TextureCoordinates.Add(new Point(0, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 0));
                cubeMesh.TextureCoordinates.Add(new Point(0, 0));
                //
                cubeMesh.TextureCoordinates.Add(new Point(0, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 0));
                cubeMesh.TextureCoordinates.Add(new Point(0, 0));
                //
                cubeMesh.TextureCoordinates.Add(new Point(0, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 0));
                cubeMesh.TextureCoordinates.Add(new Point(0, 0));
                //
                cubeMesh.TextureCoordinates.Add(new Point(0, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 1));
                cubeMesh.TextureCoordinates.Add(new Point(1, 0));
                cubeMesh.TextureCoordinates.Add(new Point(0, 0));

                result.Add(cubeMesh);

                return result;
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == CubeDepthProperty ||
                e.Property == CubeHeightProperty ||
                e.Property == CubeWidthProperty)
            {
                RebuildModel();
                InvalidateVisual();
            }
        }
    }
}
