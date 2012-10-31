using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a basic class for all windows and dialogs
    /// </summary>
    public abstract class CMDFrame : CMDContainer
    {
        private Point? dragMove = null;

        /// <summary>
        /// Gets or sets the text color for this window
        /// </summary>
        public CMDPaletteItem TextColor { get; set; }
        /// <summary>
        /// Gets or sets the text alignment for the title of this window
        /// </summary>
        public CMDHorizontalAlignment TextAlignment { get; set; }
        /// <summary>
        /// Gets or sets the color for the closebutton on this window
        /// </summary>
        public CMDCloseButtonPalette CloseButtonColor { get; set; }

        /// <summary>
        /// Called if the window was closed
        /// </summary>
        public event EventHandler Closed;
        /// <summary>
        /// Called if the window is closed
        /// </summary>
        public event CancelEventHandler Closing;

        public CMDFrame()
        {
            Location = new Point(0, 0);
            Width = 50;
            Height = 20;
            Text = "My CMD Window";
            TextAlignment = CMDHorizontalAlignment.Center;

            CMDApplication.Desktop.FrameList.Add(this);

            MouseUp += new MouseEventHandler(CMDWindow_MouseUp);
            MouseDown += new MouseEventHandler(CMDFrame_MouseDown);
            MouseDragMove += new MouseEventHandler(CMDFrame_MouseDragMove);
        }

        /// <summary>
        /// Call the closed-event
        /// </summary>
        protected void OnClosed()
        {
            if (Closed != null)
                Closed(this, new EventArgs());
        }

        /// <summary>
        /// Call the closing-event
        /// </summary>
        /// <param name="e"></param>
        protected void OnClosing(CancelEventArgs e)
        {
            if (Closing != null)
                Closing(this, e);
        }

        private void CMDWindow_MouseUp(object sender, MouseEventArgs e)
        {
            dragMove = null;

            if ((e.X == Location.X + Width - 4) && (e.Y == Location.Y))
            {
                CancelEventArgs cancel = new CancelEventArgs(false);
                OnClosing(cancel);
                if (cancel.Cancel)
                    return;

                CMDApplication.Refresh();
                Close();

                OnClosed();
            }
        }

        private void CMDFrame_MouseDragMove(object sender, MouseEventArgs e)
        {
            if (dragMove.HasValue)
            {
                int difX = e.X - dragMove.Value.X;
                int difY = e.Y - dragMove.Value.Y;

                Location += new Size(difX, difY);
                if (Location.X < 0)
                    Location = new Point(0, Location.Y);
                if (Location.X + Width >= CMDApplication.BufferSize.Columns)
                    Location = new Point(CMDApplication.BufferSize.Columns - Width - 1, Location.Y);
                if (Location.Y < 0)
                    Location = new Point(Location.X, 0);
                if (Location.Y + Height >= CMDApplication.BufferSize.Rows)
                    Location = new Point(Location.X, CMDApplication.BufferSize.Rows - Height - 1);
                CMDApplication.Refresh();

                dragMove = e.Location;
            }
        }

        private void CMDFrame_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X >= Location.X) && (e.X <= Location.X + Width) &&
                (e.Y == Location.Y))
            {
                dragMove = e.Location;
            }
        }

        public void Show()
        {
            IsVisible = true;
        }

        public void Close()
        {
            IsVisible = false;
        }
    }
}
