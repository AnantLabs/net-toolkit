using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent an abstract cmd element
    /// </summary>
    public abstract class CMDElement
    {
        private bool isVisible;

        /// <summary>
        /// Gets or sets the color for this element
        /// 
        /// As default it will be used the global console palette colors
        /// </summary>
        public CMDPaletteItem Color { get; set; }
        /// <summary>
        /// Gets or sets the visibility of this element
        /// </summary>
        public bool IsVisible {
            get { return isVisible; }
            set { if (isVisible != value) CMDApplication.Refresh(); isVisible = value; }
        }

        /// <summary>
        /// Called if the mouse was clicked on this element
        /// </summary>
        public event EventHandler Click;
        /// <summary>
        /// Called if the mouse draged on this element
        /// 
        /// One or more mouse buttons are clicked and the mouse drive over the element
        /// </summary>
        public event MouseEventHandler MouseDragMove;
        /// <summary>
        /// Called if a mouse button is pressed down
        /// </summary>
        public event MouseEventHandler MouseDown;
        /// <summary>
        /// Called if a mouse button is released
        /// </summary>
        public event MouseEventHandler MouseUp;
        /// <summary>
        /// Called if the mouse move over this element
        /// 
        /// No mouse button is pressed
        /// </summary>
        public event MouseEventHandler MouseMove;

        public CMDElement()
        {
            isVisible = true;
        }

        /// <summary>
        /// Call the Click-Event
        /// </summary>
        protected void OnClick()
        {
            if (Click != null)
                Click(this, new EventArgs());
        }

        /// <summary>
        /// Call the Mouse-Drag-Move-Event
        /// </summary>
        /// <param name="e"></param>
        protected void OnMouseDragMove(MouseEventArgs e)
        {
            if (MouseDragMove != null)
                MouseDragMove(this, e);
        }

        /// <summary>
        /// Call the Mouse-Move-Event
        /// </summary>
        /// <param name="e"></param>
        protected void OnMouseMove(MouseEventArgs e)
        {
            if (MouseMove != null)
                MouseMove(this, e);
        }

        /// <summary>
        /// Call the Mouse-Up-Event
        /// </summary>
        /// <param name="e"></param>
        protected void OnMouseUp(MouseEventArgs e)
        {
            if (MouseUp != null)
                MouseUp(this, e);
        }

        /// <summary>
        /// Call the Mouse-Down-Event
        /// </summary>
        /// <param name="e"></param>
        protected void OnMouseDown(MouseEventArgs e)
        {
            if (MouseDown != null)
                MouseDown(this, e);
        }

        internal void Draw()
        {
            if (IsVisible)
                DrawElement();
        }

        /// <summary>
        /// Drawing of this element. IsVisible is checked by Draw
        /// </summary>
        protected abstract void DrawElement();
    }
}
