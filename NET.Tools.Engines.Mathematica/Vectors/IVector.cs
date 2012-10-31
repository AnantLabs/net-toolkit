using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Marker-Interface for all (mathematical) vectors
    /// </summary>
    public interface IVector<T> where T : IVector<T>
    {
        /// <summary>
        /// Length of vector
        /// </summary>
        double Length { get; }

        /// <summary>
        /// Add to this vector an other vector
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        T Add(T vec);
        /// <summary>
        /// Sub from this vector an other vector
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        T Subtract(T vec);
        /// <summary>
        /// Multiply an vector to this vector
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        double Multiply(T vec);
        /// <summary>
        /// Multiply this vector with a number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        T Multiply(double num);
        /// <summary>
        /// Divide this vector forward with a number
        /// 
        /// It means: Vector / number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        T DivideForward(double num);
        /// <summary>
        /// Divide this vector backward with a number
        /// 
        /// It means: number / Vector
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        T DivideBackward(double num);

        /// <summary>
        /// Gets the normalized vector
        /// </summary>
        T Normalize { get; }
    }

    /// @}
}
