using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Office.Excel
{
    /// \addtogroup office_excel
    /// @{

    /// <summary>
    /// Represent an Excel cell. Must be a value (for column and row) greater than 0!
    /// </summary>
    public sealed class ExcelCell : IDisposable
    {
        /// <summary>
        /// Cell Row Number (greater than 0)
        /// </summary>
        public ushort Row { get; private set; }
        /// <summary>
        /// Cell Column Number (greater than 0)
        /// </summary>
        public ushort Column { get; private set; }

        /// <summary>
        /// Excel Worksheet Parent
        /// </summary>
        public ExcelWorksheet WorksheetParent { get; private set; }
        /// <summary>
        /// Excel Document Parent
        /// </summary>
        public ExcelDocument DocumentParent { get { return WorksheetParent.Parent; } }

        /// <summary>
        /// Text for this cell
        /// </summary>
        public String Text
        {
            get { return WorksheetParent.Worksheet.Cells[Row, Column]; }
            set { WorksheetParent.Worksheet.Cells[Row, Column] = value; }
        }

        internal ExcelCell(ushort row, ushort column, ExcelWorksheet parent)
        {
            if (row <= 0)
                throw new ArgumentException("Row must be greater than 0!");
            if (column <= 0)
                throw new ArgumentException("Column must be greater than 0!");

            Row = row;
            Column = column;
            WorksheetParent = parent;
        }

        public void Dispose()
        {
            //Empty
        }

        private bool Equals(ExcelCell other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ExcelCell && Equals((ExcelCell) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row*397) ^ Column;
            }
        }

        public override string ToString()
        {
            return string.Format("Text: {0}, Column: {1}, Row: {2}", Text, Column, Row);
        }
    }

    /// @}
}
