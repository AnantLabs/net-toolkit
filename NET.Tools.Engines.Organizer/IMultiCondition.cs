using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    /// <summary>
    /// Multi condition class template
    /// </summary>
    public abstract class MultiCondition : ICollection<ICondition>
    {
        private IList<ICondition> conditionList = new List<ICondition>();

        internal MultiCondition(LinkType type, params ICondition[] list)
        {
            LinkType = type;
            foreach (ICondition con in list)
                conditionList.Add(con);
        }

        internal LinkType LinkType
        {
            get;
            set;
        }

        #region ICollection<ICondition> Member

        public void Add(ICondition item)
        {
            conditionList.Add(item);
        }

        public void Clear()
        {
            conditionList.Clear();
        }

        public bool Contains(ICondition item)
        {
            return conditionList.Contains(item);
        }

        public void CopyTo(ICondition[] array, int arrayIndex)
        {
            conditionList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return conditionList.Count; }
        }

        public bool IsReadOnly
        {
            get { return conditionList.IsReadOnly; }
        }

        public bool Remove(ICondition item)
        {
            return conditionList.Remove(item);
        }

        #endregion

        #region IEnumerable<ICondition> Member

        public IEnumerator<ICondition> GetEnumerator()
        {
            return conditionList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Member

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return conditionList.GetEnumerator();
        }

        #endregion
    }

    internal enum LinkType
    {
        AND,
        OR
    }
}
