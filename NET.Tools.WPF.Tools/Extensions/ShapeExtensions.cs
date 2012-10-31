using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class ShapeExtensions
    {
        /// <summary>
        /// Update the shape with the given style information
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="strokeStyle">Stroke Style Information</param>
        /// <param name="fillStyle">Fill Style Information</param>
        public static void UpdateShape(this Shape shape, StrokeStyle strokeStyle, FillStyle fillStyle)
        {
            if (strokeStyle != null)
            {
                shape.Stroke = strokeStyle.StrokeColor;
                shape.StrokeThickness = strokeStyle.Thickness;
                shape.StrokeStartLineCap = strokeStyle.StartLineCap;
                shape.StrokeEndLineCap = strokeStyle.EndLineCap;
                if (strokeStyle.DashStyle != null)
                {
                    shape.StrokeDashArray = strokeStyle.DashStyle.Dashes;
                    shape.StrokeDashOffset = strokeStyle.DashStyle.Offset;
                    shape.StrokeDashCap = strokeStyle.DashCap;
                }
            }

            if (fillStyle != null)
            {
                shape.Fill = fillStyle.FillColor;
            }
        }

        public static void UpdateShape(this Shape shape, FillStyle fillStyle)
        {
            UpdateShape(shape, null, fillStyle);
        }

        public static void UpdateShape(this Shape shape, StrokeStyle strokeStyle)
        {
            UpdateShape(shape, strokeStyle, null);
        }

        public static void UpdateShape(this Shape shape, ShapeStyle shapeStyle)
        {
            UpdateShape(shape, shapeStyle.StrokeStyle, shapeStyle.FillStyle);
        }
    }

    /// @}
}
