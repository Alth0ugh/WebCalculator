using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    /// <summary>
    /// Exception for errors with operatos in mathematical exceptions.
    /// </summary>
    public class OperatorApplicationException : Exception
    {
        public OperatorApplicationException()
        {
            
        }
        public OperatorApplicationException(string message) : base(message) { }
        public OperatorApplicationException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
