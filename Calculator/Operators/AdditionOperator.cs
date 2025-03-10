﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    /// <summary>
    /// Operator of addition of numeric types.
    /// </summary>
    /// <typeparam name="T">Numeric type</typeparam>
    internal class AdditionOperator<T> : IOperator<T> where T : INumber<T>
    {
        /// <inheritdoc/>
        public T Apply(T operand1, T operand2)
        {
            return operand1 + operand2;
        }
    }
}
