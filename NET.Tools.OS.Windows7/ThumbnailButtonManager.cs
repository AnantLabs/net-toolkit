using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace NET.Tools.OS
{
    /// <summary>
    /// Represent a manager for thumbnail buttons
    /// </summary>
    public sealed class ThumbnailButtonManager
    {
        private IList<ThumbnailButton> buttonList = new List<ThumbnailButton>();

        public IntPtr Root { get; private set; }

        /// <summary>
        /// Collection of all registered buttons
        /// </summary>
        public ReadOnlyCollection<ThumbnailButton> ButtonList
        {
            get { return new ReadOnlyCollection<ThumbnailButton>(buttonList); }
        }

        internal ThumbnailButtonManager(IntPtr hwnd)
        {
            Root = hwnd;
        }

        public ThumbnailButton AddButton(System.Drawing.Icon icon, string tooltip)
        {
            ThumbnailButton btn = new ThumbnailButton(this, icon, tooltip);
            buttonList.Add(btn);
            return btn;
        }

        public ThumbnailButton AddButton(System.Windows.Media.Imaging.BitmapSource icon, string tooltip)
        {
            return AddButton(icon.ToIcon(), tooltip);
        }

        public void RemoveButton(ThumbnailButton btn)
        {
            btn.RemoveButton();
            buttonList.Remove(btn);
        }

        internal void AddButtonsToTaskbar()
        {
            foreach (ThumbnailButton btn in buttonList)
                btn.AddButton();
        }

        internal void HandleEvents(ref Message msg)
        {
            foreach (ThumbnailButton btn in buttonList)
                btn.OnWndProc(ref msg);
        }
    }
}
