using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    public static class Cards
    {
        [DllImport("cards", EntryPoint = "cdtInit")]
        public static extern bool cdtInit([In] ref int width, [In] ref int height);

        [DllImport("cards", EntryPoint = "cdtTerm")]
        public static extern void cdtTerm();

        [DllImport("cards", EntryPoint = "cdtDrawExt")]
        public static extern int cdtDrawExt(IntPtr hDC, int x, int y, int dx, int dy,
            int escCard, int ectDraw, int clr);

        [DllImport("cards", EntryPoint = "cdtDraw")]
        public static extern int cdtDraw(IntPtr hDC, int x, int y, int escCard,
            int ectDraw, int clr);

        [DllImport("cards", EntryPoint = "cdtAnimate")]
        public static extern int cdtAnimate(IntPtr hDC, int ecbCardBack, int x, int y,
            int iState);
    }

    /// \addtogroup enums
    /// @{

    /// <summary>
    /// Card suite (All card colors)
    /// </summary>
    public enum CardSuit : int
    {
        Clubs = 0,
        Diamonds = 1,
        Heards = 2,
        Spades = 3
    }

    /// <summary>
    /// Card decks (it is be able that the decks are changed between the windows versions)
    /// </summary>
    public enum CardDeck : int
    {
        CrossHatch = 53,
        Weave1 = 54,
        Weave2 = 55,
        Robot = 56,
        Flowers = 57,
        Vine1 = 58,
        Vine2 = 59,
        Fish1 = 60,
        Fish2 = 61,
        Shells = 62,
        Castle = 63,
        Island = 64,
        CardHand = 65,
        The_X = 67,
        The_O = 68
    }

    /// <summary>
    /// Type of cards (AS until King)
    /// </summary>
    public enum CardType : int
    {
        AS = 0,
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        Seven = 6,
        Eight = 7,
        Nine = 8,
        Ten = 9,
        Boy = 10,
        Girl = 11,
        King = 12
    }
    /// @}
}
