using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using NET.Tools.Engines.AbstractGUI;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Contains methods for drawing console elements
    /// </summary>
    public static class CMDDrawing
    {
        /// <summary>
        /// Draw a double-lined rectangle
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public static void DrawDoubleLinedRectangle(CMDPaletteItem palette, 
            Point location, Size size)
        {
            Console.ForegroundColor = palette.Foreground;
            Console.BackgroundColor = palette.Background;

            Console.SetCursorPosition(location.X, location.Y);

            Console.Write("╔");
            for (int i = 0; i < size.Width - 2; i++)
                Console.Write("═");
            Console.Write("╗");

            Console.SetCursorPosition(location.X, location.Y + 1);

            for (int j = 0; j < size.Height - 2; j++)
            {
                Console.Write("║");
                for (int i = 0; i < size.Width - 2; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("║");

                Console.SetCursorPosition(location.X, location.Y + 1 + j);
            }

            Console.Write("╚");
            for (int i = 0; i < size.Width - 2; i++)
                Console.Write("═");
            Console.Write("╝");
        }

        /// <summary>
        /// Draw a single-lined rectangle
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public static void DrawSingleLinedRectangle(CMDPaletteItem palette,
            Point location, Size size)
        {
            Console.ForegroundColor = palette.Foreground;
            Console.BackgroundColor = palette.Background;

            Console.SetCursorPosition(location.X, location.Y);

            Console.Write("┌");
            for (int i = 0; i < size.Width - 2; i++)
                Console.Write("─");
            Console.Write("┐");

            Console.SetCursorPosition(location.X, location.Y + 1);

            for (int j = 0; j < size.Height - 2; j++)
            {
                Console.Write("│");
                for (int i = 0; i < size.Width - 2; i++)
                    Console.Write(" ");
                Console.Write("│");

                Console.SetCursorPosition(location.X, location.Y + 1 + j);
            }

            Console.Write("└");
            for (int i = 0; i < size.Width - 2; i++)
                Console.Write("─");
            Console.Write("┘");
        }

        /// <summary>
        /// Draw a text line with a mnemonic
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="align"></param>
        /// <param name="text"></param>
        /// <param name="location"></param>
        /// <param name="width"></param>
        /*public static void DrawText(CMDMnemonicPalette palette, TextAlignment align, String text, Point location, int width)
        {
            Console.ForegroundColor = palette.MainColor.Foreground;
            Console.BackgroundColor = palette.MainColor.Background;

            int x = 0;

            switch (align)
            {
                case TextAlignment.TopLeft:
                    x = location.X;
                    break;
                case TextAlignment.Center:
                    x = location.X + (width / 2) - (text.Length / 2);
                    break;
                case TextAlignment.BottomRight:
                    x = location.X + width - text.Length;
                    break;
                default:
                    throw new NotImplementedException();
            }

            Console.CursorLeft = x;
            Console.CursorTop = location.Y;

            foreach (char c in text)
            {
                if (c == '&')
                {
                    Console.BackgroundColor = palette.MnemonicColor.Background;
                    Console.ForegroundColor = palette.MnemonicColor.Foreground;
                }
                else
                {
                    Console.Write(c);

                    if ((Console.BackgroundColor != palette.MainColor.Background) ||
                        (Console.ForegroundColor != palette.MainColor.Foreground))
                    {
                        Console.BackgroundColor = palette.MainColor.Background;
                        Console.ForegroundColor = palette.MainColor.Foreground;
                    }
                }
            }
        }*/

        /// <summary>
        /// Draw a text line
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="align"></param>
        /// <param name="text"></param>
        /// <param name="location"></param>
        /// <param name="width"></param>
        /*public static void DrawText(CMDPaletteItem palette, TextAlignment align, String text, Point location, int width)
        {
            DrawText(new CMDMnemonicPalette(palette, palette), align, text, location, width);
        }*/

        /// <summary>
        /// Draw a close button for a window
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="location"></param>
        public static void DrawCloseButton(CMDFrameButtonPalette palette, Point location)
        {
            Console.BackgroundColor = palette.SiteColor.Background;
            Console.ForegroundColor = palette.SiteColor.Foreground;

            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("[");
            Console.SetCursorPosition(location.X + 2, location.Y);
            Console.Write("]");

            Console.BackgroundColor = palette.ContentColor.Background;
            Console.ForegroundColor = palette.ContentColor.Foreground;

            Console.SetCursorPosition(location.X + 1, location.Y);
            Console.Write("X");
        }

        /// <summary>
        /// Draw a minimize button for a window
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="location"></param>
        public static void DrawMinimizeButton(CMDFrameButtonPalette palette, Point location)
        {
            Console.BackgroundColor = palette.SiteColor.Background;
            Console.ForegroundColor = palette.SiteColor.Foreground;

            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("[");
            Console.SetCursorPosition(location.X + 2, location.Y);
            Console.Write("]");

            Console.BackgroundColor = palette.ContentColor.Background;
            Console.ForegroundColor = palette.ContentColor.Foreground;

            Console.SetCursorPosition(location.X + 1, location.Y);
            Console.Write("_");
        }

        /// <summary>
        /// Draw a maximize button for a window
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="location"></param>
        public static void DrawMaximizeButton(CMDFrameButtonPalette palette, Point location)
        {
            Console.BackgroundColor = palette.SiteColor.Background;
            Console.ForegroundColor = palette.SiteColor.Foreground;

            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("[");
            Console.SetCursorPosition(location.X + 2, location.Y);
            Console.Write("]");

            Console.BackgroundColor = palette.ContentColor.Background;
            Console.ForegroundColor = palette.ContentColor.Foreground;

            Console.SetCursorPosition(location.X + 1, location.Y);
            Console.Write("■");
        }
    }
}
