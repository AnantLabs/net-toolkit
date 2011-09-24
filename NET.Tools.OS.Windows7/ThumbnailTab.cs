using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.OS
{
    /// <summary>
    /// Represent a thumbnail tab page
    /// </summary>
    public sealed class ThumbnailTab : IDisposable
    {
        private TabBehavior behavior = TabBehavior.None;
        private ThumbnailTabManager manager;

        internal IntPtr Parent { get { return manager.Root; } }
        internal IntPtr Child { get; private set; }

        /// <summary>
        /// TRUE if the tab is shown in taskbar
        /// </summary>
        public bool IsShown { get; private set; }

        internal ThumbnailTab(ThumbnailTabManager man, IntPtr child)
        {
            Log.Info("Create thumbnail tab for " + man.Root.ToInt64());
            this.Child = child;

            this.manager = man;
        }

        internal void AddTab()
        {
            Log.Debug("Add tab to thumbnail");
            Windows7TaskBar.RegisterTab(Parent, Child);
            Windows7TaskBar.SetTabOrder(Child, IntPtr.Zero);
            Windows7TaskBar.SetTabActive(Child, Parent);
            Windows7TaskBar.SetTabProperties(Child, TabBehavior.UseAppThumbnailWhenActive);
            IsShown = true;
        }

        internal void RemoveTab()
        {
            Log.Debug("Remove tab from thumbnail");
            Windows7TaskBar.UnregisterTab(Child);
            IsShown = false;
        }

        public void Activate(ThumbnailTab insertBefore)
        {
            Windows7TaskBar.SetTabActive(Child, insertBefore.Child);
        }

        public void Order(ThumbnailTab insertBefore)
        {
            Windows7TaskBar.SetTabOrder(Child, insertBefore.Child);
        }

        public TabBehavior Behavior
        {
            get { return behavior; }
            set
            {
                behavior = value;
                Windows7TaskBar.SetTabProperties(Child, behavior);
            }
        }

        #region IDisposable Member

        public void Dispose()
        {
            manager.RemoveTab(this);
        }

        #endregion
    }
}
