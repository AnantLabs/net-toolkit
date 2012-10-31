using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    public static class CollectionExtensions
    {
        public static ICollection<T> Clone<T>(this ICollection<T> list) where T : ICloneable
        {
            ICollection<T> result = null;
            try
            {
                result = (ICollection<T>)Activator.CreateInstance(list.GetType());
            }
            catch (Exception)
            {
                result = new List<T>();
            }

            foreach (T item in list)
            {
                result.Add((T) item.Clone());
            }

            return result;
        }
    }
}
