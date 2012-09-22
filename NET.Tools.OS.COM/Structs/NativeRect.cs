using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    /// <summary>
    /// A wrapper for a NativeRect struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeRect
    {
        /// <summary>
        /// Position of left edge
        /// </summary>            
        public int Left { get; set; }

        /// <summary>
        /// Position of top edge
        /// </summary>            
        public int Top { get; set; }

        /// <summary>
        /// Position of right edge
        /// </summary>            
        public int Right { get; set; }

        /// <summary>
        /// Position of bottom edge
        /// </summary>            
        public int Bottom { get; set; }

        /// <summary>
        /// Creates a new NativeRect initialized with supplied values.
        /// </summary>
        /// <param name="left">Position of left edge</param>
        /// <param name="top">Position of top edge</param>
        /// <param name="right">Position of right edge</param>
        /// <param name="bottom">Position of bottom edge</param>
        public NativeRect(int left, int top, int right, int bottom)
            : this()
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Determines if two NativeRects are equal.
        /// </summary>
        /// <param name="first">First NativeRect</param>
        /// <param name="second">Second NativeRect</param>
        /// <returns>True if first NativeRect is equal to second; false otherwise.</returns>
        public static bool operator ==(NativeRect first, NativeRect second)
        {
            return first.Left == second.Left
                && first.Top == second.Top
                && first.Right == second.Right
                && first.Bottom == second.Bottom;
        }

        /// <summary>
        /// Determines if two NativeRects are not equal
        /// </summary>
        /// <param name="first">First NativeRect</param>
        /// <param name="second">Second NativeRect</param>
        /// <returns>True if first is not equal to second; false otherwise.</returns>
        public static bool operator !=(NativeRect first, NativeRect second)
        {
            return !(first == second);
        }

        public static implicit operator NativeRect(System.Drawing.Rectangle r)
        {
            return new NativeRect(r.Left, r.Top, r.Right, r.Bottom);
        }

        public static implicit operator NativeRect(System.Windows.Rect r)
        {
            return new NativeRect((int)r.Left, (int)r.Top, (int)r.Right, (int)r.Bottom);
        }

        public static implicit operator System.Drawing.Rectangle(NativeRect r)
        {
            return System.Drawing.Rectangle.FromLTRB(r.Left, r.Top, r.Right, r.Bottom);
        }

        public static implicit operator System.Windows.Rect(NativeRect r)
        {
            return new System.Windows.Rect(r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top);
        }

        /// <summary>
        /// Determines if the NativeRect is equal to another Rect.
        /// </summary>
        /// <param name="obj">Another NativeRect to compare</param>
        /// <returns>True if this NativeRect is equal to the one provided; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj != null && obj is NativeRect) ? this == (NativeRect)obj : false;
        }

        /// <summary>
        /// Creates a hash code for the NativeRect
        /// </summary>
        /// <returns>Returns hash code for this NativeRect</returns>
        public override int GetHashCode()
        {
            int hash = Left.GetHashCode();
            hash = hash * 31 + Top.GetHashCode();
            hash = hash * 31 + Right.GetHashCode();
            hash = hash * 31 + Bottom.GetHashCode();
            return hash;
        }
    }
}
