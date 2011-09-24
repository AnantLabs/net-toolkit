using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Interface for the abstract frame
    /// </summary>
    public interface IAbstractFrame
    {
        /// <summary>
        /// Gets or sets the visibility of the close button
        /// </summary>
        bool ShowCloseButton { get; set; }
        /// <summary>
        /// Gets or sets the window state
        /// </summary>
        WindowState WindowState { get; set; }
        /// <summary>
        /// Gets the activate state
        /// </summary>
        bool IsActivated { get; }

        /// <summary>
        /// Show the window
        /// </summary>
        void Show();
        /// <summary>
        /// Close the window
        /// </summary>
        void Close();
        /// <summary>
        /// Bring the frame to front
        /// </summary>
        void BringToFront();

        /// <summary>
        /// Called if the frame was closed
        /// </summary>
        event EventHandler FrameClosed;
        /// <summary>
        /// Called if the frame is closed
        /// 
        /// You can stop the window closing here
        /// </summary>
        event CancelEventHandler FrameClosing;
        /// <summary>
        /// Called if the frame is shown
        /// </summary>
        event EventHandler FrameShow;
        /// <summary>
        /// Called if the frame is resized
        /// 
        /// It is called if the width and height is changed and if the window is 
        /// change window state to minimized or maximized
        /// </summary>
        event EventHandler FrameResize;
        /// <summary>
        /// Called if the frame is draged with help of its title bar
        /// </summary>
        event EventHandler FrameDragging;
        /// <summary>
        /// Called if the window state changed
        /// </summary>
        event CancelEventHandler WindowStateChanged;
        /// <summary>
        /// Called if the frame is activated
        /// </summary>
        event EventHandler FrameActivated;
        /// <summary>
        /// Called if the frame is deactivated
        /// </summary>
        event EventHandler FrameDeactivated;
    }

    /// @}
}
