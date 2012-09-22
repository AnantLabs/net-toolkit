using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NET.Tools
{
    /// <summary>
    /// Create a equals and hashcode for an object
    /// </summary>
    public static class EHCBuilder
    {
        /// <summary>
        /// Create an equals for the two objects
        /// </summary>
        /// <param name="baseObj">Base object</param>
        /// <param name="obj">Other object</param>
        /// <returns></returns>
        public static new bool Equals(object baseObj, object obj)
        {
            if ((baseObj == null) && (obj == null))
                return true;
            if ((baseObj == null) ^ (obj == null))
                return false;
            if (!baseObj.GetType().Equals(obj.GetType()))
                return false;
            if (Object.ReferenceEquals(baseObj, obj))
                return true;

            PropertyInfo[] props = baseObj.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo pi in props)
            {
                object left = pi.GetValue(baseObj, null);
                object right = pi.GetValue(obj, null);

                if ((left == null) && (right == null))
                    continue; // null == null
                else if ((left != null) && (right != null))
                {
                    if (!left.Equals(right)) //content == content?
                        return false;
                }
                else // null != content || content != null
                    return false;
            }

            return true;
        }

        public static int GetHashCode(object baseObj)
        {
            int res = 0;

            PropertyInfo[] props = baseObj.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo pi in props)
            {
                object value = pi.GetValue(baseObj, null);
                if (value != null)
                    res += value.GetHashCode();
            }

            return res;
        }
    }
}
