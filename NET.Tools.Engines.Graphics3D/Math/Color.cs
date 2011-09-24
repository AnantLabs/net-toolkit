using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent an easy color object
    /// 
    /// Object is immutable
    /// </summary>
    public struct Color
    {
        public static Color White { get { return new Color(1, 1, 1); } }
        public static Color Gray { get { return new Color(0.5, 0.5, 0.5); } }
        public static Color Black { get { return new Color(0, 0, 0); } }
        public static Color Transparent { get { return new Color(0, 0, 0, 0); } }

        private double r, g, b, a;

        /// <summary>
        /// Red color value
        /// </summary>
        public double Red { get { return r; } }
        /// <summary>
        /// Green color value
        /// </summary>
        public double Green { get { return g; } }
        /// <summary>
        /// Blue color value
        /// </summary>
        public double Blue { get { return b; } }
        /// <summary>
        /// Alpha color value
        /// </summary>
        public double Alpha { get { return a; } }

        public Color(double r, double g, double b, double a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(double r, double g, double b)
            : this(r, g, b, 1)
        {
        }

        public Color(Color color, double a)
            : this(color.r, color.g, color.b, a)
        {
        }

        internal ColorValue ToColorValue()
        {
            return new ColorValue((float)r, (float)g, (float)b, (float)a);
        }
    }

    /// @}
}
