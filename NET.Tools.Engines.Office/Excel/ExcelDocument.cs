using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;
using NET.Tools;

namespace NET.Tools.Engines.Office.Excel
{
    /// \addtogroup office_excel
    /// @{

    /// <summary>
    /// Represent an Excel document. It contains one or more Excel worksheets.
    /// </summary>
    public sealed class ExcelDocument : IOfficeDocument
    {
        #region Static

        public static ExcelDocument CreateDocument()
        {
            ExcelDocument doc = new ExcelDocument();
            return doc;
        }

        public static ExcelDocument OpenDocument(string file)
        {
            ExcelDocument doc = CreateDocument();
            doc.Open(file);

            return doc;
        }

        public static ExcelDocument OpenDocument(Stream stream)
        {
            ExcelDocument doc = CreateDocument();
            doc.Open(stream);

            return doc;
        }

        #endregion

        private Application app;
        private Workbook workbook;

        public bool IsDisposed { get; private set; }

        private ExcelDocument()
        {
            IsDisposed = false;

            app = new Application();
            workbook = app.Workbooks.Add();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => { if (!IsDisposed) Dispose(); };
        }

        public void Dispose()
        {
            if (IsDisposed)
                throw new InvalidOperationException("Excel Document already disposed!");

            workbook.Close(false);
            app.Quit();

            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(app);

            IsDisposed = true;
        }

        public void Open(string file)
        {
            workbook.Close(false);
            Marshal.ReleaseComObject(workbook);

            workbook = app.Workbooks.Open(file);
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
            workbook.SaveAs(file, XlFileFormat.xlWorkbookNormal);
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

        /// <summary>
        /// Creates a worksheet in this Excel document
        /// </summary>
        /// <returns></returns>
        public ExcelWorksheet CreateWorksheet()
        {
            Worksheet worksheet = workbook.Worksheets.Add();
            return new ExcelWorksheet(worksheet, this);
        }
        /// <summary>
        /// Returns all worksheets in document
        /// </summary>
        /// <returns></returns>
        public ExcelWorksheet[] GetAllWorksheets()
        {
            List<ExcelWorksheet> worksheets = new List<ExcelWorksheet>();

            foreach (Worksheet worksheet in workbook.Worksheets)
            {
                worksheets.Add(new ExcelWorksheet(worksheet, this));
            }

            return worksheets.ToArray();
        }

        /// <summary>
        /// Creates a worksheet with the given title in this Excel document
        /// </summary>
        /// <param name="title">Title for the new worksheet</param>
        /// <returns></returns>
        public ExcelWorksheet CreateWorksheet(String title)
        {
            ExcelWorksheet worksheet = CreateWorksheet();
            worksheet.Title = title;

            return worksheet;
        }
    }

    /// @}
}
