using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace NET.Tools.Engines.Office.Excel
{
    /// \addtogroup office_excel
    /// @{

    /// <summary>
    /// Represent an Excel worksheet page. On this object you can use all edit and formatting routines.
    /// </summary>
    public sealed class ExcelWorksheet : IDisposable
    {
        internal Worksheet Worksheet { get; private set; }

        public bool IsDisposed { get; private set; }
        /// <summary>
        /// Returns the parent Excel document
        /// </summary>
        public ExcelDocument Parent { get; private set; }

        /// <summary>
        /// Sets the title of this worksheet
        /// </summary>
        public String Title
        {
            get { return Worksheet.Name; }
            set { Worksheet.Name = value; }
        }

        public PageSetup PageSetup
        {
            get { return Worksheet.PageSetup; }
        }

        internal ExcelWorksheet(Worksheet worksheet, ExcelDocument parent)
        {
            IsDisposed = false;

            Worksheet = worksheet;
            Parent = parent;
        }

        public ExcelCell GetCellAt(ushort row, ushort column)
        {
            return new ExcelCell(row, column, this);
        }

        public ExcelCell GetCellAt(ExcelCellName excelCell)
        {
            return GetCellAt(excelCell.RowNumber, excelCell.ColumnLetter.ToColumnNumber());
        }

        public ExcelFormatter GetFormatterAt(ExcelCellName leftTopCell, ExcelCellName rightBottomCell)
        {
            return new ExcelFormatter(leftTopCell, rightBottomCell, this);
        }

        public ExcelFormatter GetFormatterAt(ExcelCellName cell)
        {
            return GetFormatterAt(cell, cell);
        }

        /// <summary>
        /// Delete this worksheet from Excel document. <b>Call Dispose Method!</b>
        /// </summary>
        public void Delete()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (IsDisposed)
                throw new InvalidOperationException("Object is already disposed!");

            Worksheet.Delete();
            Marshal.ReleaseComObject(Worksheet);

            IsDisposed = true;
        }

        public override string ToString()
        {
            return string.Format("Title: {0}", Title);
        }
    }

    /// @}
}
