using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Font = System.Drawing.Font;
using NET.Tools;

namespace NET.Tools.Engines.Office.Excel
{
    /// \addtogroup office_excel
    /// @{

    /// <summary>
    /// Represent an Excel formatter
    /// </summary>
    public sealed class ExcelFormatter : IOfficeFormatter
    {
        internal Range Range { get; private set; }

        public Color Background
        {
            get { return Color.FromArgb(Color.FromArgb((int)Range.Interior.Color).ToBGR()); }
            set { Range.Interior.Color = value.ToBGR(); }
        }

        public Color Foreground
        {
            get { return Color.FromArgb(Color.FromArgb((int)Range.Font.Color).ToBGR()); }
            set { Range.Font.Color = value.ToBGR(); }
        }
        public Font Font
        {
            get
            {
                FontStyle style = FontStyle.Regular;
                if (Range.Font.Bold)
                    style |= FontStyle.Bold;
                if (Range.Font.Italic)
                    style |= FontStyle.Italic;
                if (Range.Font.Underline)
                    style |= FontStyle.Underline;
                if (Range.Font.Strikethrough)
                    style |= FontStyle.Strikeout;

                return new Font(Range.Font.Name, Range.Font.Size, style);
            } 
            set
            {
                Range.Font.Name = value.Name;
                Range.Font.Size = value.Size;
                Range.Font.Bold = (value.Style & FontStyle.Bold) == FontStyle.Bold;
                Range.Font.Italic = (value.Style & FontStyle.Italic) == FontStyle.Italic;
                Range.Font.Underline = (value.Style & FontStyle.Underline) == FontStyle.Underline;
                Range.Font.Strikethrough = (value.Style & FontStyle.Strikeout) == FontStyle.Strikeout;
            }
        }
        public string Text { get { return Range.Text; } }

        /// <summary>
        /// Gets or sets the border color of selected cells
        /// </summary>
        public Color BorderColor
        {
            get { return Color.FromArgb(Color.FromArgb((int)Range.Borders.Color).ToBGR()); }
            set { Range.Borders.Color = value.ToBGR(); }
        }
        /// <summary>
        /// Gets or sets the line style for the borders
        /// </summary>
        public XlLineStyle BorderLineStyle
        {
            get { return Range.Borders.LineStyle; }
            set { Range.Borders.LineStyle = value; }
        }
        /// <summary>
        /// Gets or sets the number format. See Excel cell formatting for more informations
        /// </summary>
        public string NumberFormat
        {
            get { return Range.NumberFormat; }
            set { Range.NumberFormat = value; }
        }

        public int RowHeight
        {
            get { return Range.RowHeight; }
            set { Range.RowHeight = value; }
        }

        public int ColumnWidth
        {
            get { return Range.ColumnWidth; }
            set { Range.ColumnWidth = value; }
        }

        /// <summary>
        /// Returns the worksheet parent
        /// </summary>
        public ExcelWorksheet WorksheetParent { get; private set; }
        /// <summary>
        /// Returns the document parent
        /// </summary>
        public ExcelDocument DocumentParent { get { return WorksheetParent.Parent; } }

        public ExcelCellName LeftTopCell { get; private set; }
        public ExcelCellName RightTopCell { get; private set; }

        public bool IsDisposed { get; private set; }

        public ExcelFormatter(ExcelCellName leftTopCell, ExcelCellName rightTopCell, ExcelWorksheet worksheetParent)
        {
            IsDisposed = false;

            RightTopCell = rightTopCell;
            LeftTopCell = leftTopCell;
            WorksheetParent = worksheetParent;

            Range = worksheetParent.Worksheet.Range[leftTopCell.ToCellName(), rightTopCell.ToCellName()];
        }

        public void Merge()
        {
            Range.Merge();
        }

        public void UnMerge()
        {
            Range.UnMerge();
        }

        public void Dispose()
        {
            if (IsDisposed)
                throw new InvalidOperationException("This object was already disposed!");

            Marshal.ReleaseComObject(Range);
            IsDisposed = true;
        }
    }

    /// @}
}
