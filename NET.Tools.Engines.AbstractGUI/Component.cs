using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Represent a component in the abstract GUI framework
    /// </summary>
    public abstract class Component
    {
        private bool hasFocus = false;
        private bool isVisible = true;
        private bool isEnabled = true;
        private String text;
        private IStyle style;
        private bool wasMouseInComponent = false;

        public event EventHandler PaintEvent;
        public event EventHandler RepaintEvent;
        public event EventHandler VisibleChanged;
        public event EventHandler EnabledChanged;
        public event EventHandler FocusChanged;
        public event EventHandler TextChanged;
        public event EventHandler StyleChanged;

        public event MouseEventHandler MouseMove;
        public event MouseEventHandler MouseEnter;
        public event MouseEventHandler MouseLeave;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Container Parent { get; internal set; } 

        public Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public Point Location
        {
            get{ return new Point(X, Y);}
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Rectangle Bounds
        {
            get{ return new Rectangle(Location, Size);}
            set
            {
                Location = value.Location;
                Size = value.Size;
            }
        }

        public virtual bool IsFocusable { get; set; }
        public bool HasFocus
        {
            get { return hasFocus; }
            internal set
            {
                hasFocus = value;
                if (FocusChanged != null)
                {
                    FocusChanged(this, new EventArgs());
                }
            }
        }

        public String Text
        {
            get { return text; }
            set
            {
                text = value;
                if (TextChanged != null)
                {
                    TextChanged(this, new EventArgs());
                }
            }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                if (EnabledChanged != null)
                {
                    EnabledChanged(this, new EventArgs());
                }
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                if (VisibleChanged != null)
                {
                    VisibleChanged(this, new EventArgs());
                }
            }
        }

        public IStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                if (StyleChanged != null)
                {
                    StyleChanged(this, new EventArgs());
                }
            }
        }

        internal IInputHandler InputHandler { get; set; }

        protected Component()
        {
            Text = GetType().Name;
            InputHandler.MouseMove += new MouseEventHandler(InputHandler_MouseMove);
        }

        private void InputHandler_MouseMove(object sender, MouseEventArgs e)
        {
            if (Bounds.IsPointInRect(e.Position))
            {
                style.OnMouseMove(this);
                if (MouseMove != null)
                {
                    MouseMove(this, e);
                }

                if (!wasMouseInComponent)
                {
                    style.OnMouseEnter(this);
                    if (MouseEnter != null)
                    {
                        MouseEnter(this, e);
                    }
                    wasMouseInComponent = true;
                }
            }
            else
            {
                if (wasMouseInComponent)
                {
                    style.OnMouseLeave(this);
                    if (MouseLeave != null)
                    {
                        MouseLeave(this, e);
                    }
                    wasMouseInComponent = false;
                }
            }
        }

        public void Paint()
        {
            if (!IsVisible)
                return;

            if (PaintEvent != null)
            {
                PaintEvent(this, new EventArgs());
            }

            OnPaint();
        }

        public void Repaint()
        {
            if (!IsVisible)
                return;

            if (RepaintEvent != null)
            {
                RepaintEvent(this, new EventArgs());
            }

            OnRepaint();
        }

        protected abstract void OnPaint();
        protected abstract void OnRepaint();
    }

    /// @}
}
