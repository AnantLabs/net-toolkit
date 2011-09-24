using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NET.Tools
{
    internal class FontPaintComboBox : ComboBox
    {
        private Dictionary<String, Font> fonts = new Dictionary<string, Font>();
        private bool fontsInCache = false;

        public bool DrawFont { get; set; }
        public bool DrawFontInEditBox { get; set; }

        public FontPaintComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void CacheFonts()
        {
            fontsInCache = true;

            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                Font font = CreateDefaultFont(fontFamily, 12);
                fonts.Add(fontFamily.Name, font);
            }
        }

        public void ClearFontCache()
        {
            fontsInCache = false;
            fonts.Clear();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0)
                return;

            FontFamily fontFamily = Items[e.Index] as FontFamily;

            if ((e.State & DrawItemState.ComboBoxEdit) != 0)
            {
                Font font = e.Font;
                if (DrawFontInEditBox)
                {
                    if (!fontsInCache)
                    {
                        font = CreateDefaultFont(fontFamily, e.Font.Size);
                        if (font == null)
                            font = e.Font;
                    }
                    else
                    {
                        font = fonts[fontFamily.Name];
                        if (font == null)
                            font = e.Font;
                    }
                }

                e.Graphics.DrawString(fontFamily.Name, font, new SolidBrush(e.ForeColor),
                    e.Bounds.Left, e.Bounds.Top);
            }
            else
            {
                Font font = e.Font;
                if (DrawFont)
                {
                    if (!fontsInCache)
                    {
                        font = CreateDefaultFont(fontFamily, e.Font.Size);
                        if (font == null)
                            font = e.Font;
                    }
                    else
                    {
                        font = fonts[fontFamily.Name];
                        if (font == null)
                            font = e.Font;
                    }
                }

                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                e.Graphics.DrawString(fontFamily.Name, font, new SolidBrush(e.ForeColor),
                    e.Bounds.Left, e.Bounds.Top);
            }
        }

        private Font CreateDefaultFont(FontFamily fontFamily, float size)
        {
            Font font = null;
            if (fontFamily.IsStyleAvailable(FontStyle.Regular))
                font = new Font(fontFamily, size, FontStyle.Regular);
            else if (fontFamily.IsStyleAvailable(FontStyle.Bold))
                font = new Font(fontFamily, size, FontStyle.Bold);
            else if (fontFamily.IsStyleAvailable(FontStyle.Italic))
                font = new Font(fontFamily, size, FontStyle.Italic);
            return font;
        }
    }
}
