using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for a lot of windows forms collections
    /// </summary>
    public static class CollectionExtensions
    {
        public static bool ContainsKey(this ListViewGroupCollection col, string key)
        {
            foreach (ListViewGroup lvg in col)
                if (lvg.Name.Equals(key))
                    return true;

            return false;
        }

        public static bool ContainsHeader(this ListViewGroupCollection col, string header)
        {
            foreach (ListViewGroup lvg in col)
                if (lvg.Header.Equals(header))
                    return true;

            return false;
        }

        public static ListViewGroup GetByHeader(this ListViewGroupCollection col, string header)
        {
            foreach (ListViewGroup lvg in col)
                if (lvg.Header.Equals(header))
                    return lvg;

            return null;
        }

        public static bool ContainsKey(this ListViewItem.ListViewSubItemCollection col, string key)
        {
            foreach (ListViewItem.ListViewSubItem lvsi in col)
                if (lvsi.Name.Equals(key))
                    return true;

            return false;
        }

        public static bool ContainsText(this ListViewItem.ListViewSubItemCollection col, string text)
        {
            foreach (ListViewItem.ListViewSubItem lvsi in col)
                if (lvsi.Text.Equals(text))
                    return true;

            return false;
        }

        public static ListViewItem.ListViewSubItem GetByText(this ListViewItem.ListViewSubItemCollection col, string text)
        {
            foreach (ListViewItem.ListViewSubItem lvsi in col)
                if (lvsi.Text.Equals(text))
                    return lvsi;

            return null;
        }

        public static bool ContainsKey(this ListView.ListViewItemCollection col, string key)
        {
            foreach (ListViewItem lvi in col)
                if (lvi.Name.Equals(key))
                    return true;

            return false;
        }

        public static bool ContainsText(this ListView.ListViewItemCollection col, string text)
        {
            foreach (ListViewItem lvi in col)
                if (lvi.Text.Equals(text))
                    return true;

            return false;
        }

        public static ListViewItem GetByText(this ListView.ListViewItemCollection col, string text)
        {
            foreach (ListViewItem lvi in col)
                if (lvi.Text.Equals(text))
                    return lvi;

            return null;
        }
    }
    /// @}
}
