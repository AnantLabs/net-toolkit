using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace NET.Tools
{
    public class VisibilityConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }

            throw new NotSupportedException("Unknown type: " + targetType);
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(bool))
            {
                switch ((Visibility)value)
                {
                    case Visibility.Visible:
                        return true;
                    case Visibility.Hidden:
                    case Visibility.Collapsed:
                        return false;
                    default:
                        throw new NotImplementedException(value.ToString());
                }
            }

            throw new NotSupportedException("Unknown type: " + targetType);
        }
    }
}
