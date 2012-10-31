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
    /// Extensions for list boxes
    /// </summary>
    public static class ListBoxExtensions
    {
        /// <summary>
        /// Remove all current selected items in the list box
        /// </summary>
        /// <param name="lb"></param>
        public static void RemoveSelected(this ListBox lb)
        {
            if (lb.SelectionMode != SelectionMode.One)
            {
                while (lb.SelectedItems.Count > 0)
                    lb.Items.Remove(lb.SelectedItems[0]);
            }
            else
            {
                lb.Items.Remove(lb.SelectedItem);
            }
        }
    }
    /// @}
}
