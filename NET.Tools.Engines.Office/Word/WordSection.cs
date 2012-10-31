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
    /// Represent a Word section
    /// </summary>
    public sealed class WordSection : IDisposable
    {
        internal Section Section { get; private set; }
        /// <summary>
        /// Document parent
        /// </summary>
        public WordDocument Parent { get; private set; }

        public WordSection(Section section, WordDocument parent)
        {
            Section = section;
            Parent = parent;
        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(Section);
        }

        /// <summary>
        /// Creates a new paragraph
        /// </summary>
        /// <returns></returns>
        public WordParagraph CreateParagraph()
        {
            Paragraph paragraph = Parent.Document.Paragraphs.Add();
            return new WordParagraph(paragraph, this);
        }

        /// <summary>
        /// Get all paragraphs in document
        /// </summary>
        /// <returns></returns>
        public WordParagraph[] GetAllParagraphs()
        {
            List<WordParagraph> paragraphs = new List<WordParagraph>();

            foreach (Paragraph paragraph in Parent.Document.Paragraphs)
            {
                paragraphs.Add(new WordParagraph(paragraph, this));
            }

            return paragraphs.ToArray();
        }
    }

    /// @}
}
