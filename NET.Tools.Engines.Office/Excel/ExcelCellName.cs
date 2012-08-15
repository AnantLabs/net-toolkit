using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Office.Excel
{
    /// \addtogroup office_excel
    /// @{
    
    ///<summary>
    /// Letters
    ///</summary>
    public enum Letter : byte
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8,
        I = 9,
        J = 10,
        K = 11,
        L = 12,
        M = 13,
        N = 14,
        O = 15,
        P = 16,
        Q = 17,
        R = 18,
        S = 19,
        T = 20,
        U = 21,
        V = 22,
        W = 23,
        X = 24,
        Y = 25,
        Z = 26
    }

    public sealed class ColumnLetter
    {
        public static ColumnLetter CreateSingleColumnLetter(Letter letter)
        {
            return new ColumnLetter(letter, null);
        }

        public static ColumnLetter CreateDoubleColumnLetter(Letter firstLetter, Letter secondLetter)
        {
            return new ColumnLetter(firstLetter, secondLetter);
        }

        public Letter FirstLetter { get; private set; }
        public Letter? SecondLetter { get; private set; }

        public bool HasTwoLetters { get { return SecondLetter.HasValue; } }

        private ColumnLetter(Letter firstLetter, Letter? secondLetter)
        {
            FirstLetter = firstLetter;
            SecondLetter = secondLetter;
        }

        private bool Equals(ColumnLetter other)
        {
            return FirstLetter.Equals(other.FirstLetter) && SecondLetter.Equals(other.SecondLetter);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ColumnLetter && Equals((ColumnLetter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (FirstLetter.GetHashCode()*397) ^ SecondLetter.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("FirstLetter: {0}, SecondLetter: {1}", FirstLetter, SecondLetter);
        }

        internal String ToColumnName()
        {
            return FirstLetter.ToString() + (SecondLetter != null ? SecondLetter.Value.ToString() : "");
        }

        internal ushort ToColumnNumber()
        {
            return (ushort)(HasTwoLetters ? (byte) FirstLetter*26 + (byte) SecondLetter.Value : (byte) FirstLetter);
        }
    }

    /// <summary>
    /// Represent an Excel cell name like "A1"
    /// </summary>
    public sealed class ExcelCellName
    {
        public ColumnLetter ColumnLetter { get; private set; }
        public ushort RowNumber { get; private set; }

        public ExcelCellName(ColumnLetter columnLetter, ushort rowNumber)
        {
            ColumnLetter = columnLetter;
            RowNumber = rowNumber;
        }

        private bool Equals(ExcelCellName other)
        {
            return Equals(ColumnLetter, other.ColumnLetter) && RowNumber == other.RowNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ExcelCellName && Equals((ExcelCellName) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((ColumnLetter != null ? ColumnLetter.GetHashCode() : 0)*397) ^ RowNumber.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("ColumnLetter: {0}, RowNumber: {1}", ColumnLetter.ToColumnName(), RowNumber);
        }

        internal string ToCellName()
        {
            return ColumnLetter.ToColumnName() + RowNumber;
        }
    }

    /// @}
}
