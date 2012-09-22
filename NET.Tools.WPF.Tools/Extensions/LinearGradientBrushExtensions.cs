using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class LinearGradientBrushExtensions
    {
        public static LinearGradientBrush Brighter(this LinearGradientBrush LinearGradientBrush, int div)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops, 
                    (color) => { return color.Brighter(div); }), 
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush Brighter(this LinearGradientBrush c)
        {
            return Brighter(c, 2);
        }

        public static LinearGradientBrush Darker(this LinearGradientBrush LinearGradientBrush, int div)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops,
                    (color) => { return color.Darker(div); }),
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush Darker(this LinearGradientBrush c)
        {
            return Darker(c, 2);
        }

        public static LinearGradientBrush ToGrayScale(this LinearGradientBrush LinearGradientBrush)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops,
                    (color) => { return color.ToGrayScale(); }),
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush ToRedGrayScale(this LinearGradientBrush LinearGradientBrush)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops,
                    (color) => { return color.ToRedGrayScale(); }),
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush ToGreenGrayScale(this LinearGradientBrush LinearGradientBrush)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops,
                    (color) => { return color.ToGreenGrayScale(); }),
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush ToBlueGrayScale(this LinearGradientBrush LinearGradientBrush)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops,
                    (color) => { return color.ToBlueGrayScale(); }),
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush ToNegative(this LinearGradientBrush LinearGradientBrush)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops,
                    (color) => { return color.ToNegative(); }),
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush AddLinearGradientBrush(this LinearGradientBrush LinearGradientBrush, Color addColor, float percent)
        {
            return new LinearGradientBrush(
                EditColors(
                    LinearGradientBrush.GradientStops,
                    (color) => { return color.AddColor(addColor, percent); }),
                LinearGradientBrush.StartPoint, LinearGradientBrush.EndPoint);
        }

        public static LinearGradientBrush AddLinearGradientBrush(this LinearGradientBrush LinearGradientBrush, Color addColor)
        {
            return AddLinearGradientBrush(LinearGradientBrush, addColor, 0.5f);
        }

        public static System.Drawing.Drawing2D.LinearGradientBrush ToDrawingLinearGradientBrush(this LinearGradientBrush brush)
        {
            return new System.Drawing.Drawing2D.LinearGradientBrush(
                brush.StartPoint.ToDrawingPoint(), brush.EndPoint.ToDrawingPoint(),
                brush.GradientStops[0].Color.ToDrawingColor(),
                brush.GradientStops[brush.GradientStops.Count - 1].Color.ToDrawingColor());
        }

        #region Private 

        private static GradientStopCollection EditColors(GradientStopCollection col, Func<Color, Color> action)
        {
            GradientStopCollection res = new GradientStopCollection();

            foreach (GradientStop gs in res)
            {
                Color newColor = action(gs.Color);
                res.Add(new GradientStop(newColor, gs.Offset));
            }

            return res;
        }

        #endregion
    }
    /// @}
}
