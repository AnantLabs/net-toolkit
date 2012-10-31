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
        

        protected override IList<MeshGeometry3D> Meshes
        {
            get
            {
                IList<MeshGeometry3D> result = new List<MeshGeometry3D>();

                MeshGeometry3D cubeMesh = new MeshGeometry3D();
                //Vertices
                cubeMesh.Positions.Add(new Point3D(-1, -1, +1));//00 //0, 0, 1
                cubeMesh.Positions.Add(new Point3D(+1, -1, +1));//01 //1, 0, 1
                cubeMesh.Positions.Add(new Point3D(+1, +1, +1));//02 //1, 1, 1
                cubeMesh.Positions.Add(new Point3D(-1, +1, +1));//03 //0, 1, 1
                cubeMesh.Positions.Add(new Point3D(+1, -1, -1));//04 //1, 0, 0
                cubeMesh.Positions.Add(new Point3D(-1, -1, -1));//05 //0, 0, 0
                cubeMesh.Positions.Add(new Point3D(-1, +1, -1));//06 //0, 1, 0
                cubeMesh.Positions.Add(new Point3D(+1, +1, -1));//07 //1, 1, 0
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
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X, 
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X, 
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X, 
                    TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X, 
                    TextureCoordinationTransformFactor.Y));
                //
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                //
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                //
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                //
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                //
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationMultiplyFactor.Y + TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationMultiplyFactor.X + TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));
                cubeMesh.TextureCoordinates.Add(new Point(
                    TextureCoordinationTransformFactor.X,
                    TextureCoordinationTransformFactor.Y));

                result.Add(cubeMesh);

                return result;
            }
        }
    }
}
