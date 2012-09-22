using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for ICollection
    /// </summary>
    public static class ICollectionExtensions
    {
        public static T[] Remove<T>(this ICollection<T> array, Func<T, bool> search, out bool result)
        {
            T obj = array.Find(search);
            if (obj.Equals(default(T)))
                result = false;

            result = array.Remove(obj);
            return array.ToArray();
        }

        public static T[] Remove<T>(this ICollection<T> array, Func<T, bool> search)
        {
            bool res = true;
            return array.Remove(search, out res);
        }

        public static T[] Remove<T>(this ICollection<T> array, T value, Comparison<T> search, out bool result)
        {
            T obj = array.Find(value, search);
            if (obj.Equals(default(T)))
                result = false;

            result = array.Remove(obj);
            return array.ToArray();
        }

        public static T[] Remove<T>(this ICollection<T> array, T value, Comparison<T> search)
        {
            bool res = true;
            return array.Remove(value, search, out res);            
        }

        public static T Find<T>(this ICollection<T> array, T value, Comparison<T> search)
        {
            if (search == null)
                throw new ArgumentException("Search cannot be null!");

            foreach (T obj in array)
                if (search(value, obj) == 0)
                    return obj;

            return default(T);
        }

        public static T Find<T>(this ICollection<T> array, Func<T, bool> search)
        {
            if (search == null)
                throw new ArgumentException("Search cannot be null!");

            foreach (T obj in array)
                if (search(obj))
                    return obj;

            return default(T);
        }

        public static bool Contains<T>(this ICollection<T> array, T value, Comparison<T> comp)
        {
            if (comp == null)
                throw new ArgumentException("Comp cannot be null!");

            foreach (T obj in array)
                if (comp(value, obj) == 0)
                    return true;

            return false;
        }

        public static bool Contains<T>(this ICollection<T> array, Func<T, bool> comp)
        {
            if (comp == null)
                throw new ArgumentException("Comp cannot be null!");

            foreach (T obj in array)
                if (comp(obj))
                    return true;

            return false;
        }
    }

    /// @}
}
