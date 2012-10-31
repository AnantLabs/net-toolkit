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
    /// Extensions for list views
    /// </summary>
    public static class ListViewExtensions
    {
        /// <summary>
        /// Select all items in list view
        /// </summary>
        /// <param name="lv"></param>
        public static void SelectAll(this ListView lv)
        {
            foreach (ListViewItem lvi in lv.Items)
            {
                lv.SelectedIndices.Add(lvi.Index);
            }
        }

        /// <summary>
        /// Remove all current selected elements
        /// </summary>
        /// <param name="lv"></param>
        public static void RemoveSelected(this ListView lv)
        {
            while (lv.SelectedItems.Count > 0)
                lv.Items.Remove(lv.SelectedItems[0]);
        }

        public static void ClearItems(this ListView lv)
        {
            lv.Items.Clear();
        }

        public static void ClearGroups(this ListView lv)
        {
            lv.Groups.Clear();
        }

        public static void ClearColumns(this ListView lv)
        {
            lv.Columns.Clear();
        }

        public static void ClearAll(this ListView lv)
        {
            lv.ClearColumns();
            lv.ClearGroups();
            lv.ClearItems();
        }

        public static ListViewItem AddItem(this ListView lv, ListViewItem lvi)
        {
            return lv.Items.Add(lvi);
        }

        public static ListViewItem AddItem(this ListView lv, String key, String text, String imageKey)
        {
            return lv.Items.Add(key, text, imageKey);
        }

        public static ListViewItem AddItem(this ListView lv, String key, String text)
        {
            return AddItem(lv, key, text, null);
        }

        public static ListViewItem AddItem(this ListView lv, String text)
        {
            return AddItem(lv, text, text, null);
        }

        public static int AddGroup(this ListView lv, ListViewGroup group)
        {
            return lv.Groups.Add(group);
        }

        public static ListViewGroup AddGroup(this ListView lv, String key, String header)
        {
            return lv.Groups.Add(key, header);
        }

        public static ListViewGroup AddGroup(this ListView lv, String header)
        {
            return AddGroup(lv, header, header);
        }

        public static ListViewGroup AddGroupIfNotExists(this ListView lv, String header)
        {
            if (lv.Groups.ContainsHeader(header))
                return lv.Groups.GetByHeader(header);
            else
                return lv.Groups.Add(header, header);
        }

        public static void AddItemToGroup(this ListView lv, ListViewItem lvi, ListViewGroup group)
        {
            lv.Groups.Add(group);
            lv.Items.Add(lvi);
            lvi.Group = group;
        }

        public static ListViewItem AddItemToGroup(this ListView lv, String itemKey, 
            String itemText, String itemImage, String groupKey, String groupHeader)
        {
            ListViewItem lvi = lv.Items.Add(itemKey, itemText, itemImage);
            ListViewGroup lvg = lv.Groups.Add(groupKey, groupHeader);
            lvi.Group = lvg;

            return lvi;
        }

        public static ListViewItem AddItemToGroup(this ListView lv, String itemKey,
            String itemText, String groupKey, String groupHeader)
        {
            return AddItemToGroup(lv, itemKey, itemText, null, groupKey, groupHeader);
        }

        public static ListViewItem AddItemToGroup(this ListView lv, 
            String itemText, String groupHeader)
        {
            return AddItemToGroup(lv, itemText, itemText, groupHeader, groupHeader);
        }
    }

    /// @}
}
