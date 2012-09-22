using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace NET.Tools
{
    public static class DependencyObjectExtensions
    {
        public static bool IsDesignMode(this DependencyObject obj)
        {
            return DesignerProperties.GetIsInDesignMode(obj);
        }
    }
}
