using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.OS
{
    /// <summary>
    /// Represent a manager for the windows 7 taskbar tools
    /// 
    /// <remarks>
    /// All methods can also called on Window Forms or WPF Windows with extension methods
    /// </remarks>
    /// </summary>
    public sealed class TaskBarManager : NativeWindow
    {
        private IntPtr hwnd = IntPtr.Zero;
        private ulong value = 0, max = 100;
        private TaskbarProgressBarStyle style = TaskbarProgressBarStyle.NoProgress;
        private string tooltip = "";
        private NativeRect? clip = null;
        private System.Drawing.Icon icon = null;
        private string description = "";
        private ThumbnailButtonManager buttonManager;
        private ThumbnailTabManager tabManager;

        public event EventHandler ValueChanged;
        public event EventHandler MaximumChanged;
        public event EventHandler StyleChanged;
        public event EventHandler ToolTipChanged;
        public event EventHandler ClipChanged;
        public event EventHandler OverlayIconChanged;
        public event EventHandler OverlayIconDescriptionChanged;

        public TaskBarManager(IntPtr hwnd)
        {
            this.hwnd = hwnd;

            tabManager = new ThumbnailTabManager(hwnd);
            buttonManager = new ThumbnailButtonManager(hwnd);

            this.AssignHandle(hwnd);
        }

        public TaskBarManager(System.Windows.Forms.Form form)
            : this(form.Handle)
        {
        }

        public TaskBarManager(System.Windows.Window win)
            : this(win.GetHandle())
        {
        }

        public ulong ProgressValue
        {
            get { return value; }
            set
            {
                this.value = value;
                Windows7TaskBar.SetProgressValue(hwnd, this.value, this.max);

                OnValueChanged();
                if (style != TaskbarProgressBarStyle.Normal)
                {
                    style = TaskbarProgressBarStyle.Normal;
                    OnStyleChanged();
                }
            }
        }

        public ulong ProgressMaximum
        {
            get { return value; }
            set
            {
                this.max = value;
                Windows7TaskBar.SetProgressValue(hwnd, this.value, this.max);

                OnMaximumChanged();
                if (style != TaskbarProgressBarStyle.Normal)
                {
                    style = TaskbarProgressBarStyle.Normal;
                    OnStyleChanged();
                }
            }
        }

        public TaskbarProgressBarStyle ProgressStyle
        {
            get { return style; }
            set
            {
                style = value;
                Windows7TaskBar.SetProgressStyle(hwnd, value);
                OnStyleChanged();
            }
        }

        public string ToolTip
        {
            get { return tooltip; }
            set
            {
                tooltip = value;
                OnToolTipChanged();
            }
        }

        public System.Drawing.Rectangle Clip
        {
            get
            {
                if (clip.HasValue)
                    return clip.Value;
                else
                    return System.Drawing.Rectangle.Empty;
            }
            set
            {
                clip = value;
                Windows7TaskBar.SetThumbnailClip(hwnd, clip);
                OnClipChanged();
            }
        }

        public System.Windows.Rect WPFClip
        {
            get
            {
                if (clip.HasValue)
                    return clip.Value;
                else
                    return System.Windows.Rect.Empty;
            }
            set
            {
                clip = value;
                Windows7TaskBar.SetThumbnailClip(hwnd, clip);
                OnClipChanged();
            }
        }

        public bool HasOverlayIcon
        {
            get { return icon != null; }
        }

        public System.Drawing.Icon OverlayIcon
        {
            get { return icon; }
            set
            {
                icon = value;
                Windows7TaskBar.SetOverlayIcon(hwnd, icon.Handle, description);
                OnOverlayIconChanged();
            }
        }

        public System.Windows.Media.Imaging.BitmapSource WPFOverlayIcon
        {
            get { return icon.ToBitmapSource(); }
            set
            {
                icon = value.ToIcon();
                Windows7TaskBar.SetOverlayIcon(hwnd, icon.Handle, description);
                OnOverlayIconChanged();
            }
        }

        public string OverlayIconDescription
        {
            get { return description; }
            set
            {
                description = value;
                Windows7TaskBar.SetOverlayIcon(hwnd, icon.Handle, description);
                OnOverlayIconDescriptionChanged();
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == COMConstants.COMCommands.WmTaskbarButtonCreated)
            {
                Log.Debug("Create thumb buttons");
                buttonManager.AddButtonsToTaskbar();
            }

            buttonManager.HandleEvents(ref m);

            base.WndProc(ref m);
        }

        #region Buttons

        public ThumbnailButton AddThumbnailButton(System.Drawing.Icon icon, String tooltip)
        {
            return buttonManager.AddButton(icon, tooltip);
        }

        public ThumbnailButton AddThumbnailButton(System.Windows.Media.Imaging.BitmapSource icon, String tooltip)
        {
            return buttonManager.AddButton(icon, tooltip);
        }

        public void RemoveButton(ThumbnailButton btn)
        {
            buttonManager.RemoveButton(btn);
        }

        #endregion

        #region Tabs

        public ThumbnailTab AddTab(IntPtr child)
        {
            return tabManager.AddTab(child);
        }

        public ThumbnailTab AddTab(System.Windows.Forms.Control c)
        {
            return tabManager.AddTab(c);
        }

        public void RemoveTab(ThumbnailTab tab)
        {
            tabManager.RemoveTab(tab);
        }

        #endregion

        #region On-Events

        private void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());
        }

        private void OnMaximumChanged()
        {
            if (MaximumChanged != null)
                MaximumChanged(this, new EventArgs());
        }

        private void OnStyleChanged()
        {
            if (StyleChanged != null)
                StyleChanged(this, new EventArgs());
        }

        private void OnToolTipChanged()
        {
            if (ToolTipChanged != null)
                ToolTipChanged(this, new EventArgs());
        }

        private void OnClipChanged()
        {
            if (ClipChanged != null)
                ClipChanged(this, new EventArgs());
        }

        private void OnOverlayIconChanged()
        {
            if (OverlayIconChanged != null)
                OverlayIconChanged(this, new EventArgs());
        }

        private void OnOverlayIconDescriptionChanged()
        {
            if (OverlayIconDescriptionChanged != null)
                OverlayIconDescriptionChanged(this, new EventArgs());
        }

        #endregion
    }
}
