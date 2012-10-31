using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace NET.Tools.OS
{
    public sealed class ThumbnailTabManager
    {
        private IList<ThumbnailTab> tabList = new List<ThumbnailTab>();

        public IntPtr Root
        {
            get;
            private set;
        }

        public ReadOnlyCollection<ThumbnailTab> TabList
        {
            get { return new ReadOnlyCollection<ThumbnailTab>(tabList); }
        }

        internal ThumbnailTabManager(IntPtr hwnd)
        {
            Root = hwnd;
        }

        public ThumbnailTab AddTab(IntPtr child)
        {
            ThumbnailTab newThumbnailTab = new ThumbnailTab(this, child);
            tabList.Add(newThumbnailTab);
            newThumbnailTab.AddTab();
            return newThumbnailTab;
        }

        public ThumbnailTab AddTab(System.Windows.Forms.Control c)
        {
            return AddTab(c.Handle);
        }

        public void RemoveTab(ThumbnailTab tab)
        {
            tab.RemoveTab();
            tabList.Remove(tab);
        }
    }
}
