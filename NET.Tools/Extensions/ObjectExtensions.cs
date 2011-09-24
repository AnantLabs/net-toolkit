using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Contains all object extensions
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Check the value of the given bounds
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min">Minimum bound</param>
        /// <param name="max">Maximum bound</param>
        /// <returns>TRUE, if the value is in the bounds</returns>
        public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return
                (value.CompareTo(min) >= 0) &&
                (value.CompareTo(max) <= 0);
        }

        /// <summary>
        /// Create a byte array from the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Buffer with bytes of object content</returns>
        public static byte[] ToBytes<T>(this T obj) where T : ISerializable
        {
            byte[] res = null;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(ms, obj);
                res = ms.GetBuffer();
            }

            return res;
        }

        /// <summary>
        /// Gets the object from the given byte array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="buffer">The byte array with the object content</param>
        /// <returns>The object with his content</returns>
        public static T FromBytes<T>(this T obj, byte[] buffer) where T : ISerializable
        {
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryFormatter f = new BinaryFormatter();
                return (T)f.Deserialize(ms);
            }
        }

        /// <summary>
        /// Press the value into the bounds
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>A value between minimum and maximum</returns>
        public static T PutInto<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;
            else if (value.CompareTo(max) > 0)
                return max;
            else
                return value;
        }

        /// <summary>
        /// Check the given list with the value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="list">Values to check with value</param>
        /// <returns>TRUE, if one of values is equals value</returns>
        public static bool IsIn<T>(this T value, params T[] list)
        {
            foreach (T obj in list)
                if (value.Equals(obj))
                    return true;

            return false;
        }

        /// <summary>
        /// Is the inverted method of IsIn{T}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNotIn<T>(this T value, params T[] list)
        {
            foreach (T obj in list)
                if (value.Equals(obj))
                    return false;

            return true;
        }
    }
    /// @}
}
