using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    /// <summary>
    /// Operation of division of numeric types.
    /// </summary>
    /// <typeparam name="T">Numeric type</typeparam>
    internal class DivisionOperator<T> : IOperator<T> where T : INumber<T>
    {
        /// <inheritdoc/>
        public T Apply(T operand1, T operand2)
        {
            if (operand2 is float & (float)Convert.ChangeType(operand2, typeof(float)) == 0)
            {
                throw new DivideByZeroException();
            }
            return operand1 / operand2;
        }
    }
}
