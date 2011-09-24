using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.AbstractGUI;
using System.Drawing;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent the basic desktop for GUI
    /// </summary>
    public sealed class CMDDesktop : AbstractDesktop<CMDPaletteItem>
    {
        /// <summary>
        /// Gets or sets the fill character
        /// </summary>
        public char FillCharacter { get; set; }

        public CMDDesktop()
        {
            FillCharacter = '░';
            Style = GlobalCMDPalette.Palette.Desktop;

            CMDApplication.MouseEvent += HandleMouseInput;
        }

        public override void Dispose()
        {
        }

        protected override void DrawElement(Point origin)
        {
            StringBuilder builder = new StringBuilder();
            for (int j = 0; j < CMDApplication.BufferSize.Rows - 2; j++)
                for (int i = 0; i < CMDApplication.BufferSize.Columns; i++)
                    builder.Append(FillCharacter);

            Console.ForegroundColor = InternalStyle.Foreground;
            Console.BackgroundColor = InternalStyle.Background;

            Console.Clear();

            Console.SetCursorPosition(0, 1);
            Console.Write(builder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public override void Refresh()
        {
            CMDApplication.Refresh();
        }
    }
}
