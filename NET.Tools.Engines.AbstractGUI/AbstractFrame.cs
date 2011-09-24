using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Represent a frame
    /// </summary>
    public abstract class AbstractFrame : AbstractContainer, IAbstractFrame
    {
        private WindowState windowState = WindowState.Normal;
        private bool activate = false;

        #region IAbstractFrame Member

        public virtual bool ShowCloseButton
        {
            get;
            set;
        }

        public virtual WindowState WindowState
        {
            get { return windowState; }
            set
            {
                if (!windowState.Equals(value))
                {
                    WindowState oldValue = windowState;
                    windowState = value;
                    if (OnWindowStateChanged().Cancel)
                        windowState = value;

                    Refresh();
                }
            }
        }

        public bool IsActivated
        {
            get { return activate; }
        }

        public virtual void Show()
        {
            IsVisible = true;
            activate = true;
            Refresh();

            OnFrameShow();
            OnFrameActivated();
            RegisterFrame();
        }

        public virtual void Close()
        {
            if (OnFrameClosing().Cancel)
                return;

            IsVisible = false;
            activate = false;

            OnFrameClosed();
            OnFrameDeactivated();
            UnregisterFrame();
        }

        public virtual void BringToFront()
        {
            RegisterFrame();
            activate = true;

            OnFrameActivated();
            Refresh();
        }

        public event EventHandler FrameClosed;
        public event CancelEventHandler FrameClosing;
        public event EventHandler FrameShow;
        public event EventHandler FrameResize;
        public event EventHandler FrameDragging;
        public event EventHandler FrameActivated;
        public event EventHandler FrameDeactivated;

        public event CancelEventHandler WindowStateChanged;

        #endregion

        /// <summary>
        /// Defines the titlebar bounds for frame dragging
        /// </summary>
        protected abstract Rectangle TitlebarBounds { get; }
        /// <summary>
        /// Defines the bounds foir the close button
        /// </summary>
        protected abstract Rectangle CloseButtonBounds { get; }

        //Only for titlebar dragging
        private Point? lastDragPoint = null;

        public AbstractFrame()
            : base()
        {
            IsVisible = false;
            ShowCloseButton = true;
            IsFocusable = false;

            MouseDown += new System.Windows.Forms.MouseEventHandler(AbstractFrame_MouseDown);
            MouseUp += new System.Windows.Forms.MouseEventHandler(AbstractFrame_MouseUp);
            MouseDragMove += new System.Windows.Forms.MouseEventHandler(AbstractFrame_MouseDragMove);
        }

        protected void OnFrameClosed()
        {
            if (FrameClosed != null)
                FrameClosed(this, new EventArgs());
        }

        protected CancelEventArgs OnFrameClosing()
        {
            CancelEventArgs args = new CancelEventArgs(false);
            if (FrameClosing != null)
                FrameClosing(this, args);

            return args;
        }

        protected void OnFrameShow()
        {
            if (FrameShow != null)
                FrameShow(this, new EventArgs());
        }

        protected void OnFrameResize()
        {
            if (FrameResize != null)
                FrameResize(this, new EventArgs());
        }

        protected void OnFrameDrag()
        {
            if (FrameDragging != null)
                FrameDragging(this, new EventArgs());
        }

        protected CancelEventArgs OnWindowStateChanged()
        {
            CancelEventArgs e = new CancelEventArgs();
            if (WindowStateChanged != null)
                WindowStateChanged(this, e);

            return e;
        }

        protected void OnFrameActivated()
        {
            if (FrameActivated != null)
                FrameActivated(this, new EventArgs());
        }

        protected void OnFrameDeactivated()
        {
            if (FrameDeactivated != null)
                FrameDeactivated(this, new EventArgs());
        }

        /// <summary>
        /// Register the frame on the implemented desktop
        /// </summary>
        protected abstract void RegisterFrame();
        /// <summary>
        /// Unregister the frame on the implemented desktop
        /// </summary>
        protected abstract void UnregisterFrame();

        private void AbstractFrame_MouseDown(object sender, MouseEventArgs e)
        {
            BringToFront();

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (TitlebarBounds.IsPointInRect(e.Location))
                {
                    lastDragPoint = e.Location;
                }
            }
        }

        private void AbstractFrame_MouseDragMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Location += new Size(
                    e.X - lastDragPoint.Value.X, 
                    e.Y - lastDragPoint.Value.Y);

                lastDragPoint = e.Location;
            }
        }

        private void AbstractFrame_MouseUp(object sender, MouseEventArgs e)
        {
            if (CloseButtonBounds.IsPointInRect(e.Location))
                Close();

            if (lastDragPoint.HasValue)
            {
                lastDragPoint = null;
            }
        }
    }

    /// @}
}
