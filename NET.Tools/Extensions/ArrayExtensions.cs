using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for arrays
    /// </summary>
    public static class ArrayExtensions
    {
        public static T[] Add<T>(this T[] array, T item)
        {
            IList<T> tmp = new List<T>(array);
            tmp.Add(item);

            return tmp.ToArray();
        }

        public static T[] Remove<T>(this T[] array, T item)
        {
            IList<T> tmp = new List<T>(array);
            if (!tmp.Remove(item))
                throw new ArgumentException("Cannot find item in array!");

            return tmp.ToArray();
        }

        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            IList<T> tmp = new List<T>(array);
            tmp.RemoveAt(index);

            return tmp.ToArray();
        }
    }

    /// @}
}
