using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Represent a abstract basic for all abstract components
    /// </summary>
    public abstract class AbstractComponent : IAbstractComponent
    {
        private bool mouseDown = false;

        private bool isVisible = true;
        private bool isEnabled = true;
        private bool hasFocus = false;
        private String text = "";
        private IAbstractStyle style;
        private Rectangle bounds;
        private TextAlignment textAlign = TextAlignment.TopLeft;

        #region IAbstractElement<ColorType,int> Member

        public virtual bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnVisibilityChanged();
                    Refresh();
                }
            }
        }

        public virtual bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnEnableChanged();
                    Refresh();
                }
            }
        }

        public virtual bool IsFocusable
        {
            get;
            set;
        }

        public virtual bool HasFocus
        {
            get { return hasFocus; }
            set
            {
                if (hasFocus != value)
                {
                    hasFocus = value;
                    Refresh();
                }
            }
        }

        public virtual string Text
        {
            get { return text; }
            set
            {
                if (!text.Equals(value))
                {
                    String oldValue = text;
                    text = value;
                    if (OnTextChanged().Cancel)
                        text = oldValue;

                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the horizontal text alignment
        /// </summary>
        public TextAlignment TextAlignment
        {
            get { return textAlign; }
            set
            {
                if (!textAlign.Equals(value))
                {
                    textAlign = value;
                    OnTextAlignmentChanged();
                    Refresh();
                }
            }
        }

        public virtual IAbstractStyle Style
        {
            get { return style; }
            set
            {
                if (style == null)
                {
                    style = value;
                    return;
                }

                if (!style.Equals(value))
                {
                    style = value;
                    OnStyleChanged();
                    Refresh();
                }
            }
        }

        public virtual int Left
        {
            get
            {
                return Bounds.Left;
            }
            set
            {
                Bounds = new Rectangle(value, Top, Width, Height);
            }
        }

        public virtual int Top
        {
            get
            {
                return Bounds.Top;
            }
            set
            {
                Bounds = new Rectangle(Left, value, Width, Height);
            }
        }

        public virtual int Width
        {
            get
            {
                return Bounds.Width;
            }
            set
            {
                Bounds = new Rectangle(Left, Top, value, Height);
            }
        }

        public virtual int Height
        {
            get
            {
                return Bounds.Height;
            }
            set
            {
                Bounds = new Rectangle(Left, Top, Width, value);
            }
        }

        public virtual Point Location
        {
            get
            {
                return Bounds.Location;
            }
            set
            {
                Bounds = new Rectangle(value, Size);
            }
        }

        public virtual Size Size
        {
            get
            {
                return Bounds.Size;
            }
            set
            {
                Bounds = new Rectangle(Location, value);
            }
        }

        public virtual Rectangle Bounds
        {
            get { return bounds; }
            set
            {
                if (!bounds.Equals(value))
                {
                    Rectangle oldValue = bounds;
                    bounds = value;
                    if (OnBoundsChanged().Cancel)
                        bounds = oldValue;

                    Refresh();
                }
            }
        }

        public virtual void Focus()
        {
            FocusManager.SetFocus(this);
        }

        internal void SetFocus()
        {
            if (!IsFocusable)
                throw new InvalidOperationException("This object is not focusable!");

            if (HasFocus)
                return;

            HasFocus = true;
            OnGotFocus();
        }

        internal void ResetFocus()
        {
            if (!IsFocusable || !HasFocus)
                return;

            HasFocus = false;
            OnLostFocus();
        }

        public abstract void Refresh();

        public event EventHandler Click;
        public event MouseEventHandler MouseDown;
        public event MouseEventHandler MouseUp;
        public event MouseEventHandler MouseMove;
        public event MouseEventHandler MouseDragMove;

        public event EventHandler GotFocus;
        public event EventHandler LostFocus;

        public event EventHandler EnableChanged;
        public event EventHandler VisibilityChanged;
        public event CancelEventHandler TextChanged;
        public event CancelEventHandler BoundsChanged;
        public event EventHandler StyleChanged;
        public event EventHandler TextAlignmentChanged;

        #endregion

        #region IDisposable Member

        public abstract void Dispose();

        #endregion

        public AbstractComponent()
        {
            IsFocusable = true;
            IsVisible = true;
            IsEnabled = true;
            HasFocus = false;
        }

        internal virtual void Draw(Point origin)
        {
            DrawElement(origin);
        }

        protected abstract void DrawElement(Point origin);

        protected void OnClick()
        {
            if (Click != null)
                Click(this, new EventArgs());
        }

        protected void OnMouseDown(MouseEventArgs e)
        {
            if (MouseDown != null)
                MouseDown(this, e);
        }

        protected void OnMouseUp(MouseEventArgs e)
        {
            if (MouseUp != null)
                MouseUp(this, e);
        }

        protected void OnMouseMove(MouseEventArgs e)
        {
            if (MouseMove != null)
                MouseMove(this, e);
        }

        protected void OnMouseDragMove(MouseEventArgs e)
        {
            if (MouseDragMove != null)
                MouseDragMove(this, e);
        }

        protected void OnGotFocus()
        {
            if (GotFocus != null)
                GotFocus(this, new EventArgs());
        }

        protected void OnLostFocus()
        {
            if (LostFocus != null)
                LostFocus(this, new EventArgs());
        }

        protected void OnEnableChanged()
        {
            if (EnableChanged != null)
                EnableChanged(this, new EventArgs());
        }

        protected void OnVisibilityChanged()
        {
            if (VisibilityChanged != null)
                VisibilityChanged(this, new EventArgs());
        }

        protected CancelEventArgs OnTextChanged()
        {
            CancelEventArgs e = new CancelEventArgs();
            if (TextChanged != null)
                TextChanged(this, e);

            return e;
        }

        protected void OnStyleChanged()
        {
            if (StyleChanged != null)
                StyleChanged(this, new EventArgs());
        }

        protected CancelEventArgs OnBoundsChanged()
        {
            CancelEventArgs e = new CancelEventArgs();
            if (BoundsChanged != null)
                BoundsChanged(this, e);

            return e;
        }

        protected void OnTextAlignmentChanged()
        {
            if (TextAlignmentChanged != null)
                TextAlignmentChanged(this, new EventArgs());
        }

        /// <summary>
        /// Handle the input from input devices like mouse and keyboard
        /// </summary>
        /// protected abstract void HandleInput();

        /// <summary>
        /// Handle internal the mouse input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal virtual bool HandleMouseInput(MouseEventArgs e)
        {
            if (!IsEnabled || !IsVisible)
                return false;

            bool result = false;
            if (Bounds.IsPointInRect(e.Location))
            {
                if (e.Button != MouseButtons.None)
                {
                    if (!mouseDown)
                    {
                        mouseDown = true;
                        OnMouseDown(e);
                    }                   
                }
                else
                {
                    if (mouseDown)
                    {
                        mouseDown = false;
                        OnMouseUp(e);
                        OnClick();
                    }

                    OnMouseMove(e);
                }

                result = true;
            }

            //Drag-Move always
            if (e.Button != MouseButtons.None)
                OnMouseDragMove(e);

            return result;
        }
    }

    /// @}
}
