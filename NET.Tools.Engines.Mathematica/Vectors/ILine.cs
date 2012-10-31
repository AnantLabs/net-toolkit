using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// <summary>
    /// Marker-Interface for all Vector-Lines
    /// </summary>
    /// <typeparam name="T">Type of vectors</typeparam>
    public interface ILine<T>
    {
        T Point { get; }
        T Direction { get; }
    }
}
