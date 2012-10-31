using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace NET.Tools.Engines.Office.Word
{
    /// \addtogroup office_word
    /// @{

    /// <summary>
    /// Represent a Word paragraph
    /// </summary>
    public sealed class WordParagraph : IDisposable
    {
        internal Paragraph Paragraph { get; private set; }

        /// <summary>
        /// Document parent
        /// </summary>
        public WordDocument DocumentParent { get { return SectionParent.Parent; } }
        /// <summary>
        /// Section Parent
        /// </summary>
        public WordSection SectionParent { get; private set; }

        /// <summary>
        /// Gets or sets the text of the paragraph
        /// </summary>
        public String Text
        {
            get { return Paragraph.Range.Text; }
            set { Paragraph.Range.Text = value; }
        }
        /// <summary>
        /// Returns the formatter
        /// </summary>
        public WordFormatter Formatter
        {
            get { return new WordFormatter(this); }
        }
        /// <summary>
        /// Paragraph Alignment
        /// </summary>
        public WdParagraphAlignment ParagraphAlignment
        {
            get { return Paragraph.Format.Alignment; }
            set { Paragraph.Format.Alignment = value; }
        }

        public WordParagraph(Paragraph paragraph, WordSection parent)
        {
            SectionParent = parent;
            Paragraph = paragraph;
        }

        public void Dispose()
        {
            Paragraph.CloseUp();
            Marshal.ReleaseComObject(Paragraph);
        }
    }

    /// @}
}
