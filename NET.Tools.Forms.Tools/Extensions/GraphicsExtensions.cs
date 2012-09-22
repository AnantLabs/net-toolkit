using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using NET.Tools.OS;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Graphic
    /// 
    /// Contains this main extensions:
    /// - Drawing Cube 3D
    /// - Filled Cube 3D
    /// - Draw Graph with individual function
    /// - Draw Background for a graph
    /// - Draw Cards from window cards.dll
    /// </summary>
    public static class GraphicsExtensions
    {
        #region Inner Classes

        private static class CardsWrapper
        {
            private static int defWidth, defHeight;
            private static bool isInitialized = false;

            static CardsWrapper()
            {
                try
                {
                    bool res = Cards.cdtInit(ref defWidth, ref defHeight);
                    if (!res)
                        throw new ApplicationException("Cannot load cards.dll!");

                    AppDomain.CurrentDomain.ProcessExit += (s, e) => { Cards.cdtTerm(); };
                    isInitialized = true;
                }
                catch (Exception)
                {
                    isInitialized = false;
                }
            }

            public static void DrawFace(Graphics g, int x, int y, int width, int height,
                int faceValue, CardSuit suit, Color invColor)
            {
                if (!isInitialized)
                    return;

                if ((faceValue < 0) || (faceValue > 12))
                    throw new ArgumentOutOfRangeException("FaceValue", faceValue, "FaceValue must be in the range 0 - 12!");

                int cardValue = (int)suit + faceValue * 4;
                IntPtr hDC = g.GetHdc();

                try
                {
                    Cards.cdtDrawExt(hDC, x, y, width, height, cardValue,
                        invColor != Color.Empty ? 2 : 0, invColor.ToBGR());
                }
                finally
                {
                    g.ReleaseHdc(hDC);
                }
            }

            public static void DrawFace(Graphics g, int x, int y, int faceValue, 
                CardSuit suit, Color invColor)
            {
                if (!isInitialized)
                    return;

                if ((faceValue < 0) || (faceValue > 12))
                    throw new ArgumentOutOfRangeException("FaceValue", faceValue, "FaceValue must be in the range 0 - 12!");

                int cardValue = (int)suit + faceValue * 4;
                IntPtr hDC = g.GetHdc();

                try
                {
                    Cards.cdtDraw(hDC, x, y, cardValue,
                        invColor != Color.Empty ? 2 : 0, invColor.ToBGR());
                }
                finally
                {
                    g.ReleaseHdc(hDC);
                }
            }

            public static void DrawDeck(Graphics g, int x, int y, int width, int height,
                CardDeck deck, Color color)
            {
                if (!isInitialized)
                    return;

                IntPtr hDC = g.GetHdc();
                try
                {
                    Cards.cdtDrawExt(hDC, x, y, width, height, (int)deck, 1, color.ToBGR());
                }
                finally
                {
                    g.ReleaseHdc(hDC);
                }
            }

            public static void DrawDeck(Graphics g, int x, int y, CardDeck deck, Color color)
            {
                if (!isInitialized)
                    return;

                IntPtr hDC = g.GetHdc();
                try
                {
                    Cards.cdtDraw(hDC, x, y, (int)deck, 1, color.ToBGR());
                }
                finally
                {
                    g.ReleaseHdc(hDC);
                }
            }
        }

        #endregion

        #region Inner Enums

        //private enum Pyramid3DPart
        //{
        //    Floor,
        //    Noth,
        //    East,
        //    South,
        //    West
        //}

        private enum Alignment
        {
            LeftTop,
            Center,
            RightBottom
        }

        #endregion

        //#region Pyramid3D

        //#endregion

        #region Cards

        public static void DrawCardFace(this Graphics g, int x, int y, int width, int height,
            CardSuit suit, CardType type, Color invColor)
        {
            CardsWrapper.DrawFace(g, x, y, width, height, (int)type, suit, invColor);
        }

        public static void DrawCardFace(this Graphics g, int x, int y, int width, int height,
            CardSuit suit, CardType type)
        {
            CardsWrapper.DrawFace(g, x, y, width, height, (int)type, suit, Color.Empty);
        }

        public static void DrawCardFace(this Graphics g, Rectangle rect,
            CardSuit suit, CardType type)
        {
            CardsWrapper.DrawFace(g, rect.X, rect.Y, rect.Width, rect.Height, (int)type, suit, Color.Empty);
        }

        public static void DrawCardFace(this Graphics g, int x, int y,
            CardSuit suit, CardType type, Color invColor)
        {
            CardsWrapper.DrawFace(g, x, y, (int)type, suit, invColor);
        }

        public static void DrawCardFace(this Graphics g, int x, int y,
            CardSuit suit, CardType type)
        {
            CardsWrapper.DrawFace(g, x, y, (int)type, suit, Color.Empty);
        }

        public static void DrawCardFace(this Graphics g, Point point,
            CardSuit suit, CardType type)
        {
            CardsWrapper.DrawFace(g, point.X, point.Y, (int)type, suit, Color.Empty);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y, int width, int height,
            CardDeck deck, Color invColor)
        {
            CardsWrapper.DrawDeck(g, x, y, width, height, deck, invColor);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y, int width, int height,
            CardDeck deck)
        {
            CardsWrapper.DrawDeck(g, x, y, width, height, deck, Color.Empty);
        }

        public static void DrawCardDeck(this Graphics g, Rectangle rect,
            CardDeck deck)
        {
            CardsWrapper.DrawDeck(g, rect.X, rect.Y, rect.Width, rect.Height, deck, Color.Empty);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y, int width, int height,
            Color invColor)
        {
            CardsWrapper.DrawDeck(g, x, y, width, height, CardDeck.CrossHatch, invColor);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y, int width, int height)
        {
            CardsWrapper.DrawDeck(g, x, y, width, height, CardDeck.CrossHatch, Color.Black);
        }

        public static void DrawCardDeck(this Graphics g, Rectangle rect)
        {
            CardsWrapper.DrawDeck(g, rect.X, rect.Y, rect.Width, rect.Height, CardDeck.CrossHatch, Color.Black);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y,
            CardDeck deck, Color invColor)
        {
            CardsWrapper.DrawDeck(g, x, y, deck, invColor);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y,
            CardDeck deck)
        {
            CardsWrapper.DrawDeck(g, x, y, deck, Color.Empty);
        }

        public static void DrawCardDeck(this Graphics g, Point point,
            CardDeck deck)
        {
            CardsWrapper.DrawDeck(g, point.X, point.Y, deck, Color.Empty);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y, Color invColor)
        {
            CardsWrapper.DrawDeck(g, x, y, CardDeck.CrossHatch, invColor);
        }

        public static void DrawCardDeck(this Graphics g, int x, int y)
        {
            CardsWrapper.DrawDeck(g, x, y, CardDeck.CrossHatch, Color.Empty);
        }

        public static void DrawCardDeck(this Graphics g, Point point)
        {
            CardsWrapper.DrawDeck(g, point.X, point.Y, CardDeck.CrossHatch, Color.Empty);
        }

        #endregion

        #region Others

        /// <summary>
        /// Draw a string with the given content alignment
        /// </summary>
        /// <param name="g"></param>
        /// <param name="str">String to draw</param>
        /// <param name="font">Font to use to draw this string</param>
        /// <param name="brush">Brush to use to draw this string</param>
        /// <param name="rect">Rectangle with the string (<b>no cutting!</b>)</param>
        /// <param name="alignment">The alignment of string to the given rectangle</param>
        public static void DrawString(this Graphics g, String str, Font font, Brush brush, RectangleF rect, ContentAlignment alignment)
        {
            SizeF size = font.GetStringSize(str);
            float x = rect.X;
            float y = rect.Y;

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    x = GetAlignment(Alignment.Center, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.RightBottom, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    x = GetAlignment(Alignment.LeftTop, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.RightBottom, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.BottomRight:
                    x = GetAlignment(Alignment.RightBottom, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.RightBottom, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    x = GetAlignment(Alignment.Center, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.Center, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    x = GetAlignment(Alignment.LeftTop, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.Center, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    x = GetAlignment(Alignment.RightBottom, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.Center, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.TopCenter:
                    x = GetAlignment(Alignment.Center, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.LeftTop, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.TopLeft:
                    x = GetAlignment(Alignment.LeftTop, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.LeftTop, rect.Y, rect.Height, size.Height);
                    break;
                case ContentAlignment.TopRight:
                    x = GetAlignment(Alignment.RightBottom, rect.X, rect.Width, size.Width);
                    y = GetAlignment(Alignment.LeftTop, rect.Y, rect.Height, size.Height);
                    break;
                default:
                    throw new NotImplementedException();
            }

            g.DrawString(str, font, brush, new PointF(x, y));
        }

        #endregion

        #region Private

        

        //private static GraphicsPath CreatePyramid3DPath(Pyramid3DPart part,
        //    int x, int y, int width, int height, int depth)
        //{
        //    GraphicsPath path = new GraphicsPath();
        //    Point realDepth = GetRealDepth(depth);

        //    if (part == Pyramid3DPart.Floor)
        //    {
        //        //Empty
        //    }
        //    else if (part == Pyramid3DPart.Noth)
        //    {
        //        path.AddLines(new Point[] 
        //        {
        //            new Point(x + realDepth.X, y + realDepth.Y),
        //            new Point(x + width + realDepth.X, y + realDepth.Y),
        //            new Point(x + width / 2 + realDepth.X / 2, y - height + realDepth.Y / 2),
        //            new Point(x + realDepth.X, y + realDepth.Y)
        //        });
        //    }
        //    else if (part == Pyramid3DPart.East)
        //    {
        //        path.AddLines(new Point[] 
        //        {
        //            new Point(x, y),
        //            new Point(x + realDepth.X, y + realDepth.Y),
        //            new Point(x + width / 2 + realDepth.X / 2, y - height + realDepth.Y / 2),
        //            new Point(x, y)
        //        });
        //    }
        //    else if (part == Pyramid3DPart.South)
        //    {
        //        path.AddLines(new Point[] 
        //        {
        //            new Point(x, y),
        //            new Point(x + width, y),
        //            new Point(x + width / 2 + realDepth.X / 2, y - height + realDepth.Y / 2),
        //            new Point(x, y)
        //        });
        //    }
        //    else if (part == Pyramid3DPart.West)
        //    {
        //        path.AddLines(new Point[] 
        //        {
        //            new Point(x + width, y),
        //            new Point(x + width + realDepth.X, y + realDepth.Y),
        //            new Point(x + width / 2 + realDepth.X / 2, y - height + realDepth.Y / 2),
        //            new Point(x + width, y)
        //        });
        //    }
        //    else
        //        throw new NotImplementedException();

        //    return path;
        //}

        private static float GetAlignment(Alignment align, float start, float length, float contentLength)
        {
            switch (align)
            {
                case Alignment.LeftTop:
                    return start;
                case Alignment.Center:
                    return start + (length / 2) - (contentLength / 2);
                case Alignment.RightBottom:
                    return start + length - contentLength;
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion
    }
    /// @}
}
