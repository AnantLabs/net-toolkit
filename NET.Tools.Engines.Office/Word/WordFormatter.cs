using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Word;
using Font = System.Drawing.Font;

namespace NET.Tools.Engines.Office.Word
{
    /// \addtogroup office_word
    /// @{
    
    /// <summary>
    /// Represent a Word formatter to format text
    /// </summary>
    public sealed class WordFormatter : IOfficeFormatter
    {
        internal Range Range { get; private set; }

        /// <summary>
        /// Document Parent
        /// </summary>
        public WordDocument DocumentParent { get { return ParagraphParent.DocumentParent; } }
        /// <summary>
        /// Paragraph Parent
        /// </summary>
        public WordParagraph ParagraphParent { get; private set; }
        /// <summary>
        /// Section Parent
        /// </summary>
        public WordSection SectionParent { get { return ParagraphParent.SectionParent; } }

        public Color Foreground
        {
            get { return Color.FromArgb(Color.FromArgb((int)Range.Font.Color).ToBGR()); }
            set { Range.Font.Color = (WdColor)value.ToBGR(); }
        }
        public Color Background
        {
            get { return Color.FromArgb(Color.FromArgb((int) Range.Shading.BackgroundPatternColor).ToBGR()); }
            set { Range.Shading.BackgroundPatternColor = (WdColor) value.ToBGR(); }
        }
        public Font Font
        {
            get
            {
                FontStyle style = FontStyle.Regular;
                if (Range.Font.Bold != 0)
                    style |= FontStyle.Bold;
                if (Range.Font.Italic != 0)
                    style |= FontStyle.Italic;
                if (Range.Font.Underline != 0)
                    style |= FontStyle.Underline;
                if (Range.Font.StrikeThrough != 0)
                    style |= FontStyle.Strikeout;

                return new Font(Range.Font.Name, Range.Font.Size, style);
            }
            set
            {
                Range.Font.Name = value.Name;
                Range.Font.Size = value.Size;
                Range.Font.Bold = (value.Style & FontStyle.Bold) == FontStyle.Bold ? 1 : 0;
                Range.Font.Italic = (value.Style & FontStyle.Italic) == FontStyle.Italic ? 1 : 0;
                Range.Font.Underline = (value.Style & FontStyle.Underline) == FontStyle.Underline ? WdUnderline.wdUnderlineSingle : WdUnderline.wdUnderlineNone;
                Range.Font.StrikeThrough = (value.Style & FontStyle.Strikeout) == FontStyle.Strikeout ? 1 : 0;
            }
        }
        public string Text
        {
            get { return Range.Text; }
        }

        internal WordFormatter(WordParagraph paragraphParent)
        {
            ParagraphParent = paragraphParent;
            Range = ParagraphParent.Paragraph.Range;
        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(Range);
        }
    }

    /// @}
}
