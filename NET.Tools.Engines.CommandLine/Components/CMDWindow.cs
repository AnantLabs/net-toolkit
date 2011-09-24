using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.AbstractGUI;
using System.Drawing;
using System.Windows.Forms;

namespace NET.Tools.Engines.CommandLine
{
    public sealed class CMDWindow : AbstractWindow<CMDWindowPalette>
    {
        protected override Rectangle TitlebarBounds
        {
            get { return new Rectangle(Location.X + 1, Location.Y, Width - 1, 1); }
        }

        public CMDWindow()
        {
            Style = GlobalCMDPalette.Palette.Window;
            Bounds = new Rectangle(0, 1, 50, 10);
            Text = "CMD Window";
            TextAlignment = TextAlignment.Center;

            BoundsChanged += new System.ComponentModel.CancelEventHandler(CMDWindow_BoundsChanged);
        }

        protected override void RegisterFrame()
        {
            CMDApplication.Desktop.Show(this);
        }

        protected override void UnregisterFrame()
        {
            CMDApplication.Desktop.Hide(this);
        }

        public override void Dispose()
        {
        }

        protected override void DrawElement(Point origin)
        {
            CMDDrawing.DrawDoubleLinedRectangle(InternalStyle.WindowColor, Location, Size);
            CMDDrawing.DrawText(InternalStyle.TextColor, TextAlignment, " " + Text + " ", 
                Location, Width);

            if (ShowCloseButton)
                CMDDrawing.DrawCloseButton(InternalStyle.CloseButtonColor, new Point(
                    Bounds.Right - 5, Location.Y));
            if (ShowMaximizeButton)
                CMDDrawing.DrawMaximizeButton(InternalStyle.MaximizeButtonColor, new Point(
                    Bounds.Right - 8, Location.Y));
            if (ShowMinimzeButton)
                CMDDrawing.DrawMinimizeButton(InternalStyle.MinimizeButtonColor, new Point(
                    Bounds.Right - 11, Location.Y));
        }

        protected override Rectangle MinimizeButtonBounds
        {
            get { return new Rectangle(Bounds.Right - 11, Location.Y, 2, 1); }
        }

        protected override Rectangle MaximizeButtonBounds
        {
            get { return new Rectangle(Bounds.Right - 8, Location.Y, 2, 1); }
        }

        protected override Rectangle CloseButtonBounds
        {
            get { return new Rectangle(Bounds.Right - 5, Location.Y, 2, 1); }
        }

        public override void Refresh()
        {
            CMDApplication.Refresh();
        }

        private void CMDWindow_BoundsChanged(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((Bounds.Left < 0) || (Bounds.Right > CMDApplication.BufferSize.Columns) ||
                (Bounds.Top < 1) || (Bounds.Bottom > CMDApplication.BufferSize.Rows))
                e.Cancel = true;
        }

        protected override Rectangle MaximumBounds
        {
            get
            {
                return new Rectangle(
                    0,
                    1,
                    CMDApplication.BufferSize.Columns,
                    CMDApplication.BufferSize.Rows - 1);
            }
        }
    }
}
