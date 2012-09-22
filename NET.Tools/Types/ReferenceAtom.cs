using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Represent a reference manager for an object type as atom
    /// 
    /// This manager count all references of an object it will be needed. If the object
    /// is destroyed, it will sub each reference from the counter. This system likes
    /// objective-c reference system
    /// </summary>
    /// <typeparam name="T">Type of the atomic reference</typeparam>
    public struct ReferenceAtom<T> : IDisposable
    {
        private static IDictionary<object, int> referenceCounterList = new Dictionary<object, int>();

        private T value;
        private bool selfDisposed;

        /// <summary>
        /// Create the atomic reference of this type
        /// </summary>
        /// <param name="parameterList"></param>
        public ReferenceAtom(params object[] parameterList)
        {
            value = (T)Activator.CreateInstance(typeof(T), parameterList);
            referenceCounterList.Add(value, 0);
            selfDisposed = false;
        }

        private ReferenceAtom(T value)
        {
            this.value = value;
            //Copy-Constructor: One more reference
            referenceCounterList[value]++;
            selfDisposed = false;
        }

        public static implicit operator T(ReferenceAtom<T> atom)
        {
            return atom.value;
        }

        //public static implicit operator ReferenceAtom<T>(ReferenceAtom<T> atom)
        //{
            
        //    //Copy value reference in a new atom
        //    return new ReferenceAtom<T>(atom.value);
        //}

        /// <summary>
        /// Gets the atomic value
        /// </summary>
        public T Value
        {
            get { return value; }
        }

        public bool IsDisposed
        {
            get { return !referenceCounterList.ContainsKey(value); }
        }

        #region IDisposable Member

        public void Dispose()
        {
            if (IsDisposed || selfDisposed)
                throw new InvalidOperationException("Cannot dispose object: Is already disposed!");

            referenceCounterList[value]--;
            if (referenceCounterList[value] <= 0)
            {
                referenceCounterList.Remove(value);
                selfDisposed = true;
            }
        }

        #endregion
    }
}
