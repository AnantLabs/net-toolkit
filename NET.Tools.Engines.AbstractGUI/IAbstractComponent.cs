using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Interface for a defualt abstract gui element
    /// </summary>
    public interface IAbstractComponent : IDisposable
    {
        /// <summary>
        /// Gets or sets the visibility
        /// </summary>
        bool IsVisible { get; set; }
        /// <summary>
        /// Gets or sets the enabled state
        /// </summary>
        bool IsEnabled { get; set; }
        /// <summary>
        /// Gets or sets the focusability
        /// </summary>
        bool IsFocusable { get; set; }
        /// <summary>
        /// Gets or sets the focus state
        /// </summary>
        bool HasFocus { get; set; }
        /// <summary>
        /// Gets or sets the text
        /// </summary>
        String Text { get; set; }
        /// <summary>
        /// Gets or sets the color for this element
        /// </summary>
        IAbstractStyle Style { get; set; }

        /// <summary>
        /// Gets or sets the left position of this element
        /// </summary>
        int Left { get; set; }
        /// <summary>
        /// Gets or sets the top position of this element
        /// </summary>
        int Top { get; set; }
        /// <summary>
        /// Gets or sets the width of this element
        /// </summary>
        int Width { get; set; }
        /// <summary>
        /// Gets or sets the height of this element
        /// </summary>
        int Height { get; set; }
        /// <summary>
        /// Gets or sets the location of this element
        /// </summary>
        Point Location { get; set; }
        /// <summary>
        /// Gets or sets the size of this element
        /// </summary>
        Size Size { get; set; }
        /// <summary>
        /// Gets or sets the bounds of this element
        /// </summary>
        Rectangle Bounds { get; set; }
        /// <summary>
        /// Gets or sets the horizontal text alignment
        /// </summary>
        TextAlignment TextAlignment { get; set; }

        /// <summary>
        /// Set the focus to this object
        /// </summary>
        void Focus();
        /// <summary>
        /// Refresh the element (repaint itself)
        /// </summary>
        void Refresh();

        /// <summary>
        /// Called if the mouse is clicked
        /// </summary>
        event EventHandler Click;
        /// <summary>
        /// Called if the mouse button is pressed down
        /// </summary>
        event MouseEventHandler MouseDown;
        /// <summary>
        /// Called if the mouse button is released
        /// </summary>
        event MouseEventHandler MouseUp;
        /// <summary>
        /// Called if the mouse move over this element without a mouse button is pressed
        /// </summary>
        event MouseEventHandler MouseMove;
        /// <summary>
        /// Called if the mouse move over the element with a pressed mouse button
        /// </summary>
        event MouseEventHandler MouseDragMove;
        /// <summary>
        /// Called if the component got the focus
        /// </summary>
        event EventHandler GotFocus;
        /// <summary>
        /// Called if the component lost the focus
        /// </summary>
        event EventHandler LostFocus;
        /// <summary>
        /// Called if the enable-state changed
        /// </summary>
        event EventHandler EnableChanged;
        /// <summary>
        /// Called if the visibility changed
        /// </summary>
        event EventHandler VisibilityChanged;
        /// <summary>
        /// Called if the text content changed
        /// </summary>
        event CancelEventHandler TextChanged;
        /// <summary>
        /// Called if the bounds of component changed
        /// </summary>
        event CancelEventHandler BoundsChanged;
        /// <summary>
        /// Called if the style of component changed
        /// </summary>
        event EventHandler StyleChanged;
        /// <summary>
        /// Called if the text alignment changed
        /// </summary>
        event EventHandler TextAlignmentChanged;
    }

    /// @}
}
