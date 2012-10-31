using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Controls;

namespace NET.Tools.WPF
{
    public class GridAnimation : AnimationTimeline
    {
        #region Static Members
        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(GridLength), typeof(GridAnimation));
        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(GridLength), typeof(GridAnimation));
        public static readonly DependencyProperty ByProperty =
            DependencyProperty.Register("By", typeof(GridLength), typeof(GridAnimation));
        #endregion

        #region Properties
        public GridLength From
        {
            get
            {
                return (GridLength)GetValue(FromProperty);
            }
            set
            {
                SetValue(FromProperty, value);
            }
        }

        public GridLength To
        {
            get
            {
                return (GridLength)GetValue(ToProperty);
            }
            set
            {
                SetValue(ToProperty, value);
            }
        }

        public GridLength By
        {
            get
            {
                return (GridLength)GetValue(ByProperty);
            }
            set
            {
                SetValue(ByProperty, value);
            }
        }
        #endregion

        public GridAnimation()
        {
            By = GridLength.Auto;
            From = GridLength.Auto;
            To = GridLength.Auto;
        }

        public override Type TargetPropertyType
        {
            get { return typeof(GridLength); }
        }

        protected override System.Windows.Freezable CreateInstanceCore()
        {
            return new GridAnimation();
        }

        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            double from = ((GridLength)GetValue(FromProperty)).Value;
            if (from.Equals(GridLength.Auto.Value))
                from = ((GridLength)defaultOriginValue).Value;

            double to = ((GridLength)GetValue(ToProperty)).Value;

            double by = ((GridLength)GetValue(ByProperty)).Value;

            if (by.Equals(GridLength.Auto.Value))
            {
                if (from > to)
                {
                    return new GridLength((1 - animationClock.CurrentProgress.Value) *
                        (from - to) + to, GridUnitType.Star);
                }
                else
                {
                    return new GridLength((animationClock.CurrentProgress.Value) *
                        (to - from) + from, GridUnitType.Star);
                }
            }
            else
            {
                if (from > by)
                {
                    return new GridLength((1 - animationClock.CurrentProgress.Value) *
                        (from - by) + by, GridUnitType.Star);
                }
                else
                {
                    return new GridLength((animationClock.CurrentProgress.Value) *
                        (by - from) + from, GridUnitType.Star);
                }
            }
        }
    }
}
