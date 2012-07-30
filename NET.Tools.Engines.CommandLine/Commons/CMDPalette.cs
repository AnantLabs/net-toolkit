using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.AbstractGUI;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a console color palette
    /// </summary>
    public sealed class CMDPalette
    {
        #region Static

        public static CMDPalette TurboVisionPalette
        {
            get
            {
                CMDPalette palette = new CMDPalette();

                palette.Window = new CMDWindowPalette(
                    new CMDPaletteItem(ConsoleColor.White, ConsoleColor.Blue),
                    new CMDPaletteItem(ConsoleColor.White, ConsoleColor.Blue),
                    new CMDFrameButtonPalette(
                        new CMDPaletteItem(ConsoleColor.White, ConsoleColor.Blue),
                        new CMDPaletteItem(ConsoleColor.Green, ConsoleColor.Blue)),
                    new CMDFrameButtonPalette(
                        new CMDPaletteItem(ConsoleColor.White, ConsoleColor.Blue),
                        new CMDPaletteItem(ConsoleColor.Green, ConsoleColor.Blue)),
                    new CMDFrameButtonPalette(
                        new CMDPaletteItem(ConsoleColor.White, ConsoleColor.Blue),
                        new CMDPaletteItem(ConsoleColor.Green, ConsoleColor.Blue)));
                palette.Dialog = new CMDFramePalette(
                    new CMDPaletteItem(ConsoleColor.Black, ConsoleColor.Gray),
                    new CMDPaletteItem(ConsoleColor.Black, ConsoleColor.Gray),
                    new CMDFrameButtonPalette(
                        new CMDPaletteItem(ConsoleColor.Black, ConsoleColor.Gray),
                        new CMDPaletteItem(ConsoleColor.White, ConsoleColor.Gray)));
                palette.Desktop = new CMDPaletteItem(ConsoleColor.Blue, ConsoleColor.Gray);
                palette.Button = new CMDMnemonicPalette(
                    new CMDPaletteItem(ConsoleColor.Yellow, ConsoleColor.DarkGreen),
                    new CMDPaletteItem(ConsoleColor.White, ConsoleColor.DarkGreen));

                return palette;
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the window palette
        /// </summary>
        public CMDFramePalette Window { get; set; }
        /// <summary>
        /// Gets or sets the dialog palette
        /// </summary>
        public CMDFramePalette Dialog { get; set; }
        /// <summary>
        /// Gets or sets the desktop palette
        /// </summary>
        public CMDPaletteItem Desktop { get; set; }
        /// <summary>
        /// Gets or sets the button palette
        /// </summary>
        public CMDMnemonicPalette Button { get; set; }

        public CMDPalette()
        {            
        }
    }

    public class CMDWindowPalette : CMDFramePalette
    {
        /// <summary>
        /// Gets the color for the minimize button on this window
        /// </summary>
        public CMDFrameButtonPalette MinimizeButtonColor { get; private set; }
        /// <summary>
        /// Gets the color for the maximize button on this window
        /// </summary>
        public CMDFrameButtonPalette MaximizeButtonColor { get; private set; }

        public CMDWindowPalette(CMDPaletteItem window, CMDPaletteItem text, 
            CMDFrameButtonPalette closeButton, CMDFrameButtonPalette minimizeButton,
            CMDFrameButtonPalette maximizeButton) 
            : base(window, text, closeButton)
        {
            MinimizeButtonColor = minimizeButton;
            MaximizeButtonColor = maximizeButton;
        }
    }

    public class CMDFramePalette
    {
        /// <summary>
        /// Gets the color only for windows
        /// </summary>
        public CMDPaletteItem WindowColor { get; private set; }
        /// <summary>
        /// Gets the color only for text
        /// </summary>
        public CMDPaletteItem TextColor { get; private set; }
        /// <summary>
        /// Gets the color for the close button on this window
        /// </summary>
        public CMDFrameButtonPalette CloseButtonColor { get; private set; }        

        public CMDFramePalette(CMDPaletteItem window, CMDPaletteItem text, 
            CMDFrameButtonPalette closeButton)
        {
            WindowColor = window;
            TextColor = text;
            CloseButtonColor = closeButton;
        }
    }

    /// <summary>
    /// Represent a mnemonic palette
    /// </summary>
    public class CMDMnemonicPalette
    {
        /// <summary>
        /// Gets Mnemonic color
        /// </summary>
        public CMDPaletteItem MnemonicColor { get; private set; }
        /// <summary>
        /// Gets main color
        /// </summary>
        public CMDPaletteItem MainColor { get; private set; }

        public CMDMnemonicPalette(CMDPaletteItem mnemonic, CMDPaletteItem main)
        {
            MnemonicColor = mnemonic;
            MainColor = main;
        }
    }

    /// <summary>
    /// Represent a console window close button palette
    /// </summary>
    public class CMDFrameButtonPalette
    {
        /// <summary>
        /// Site color of button ([])
        /// </summary>
        public CMDPaletteItem SiteColor { get; private set; }
        /// <summary>
        /// Content color of button (X)
        /// </summary>
        public CMDPaletteItem ContentColor { get; private set; }

        public CMDFrameButtonPalette(CMDPaletteItem site, CMDPaletteItem content)
        {
            this.SiteColor = site;
            this.ContentColor = content;
        }
    }

    /// <summary>
    /// Represent a console palette item
    /// </summary>
    public class CMDPaletteItem
    {
        /// <summary>
        /// Foreground color
        /// </summary>
        public ConsoleColor Foreground { get; private set; }
        /// <summary>
        /// Background color
        /// </summary>
        public ConsoleColor Background { get; private set; }

        public CMDPaletteItem(ConsoleColor fore, ConsoleColor back)
        {
            Foreground = fore;
            Background = back;
        }
    }
}
