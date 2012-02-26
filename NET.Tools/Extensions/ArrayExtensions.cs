using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        /// <summary>
        /// Gets a sub-array from the current array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="start">Start index in the array, 0 based</param>
        /// <param name="length">Length to copy into the result array or a negative value to copy complete array started by start index</param>
        /// <returns>Sub-Array</returns>
        public static T[] SubArray<T>(this T[] array, int start, int length)
        {
            if (length == 0)
                throw new ArgumentException("Length must be greater than 0 or a negative value!");
            if (length < 0)
                length = array.Length - start;

            T[] result = new T[length];
            for (int i = start; i < start + length; i++)
            {
                result[i - start] = array[i];
            }

            return result;
        }

        /// <summary>
        /// Gets a sub-array from the current array started at start index until the array length
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="start">Start index in the array, 0 based</param>
        /// <returns>Sub-Array</returns>
        public static T[] SubArray<T>(this T[] array, int start)
        {
            return SubArray<T>(array, start, -1);
        }

        /// <summary>
        /// Sort the given array with the Array.Sort method based on the IComparanle interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Sort<T>(this T[] array) where T : IComparable
        {
            Array.Sort(array, (x, y) =>
            {
                return x.CompareTo(y);
            });
        }

        /// <summary>
        /// Do an equals to an other array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array1"></param>
        /// <param name="array2">The array to compare with current array</param>
        /// <returns></returns>
        public static bool EqualsTo<T>(this T[] array1, T[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
                if (!array1[i].Equals(array2[i]))
                    return false;

            return true;
        }
    }

    /// @}
}
