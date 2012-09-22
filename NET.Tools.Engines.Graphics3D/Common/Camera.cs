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

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else if (Object.ReferenceEquals(obj, this))
            {
                return true;
            }

            ProjectionInformation pi = obj as ProjectionInformation;

            return
                FieldOfView == pi.FieldOfView &&
                Aspect == pi.Aspect &&
                NearestZ == pi.NearestZ &&
                FarthestZ == pi.FarthestZ;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return FieldOfView.GetHashCode() + Aspect.GetHashCode() + NearestZ.GetHashCode() + FarthestZ.GetHashCode();
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

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else if (Object.ReferenceEquals(obj, this))
            {
                return true;
            }

            ViewInformation vi = obj as ViewInformation;

            return
                vi.LookAt.Equals(LookAt) &&
                vi.Position.Equals(Position) &&
                vi.UpVector.Equals(UpVector);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return LookAt.GetHashCode() + Position.GetHashCode() + UpVector.GetHashCode();
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

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else if (Object.ReferenceEquals(obj, this))
            {
                return true;
            }

            Camera cam = obj as Camera;

            return
                cam.ProjectionInformation.Equals(ProjectionInformation) &&
                cam.ViewInformation.Equals(ViewInformation);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ProjectionInformation.GetHashCode() * ViewInformation.GetHashCode();
        }
    }
}
