using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    /// <summary>
    /// Exception for errors in mathematical expression.
    /// </summary>
    public class ExpressionException : Exception
    {
        public ExpressionException() { }
        public ExpressionException(string message) : base(message) { }
    }
}
