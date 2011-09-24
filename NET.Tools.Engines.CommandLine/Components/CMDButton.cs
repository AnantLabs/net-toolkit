using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.AbstractGUI;
using System.Drawing;

namespace NET.Tools.Engines.CommandLine
{
    public sealed class CMDButton : AbstractButton<CMDMnemonicPalette>
    {
        public CMDButton()
        {
            Style = GlobalCMDPalette.Palette.Button;
            TextAlignment = TextAlignment.Center;
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
            Console.SetCursorPosition(origin.X + Location.X, origin.Y + Location.Y);
            Console.BackgroundColor = InternalStyle.MainColor.Background;

            for (int i = 0; i < Width; i++)
                Console.Write(" ");

            CMDDrawing.DrawText(InternalStyle, TextAlignment, Text, Location + new Size(origin), Width);
        }
    }
}
