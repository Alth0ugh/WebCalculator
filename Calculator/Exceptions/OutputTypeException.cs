using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    /// <summary>
    /// Exception for incorrect output types.
    /// </summary>
    public class OutputTypeException : Exception
    {
        public OutputTypeException() : base() { }
        public OutputTypeException(string message) : base(message) { }
    }
}
