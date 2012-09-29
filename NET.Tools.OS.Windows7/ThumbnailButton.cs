using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using log4net;

namespace NET.Tools.OS
{
    /// <summary>
    /// Represent a thumbnail button for the windows 7 taskbar
    /// </summary>
    public class ThumbnailButton : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(ThumbnailButton));

        #region Static Memebrs

        private static ThumbButtonMask Mask
        {
            get
            {
                return ThumbButtonMask.Icon | ThumbButtonMask.THB_FLAGS | ThumbButtonMask.Tooltip;
            }
        }

        private static IList<uint> ids = new List<uint>();

        private static uint CreateID()
        {
            uint res = 0;
            while (ids.Contains(res))
                res++;

            return res;
        }

        private static void RemoveID(uint id)
        {
            ids.Remove(id);
        }

        #endregion

        private ThumbButtonOptions options;
        private ThumbnailButtonManager manager;

        public Icon Icon { get; set; }
        public String ToolTip { get; set; }
        public uint ID { get; private set; }
        public System.Windows.Media.Imaging.BitmapSource WPFIcon
        {
            get { return Icon.ToBitmapSource(); }
            set { Icon = value.ToIcon(); }
        }

        /// <summary>
        /// Is called if the button is pressed
        /// </summary>
        public event EventHandler Click;
        public event EventHandler VisibleChanged;
        public event EventHandler EnabledChanged;
        public event EventHandler BackgroundChanged;
        public event EventHandler DismissionChanged;
        public event EventHandler Update;

        public bool Enabled
        {
            get { return (options & ThumbButtonOptions.Disabled) == 0; }
            set
            {
                if (value == Enabled)
                    return;

                if (value)
                    options ^= ThumbButtonOptions.Disabled;
                else
                    options |= ThumbButtonOptions.Disabled;

                OnEnabledChanged();
                OnUpdate();
            }
        }

        public bool Visible
        {
            get { return (options & ThumbButtonOptions.Hidden) == 0; }
            set
            {
                if (value == Visible)
                    return;

                if (value)
                    options ^= ThumbButtonOptions.Hidden;
                else
                    options |= ThumbButtonOptions.Hidden;

                OnVisibleChanged();
                OnUpdate();
            }
        }

        public bool HasBackground
        {
            get { return (options & ThumbButtonOptions.NoBackground) == 0; }
            set
            {
                if (value == HasBackground)
                    return;

                if (value)
                    options ^= ThumbButtonOptions.NoBackground;
                else
                    options |= ThumbButtonOptions.NoBackground;

                OnBackgroundChanged();
                OnUpdate();
            }
        }

        public bool DismissOnClick
        {
            get { return (options & ThumbButtonOptions.DismissOnClick) != 0; }
            set
            {
                if (value == DismissOnClick)
                    return;

                if (value)
                    options |= ThumbButtonOptions.DismissOnClick;
                else
                    options ^= ThumbButtonOptions.DismissOnClick;

                OnDismissionChanged();
                OnUpdate();
            }
        }

        public IntPtr Parent
        {
            get { return manager.Root; }
        }

        internal ThumbnailButton(ThumbnailButtonManager man, Icon icon, string tooltip)
        {
            LOG.Info("Create thumbnail button for " + man.Root.ToInt64());

            Icon = icon;
            ToolTip = tooltip;

            ID = CreateID();
            options = ThumbButtonOptions.Enabled;
            manager = man;
        }

        internal void AddButton()
        {
            LOG.Debug("Add thumbnail button");
            Windows7TaskBar.UpdateThumbnailButtons(Parent, this.ToThumbButton());
            Windows7TaskBar.AddThumbnailButtons(Parent, this.ToThumbButton());
        }

        internal void RemoveButton()
        {
            LOG.Debug("Remove thumbnail button");
            Visible = false;
        }

        private ThumbButton ToThumbButton()
        {
            LOG.Debug("Convert to ThumbButton...");

            ThumbButton btn = new ThumbButton();
            btn.Bitmap = 0;
            btn.Flags = options;
            btn.Icon = Icon.Handle;
            btn.Id = ID;
            btn.Mask = Mask;
            btn.Tip = ToolTip;

            LOG.Debug(">>> OK");
            return btn;
        }

        internal void OnWndProc(ref Message msg)
        {
            LOG.Debug("Thumbnail Button: Do Action");

            WmCommandResult res = MessageInterpreter.CheckWmCommand(msg);
            if ((res != null) && (ID == res.ID))
            {
                switch (res.MouseAction)
                {
                    case MouseAction.Clicked:
                        OnClick();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        #region IDisposable Member

        public void Dispose()
        {
            RemoveID(ID);
            manager.RemoveButton(this);
        }

        #endregion

        #region ON-Event

        protected virtual void OnClick()
        {
            if (Click != null)
                Click(this, new EventArgs());
        }

        protected virtual void OnVisibleChanged()
        {
            if (VisibleChanged != null)
                VisibleChanged(this, new EventArgs());
        }

        protected virtual void OnEnabledChanged()
        {
            if (EnabledChanged != null)
                EnabledChanged(this, new EventArgs());
        }

        protected virtual void OnBackgroundChanged()
        {
            if (BackgroundChanged != null)
                BackgroundChanged(this, new EventArgs());
        }

        protected virtual void OnDismissionChanged()
        {
            if (DismissionChanged != null)
                DismissionChanged(this, new EventArgs());
        }

        protected virtual void OnUpdate()
        {
            if (Update != null)
                Update(this, new EventArgs());

            LOG.Debug("Thumbnail Button: Update Taskbar");
            Windows7TaskBar.UpdateThumbnailButtons(Parent, this.ToThumbButton());
        }

        #endregion
    }
}
