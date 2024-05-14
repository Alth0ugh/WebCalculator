using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Interfacce for sending errors.
    /// </summary>
    public interface IErrorSender
    {
        /// <summary>
        /// Event that is triggered when error occures.
        /// </summary>
        event Action<Exception>? OnError;
    }
}
