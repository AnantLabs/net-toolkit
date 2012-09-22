using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NativePoint
    {
        public int X;
        public int Y;

        public NativePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator NativePoint(System.Drawing.Point p)
        {
            return new NativePoint(p.X, p.Y);
        }

        public static implicit operator System.Drawing.Point(NativePoint p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static implicit operator NativePoint(System.Windows.Point p)
        {
            return new NativePoint((int)p.X, (int)p.Y);
        }

        public static implicit operator System.Windows.Point(NativePoint p)
        {
            return new System.Windows.Point(p.X, p.Y);
        }
    }
}
