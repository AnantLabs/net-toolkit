using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class UIElementExtensions
    {
        public static void Refresh(this UIElement element)
        {
            element.Dispatcher.Invoke(new Action(() => { }), null);
        }

        public static void Invoke(this UIElement element, Action action)
        {
            element.Dispatcher.Invoke(action, null);
        }

        public static T Invoke<T>(this UIElement element, Func<T> action)
        {
            return (T)element.Dispatcher.Invoke(action, null);
        }
    }
    /// @}
}
