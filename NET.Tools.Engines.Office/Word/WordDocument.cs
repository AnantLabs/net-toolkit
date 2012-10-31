using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace NET.Tools.Engines.Office.Word
{
    /// \addtogroup office_word
    /// @{

    /// <summary>
    /// Represent a Word document
    /// </summary>
    public sealed class WordDocument : IOfficeDocument
    {
        #region Static

        public static WordDocument CreateDocument()
        {
            WordDocument doc = new WordDocument();
            return doc;
        }

        public static WordDocument OpenDocument(string file)
        {
            WordDocument doc = CreateDocument();
            doc.Open(file);

            return doc;
        }

        public static WordDocument OpenDocument(Stream stream)
        {
            WordDocument doc = CreateDocument();
            doc.Open(stream);

            return doc;
        }

        #endregion

        private Application app;
        internal Document Document { get; private set; }

        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Words in document
        /// </summary>
        public int Words
        {
            get { return Document.Words.Count; }
        }

        /// <summary>
        /// Character in document
        /// </summary>
        public int Characters
        {
            get { return Document.Characters.Count; }
        }

        public PageSetup PageSetup
        {
            get { return Document.PageSetup; }
        }

        private WordDocument()
        {
            IsDisposed = false;

            app = new Application();
            Document = app.Documents.Add();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => { if (!IsDisposed) Dispose(); };
        }

        public void Dispose()
        {
            if (IsDisposed)
                throw new InvalidOperationException("Word document was already disposed!");

            Document.Close(false);
            app.Quit();

            Marshal.ReleaseComObject(Document);
            Marshal.ReleaseComObject(app);

            IsDisposed = true;
        }

        public void Open(string file)
        {
            Document.Close(false);
            Marshal.ReleaseComObject(Document);

            Document = app.Documents.Open(file);
        }

        public void Open(Stream stream)
        {
            string file = Path.GetTempFileName();
            stream.WriteToFile(file);

            Open(file);
            new FileInfo(file).DeleteOnExit();
        }

        public void Save(string file)
        {
            Document.SaveAs(file, WdSaveFormat.wdFormatDocument);
        }

        public void Save(Stream stream)
        {
            string file = Path.GetTempFileName();
            Save(file);

            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                fs.CopyTo(stream);
            }

            new FileInfo(file).DeleteOnExit();
        }

        public WordSection CreateSection()
        {
            Section section = Document.Sections.Add();
            return new WordSection(section, this);
        }

        public WordSection[] GetAllSections()
        {
            List<WordSection> sections = new List<WordSection>();

            foreach(Section section in Document.Sections)
            {
                sections.Add(new WordSection(section, this));
            }

            return sections.ToArray();
        }
    }

    /// @}
}
