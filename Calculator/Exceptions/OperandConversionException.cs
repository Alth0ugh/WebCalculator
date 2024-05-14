using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    /// <summary>
    /// Exception for errors of operands in mathematical expression.
    /// </summary>
    public class OperandConversionException : Exception
    {
        public OperandConversionException() { }
        public OperandConversionException(string message) : base(message) { }
        public OperandConversionException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
