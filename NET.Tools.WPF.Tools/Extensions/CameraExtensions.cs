using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace NET.Tools.Extensions
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class CameraExtensions
    {
        /// <summary>
        /// Returns the current camera look position (from look direction)
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static Point3D GetLookAtPosition(this ProjectionCamera camera)
        {
            return camera.Position + camera.LookDirection;
        }

        /// <summary>
        /// Set the camera look position (calculate look direction)
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="lookPosition"></param>
        public static void SetLookAtPosition(this ProjectionCamera camera, Point3D lookPosition)
        {
            camera.LookDirection = lookPosition - camera.Position;
        }
    }

    /// @}
}
