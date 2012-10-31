using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Represent a reference manager
    /// 
    /// This manager count all references of an object it will be needed. If the object
    /// is destroyed, it will sub each reference from the counter. This system likes
    /// objective-c reference system
    /// </summary>
    public sealed class ReferenceManager
    {
        private int counter;

        public ReferenceManager()
        {
            counter = 0;
        }

        /// <summary>
        /// Add a reference
        /// </summary>
        public void AddReference()
        {
            counter++;
        }

        /// <summary>
        /// Remove a reference
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Is thrown if no reference exists. See also: HasReferences is false
        /// </exception>
        public void RemoveReference()
        {
            if (counter <= 0)
                throw new InvalidOperationException("Cannot remove reference: No references exists!");

            counter--;
        }

        /// <summary>
        /// FALSE if no reference exists, otherwise TRUE
        /// </summary>
        public bool HasReferences
        {
            get
            {
                return counter > 0;
            }
        }
    }
}
