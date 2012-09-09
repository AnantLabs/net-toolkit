using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NET.Tools.WPF
{
    public class AutoResizeCanvas : Canvas
    {
        protected override Size MeasureOverride(Size constraint)
        {
            Size size = base.MeasureOverride(constraint);
            if (InternalChildren.Count <= 0)
                return size;

            double width = base
                .InternalChildren
                .OfType<UIElement>()
                .Max(i => i.DesiredSize.Width + (double) i.GetValue(LeftProperty));
            if (width < MinWidth || double.IsNaN(width))
                width = MinWidth;
            if (!double.IsNaN(MaxWidth) && width > MaxWidth)
                width = MaxWidth;

            double height = base
                .InternalChildren
                .OfType<UIElement>()
                .Max(i => i.DesiredSize.Height + (double) i.GetValue(TopProperty));
            if (height < MinHeight || double.IsNaN(height))
                height = MinHeight;
            if (!double.IsNaN(MaxHeight) && height > MaxHeight)
                height = MaxHeight;

            return new Size(width, height);
        }
    }
}