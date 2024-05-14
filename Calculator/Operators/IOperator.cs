using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    /// <summary>
    /// Interface for a mathematical operation.
    /// </summary>
    /// <typeparam name="T">Numeric type</typeparam>
    internal interface IOperator<T> where T : INumber<T>
    {
        /// <summary>
        /// Applies the operator to numbers.
        /// </summary>
        /// <param name="operand1">First operand.</param>
        /// <param name="operand2">Sencod operand.</param>
        /// <returns></returns>
        T Apply(T operand1, T operand2);
    }
}
