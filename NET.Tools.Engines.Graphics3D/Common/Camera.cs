using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;

namespace NET.Tools.Engines.Graphics3D
{
    public sealed class ProjectionInformation
    {
        public float FieldOfView { get; set; }
        public float Aspect { get; set; }
        public float NearestZ { get; set; }
        public float FarthestZ { get; set; }

        internal ProjectionInformation()
        {
            FieldOfView = (float)Math.PI / 4f;
            Aspect = (float)Graphics3DSystem.Configuration.ScreenConfiguration.Width / (float)Graphics3DSystem.Configuration.ScreenConfiguration.Height;
            NearestZ = 1f;
            FarthestZ = 10000f;
        }
    }

    public sealed class ViewInformation
    {
        public Vector3 Position { get; set; }
        public Vector3 LookAt { get; set; }
        public Vector3 UpVector { get; set; }

        internal ViewInformation()
        {
            Position = new Vector3(1, 1, 1);
            LookAt = Vector3.Zero;
            UpVector = Vector3.UnitY;
        }
    }

    public sealed class Camera
    {
        public ProjectionInformation ProjectionInformation { get; private set; }
        public ViewInformation ViewInformation { get; private set; }

        internal Camera()
        {
            ProjectionInformation = new ProjectionInformation();
            ViewInformation = new ViewInformation();
        }

        internal void SetupCamera()
        {
            Graphics3DSystem.Implementors.MatrixImplementor.SetupCamera(ViewInformation, ProjectionInformation);
        }
    }
}
