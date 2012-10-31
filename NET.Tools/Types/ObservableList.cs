using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace NET.Tools
{
    public class ObservableList<T> : ObservableCollection<T>
    {
        private Dispatcher dispatcher;

        #region Constructors

        public ObservableList(Dispatcher dispatcher = null)
        {
            this.dispatcher = dispatcher ??
                              (Application.Current != null
                                   ? Application.Current.Dispatcher
                                   : Dispatcher.CurrentDispatcher);
        }

        public ObservableList(IEnumerable<T> collection, Dispatcher dispatcher = null)
            : base(collection)
        {
            this.dispatcher = dispatcher ??
                              (Application.Current != null
                                   ? Application.Current.Dispatcher
                                   : Dispatcher.CurrentDispatcher);
        }

        public ObservableList(List<T> list, Dispatcher dispatcher = null)
            : base(list)
        {
            this.dispatcher = dispatcher ??
                              (Application.Current != null
                                   ? Application.Current.Dispatcher
                                   : Dispatcher.CurrentDispatcher);
        }

        #endregion

        protected override void ClearItems()
        {
            if (dispatcher.CheckAccess())
            {
                base.ClearItems();
            }
            else
            {
                dispatcher.Invoke(new Action(ClearItems));
            }
        }

        protected override void RemoveItem(int index)
        {
            if (dispatcher.CheckAccess())
            {
                base.RemoveItem(index);
            }
            else
            {
                dispatcher.Invoke(new Action(() => RemoveItem(index)));
            }
        }

        protected override void InsertItem(int index, T item)
        {
            if (dispatcher.CheckAccess())
            {
                base.InsertItem(index, item);
            }
            else
            {
                dispatcher.Invoke(new Action(() => InsertItem(index, item)));
            }
        }

        protected override void SetItem(int index, T item)
        {
            if (dispatcher.CheckAccess())
            {
                base.SetItem(index, item);
            }
            else
            {
                dispatcher.Invoke(new Action(() => SetItem(index, item)));
            }
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            if (dispatcher.CheckAccess())
            {
                base.MoveItem(oldIndex, newIndex);
            }
            else
            {
                dispatcher.Invoke(new Action(() => MoveItem(oldIndex, newIndex)));
            }
        }
    }
}
