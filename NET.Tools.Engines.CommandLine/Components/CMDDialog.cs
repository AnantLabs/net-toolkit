using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.AbstractGUI;
using System.Drawing;

namespace NET.Tools.Engines.CommandLine
{
    public sealed class CMDDialog : AbstractDialog<CMDFramePalette>
    {
        public CMDDialog()
        {
            Style = GlobalCMDPalette.Palette.Dialog;
            Bounds = new Rectangle(0, 1, 25, 20);
            Text = "CMD Dialog";
            TextAlignment = TextAlignment.Center;

            BoundsChanged += new System.ComponentModel.CancelEventHandler(CMDDialog_BoundsChanged);
        }

        private void CMDDialog_BoundsChanged(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((Bounds.Left < 0) || (Bounds.Right > CMDApplication.BufferSize.Columns) ||
                (Bounds.Top < 1) || (Bounds.Bottom > CMDApplication.BufferSize.Rows))
                e.Cancel = true;
        }

        protected override Rectangle TitlebarBounds
        {
            get { return new Rectangle(Location.X + 1, Location.Y, Width - 1, 1); }
        }

        protected override Rectangle CloseButtonBounds
        {
            get { return new Rectangle(Bounds.Right - 5, Location.Y, 2, 1); }
        }

        protected override void RegisterFrame()
        {
            CMDApplication.Desktop.Show(this);
        }

        protected override void UnregisterFrame()
        {
            CMDApplication.Desktop.Hide(this);
        }

        public override void Refresh()
        {
            CMDApplication.Refresh();
        }

        public override void Dispose()
        {
        }

        protected override void DrawElement(Point origin)
        {
            CMDDrawing.DrawSingleLinedRectangle(InternalStyle.WindowColor, Location, Size);
            CMDDrawing.DrawText(InternalStyle.TextColor, TextAlignment, " " + Text + " ", 
                Location, Width);

            if (ShowCloseButton)
                CMDDrawing.DrawCloseButton(InternalStyle.CloseButtonColor, new Point(
                    Bounds.Right - 5, Location.Y));
        }
    }
}
