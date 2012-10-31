using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Mathematica
{
    /// \addtogroup math 
    /// @{

    /// <summary>
    /// Represent a vector with n dimensions
    /// 
    /// This object is immutable!
    /// </summary>
    public sealed class VectorND : IVector<VectorND>
    {
        private double[] values = null;

        public VectorND(uint dimension, params double[] valueList)
        {
            if (dimension <= 0)
                throw new ArgumentException("Dimension must be greater than 0!");
            if ((valueList.Length != 0) && (valueList.Length != dimension))
                throw new ArgumentException("The value list length must be 0 or " + dimension + "!");

            values = new double[dimension];
            if (valueList.Length == 0)
            {
                for (int i = 0; i < dimension; i++)
                    values[i] = 0d;
            }
            else
            {
                for (int i = 0; i < dimension; i++)
                    values[i] = valueList[i];
            }            
        }

        /// <summary>
        /// Gets the dimension of this vector
        /// </summary>
        public uint Dimension
        {
            get { return (uint)values.Length; }
        }

        /// <summary>
        /// Get all values of this vector
        /// </summary>
        public double[] ValueList
        {
            get { return values; }
        }

        /// <summary>
        /// Gets one value from this vector with the given index
        /// </summary>
        /// <param name="index">Index of value</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if the index is not between 0 and dimension of vector
        /// </exception>
        public double GetValue(int index)
        {
            if ((index < 0) || (index >= Dimension))
                throw new ArgumentOutOfRangeException("The index must be between 0 and " + Dimension + "!");

            return values[index];
        }

        public static VectorND operator +(VectorND v1, VectorND v2)
        {
            return v1.Add(v2);
        }

        public static VectorND operator -(VectorND v1, VectorND v2)
        {
            return v1.Subtract(v2);
        }

        public static double operator *(VectorND v1, VectorND v2)
        {
            return v1.Multiply(v2);
        }

        public static VectorND operator *(double val, VectorND vec)
        {
            return vec.Multiply(val);
        }

        public static VectorND operator /(VectorND vec, double val)
        {
            return vec.DivideForward(val);
        }

        public static VectorND operator /(double val, VectorND vec)
        {
            return vec.DivideBackward(val);
        }

        #region IVector<VectorND> Member

        public double Length
        {
            get
            {
                double result = 0d;
                foreach (double value in values)
                    result += Math.Pow(value, 2);
                result = Math.Sqrt(result);
                result = Math.Abs(result);

                return result;
            }
        }

        public VectorND Add(VectorND vec)
        {
            if (vec.Dimension != this.Dimension)
                throw new ArgumentException("The vectors must be the same dimension!");

            double[] list = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
                list[i] = values[i] + vec.values[i];

            return new VectorND(this.Dimension, list);
        }

        public VectorND Subtract(VectorND vec)
        {
            if (vec.Dimension != this.Dimension)
                throw new ArgumentException("The vectors must be the same dimension!");

            double[] list = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
                list[i] = values[i] - vec.values[i];

            return new VectorND(this.Dimension, list);
        }

        public double Multiply(VectorND vec)
        {
            if (vec.Dimension != this.Dimension)
                throw new ArgumentException("The vectors must be the same dimension!");

            double result = 0d;
            for (int i = 0; i < values.Length; i++)
                result += (values[i] * vec.values[i]);

            return result;
        }

        public VectorND Multiply(double num)
        {
            double[] list = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
                list[i] = values[i] * num;

            return new VectorND(this.Dimension, list);
        }

        public VectorND DivideForward(double num)
        {
            double[] list = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
                list[i] = values[i] / num;

            return new VectorND(this.Dimension, list);
        }

        public VectorND DivideBackward(double num)
        {
            double[] list = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
                list[i] = num / values[i];

            return new VectorND(this.Dimension, list);
        }

        public VectorND Normalize
        {
            get { return this / Length; }
        }

        #endregion

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");

            foreach (double value in values)
                str.Append(value + "|");

            str.Remove(str.Length - 1, 1);
            str.Append("]");

            return str.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is VectorND))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            VectorND myObj = (VectorND)obj;

            for (int i = 0; i < values.Length; i++)
            {
                if (!values[i].Equals(myObj.values[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int result = 0;
            foreach (double value in values)
                result += value.GetHashCode();

            return result;
        }
    }

    /// @}
}
