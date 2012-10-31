using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;
using SlimDX;

namespace NET.Tools.Engines.Graphics3D.Direct3D9
{
    internal sealed class Direct3D9MatrixImplementor : IMatrixImplementor
    {
        private static Direct3D9MatrixImplementor instance = null;
        public static Direct3D9MatrixImplementor GetInstance()
        {
            if (instance == null)
            {
                instance = new Direct3D9MatrixImplementor();
            }

            return instance;
        }

        private Direct3D9MatrixImplementor()
        {
        }

        public void SetupCamera(ViewInformation view, ProjectionInformation projection)
        {
            GraphicsDirect3D9.Device.SetTransform(
                TransformState.View,
                Matrix.LookAtLH(
                    view.Position,
                    view.LookAt,
                    view.UpVector
                )
            );
            GraphicsDirect3D9.Device.SetTransform(
                TransformState.Projection,
                Matrix.PerspectiveFovLH(
                    projection.FieldOfView,
                    projection.Aspect,
                    projection.NearestZ,
                    projection.FarthestZ
                )
            );
        }


        public Matrix SetTransformation(Matrix matrix)
        {
            //Get old matrix first
            Matrix oldMatrix = GraphicsDirect3D9.Device.GetTransform(TransformState.World);
            //Setup new matrix (overwrite)
            GraphicsDirect3D9.Device.SetTransform(TransformState.World, matrix);
            //Return old matrix
            return oldMatrix;
        }


        public Matrix AddTransformation(Matrix matrix)
        {
            //Get old matrix first
            Matrix oldMatrix = GraphicsDirect3D9.Device.GetTransform(TransformState.World);
            //Setup new matrix (add)
            GraphicsDirect3D9.Device.SetTransform(TransformState.World, oldMatrix * matrix);
            //Return old matrix
            return oldMatrix;
        }
    }
}
