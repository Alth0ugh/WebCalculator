using Calculator;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebCalculator.Models
{
    /// <summary>
    /// Model of calculator.
    /// </summary>
    public class CalculatorModel
    {
        /// <summary>
        /// Display with infix expression.
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// Whether to return whole numbers.
        /// </summary>
        public bool Whole { get; set; }
        private readonly string[] _operators = new string[] { "+", "-", "*", "/" };
        /// <summary>
        /// History of expresssions.
        /// </summary>
        public List<string> History { get; set; } = new List<string>();
        private ICalculator _calculator;
        private Exception _lastException;
        private ILogger _logger;

        public CalculatorModel(string display, ICalculator calculator, ILogger logger)
        {
            Display = display;
            _calculator = calculator;
            calculator.OnError += SendError;
            _logger = logger;
        }

        /// <summary>
        /// Clears the display of calculator.
        /// </summary>
        public void Clear()
        {
            Display = "0";
        }

        /// <summary>
        /// Adds decimal point to calculator.
        /// </summary>
        public void AddDecimal()
        {
            var displaySplit = Display.Split(" ");

            if (displaySplit.Length == 1)
            {
                var operand = displaySplit[displaySplit.Length - 1];
                if (operand.Contains("."))
                    return;

                Display = $"{operand}.".ToString();
            }
            else if (displaySplit.Length == 3)
            {
                var operand = displaySplit[displaySplit.Length - 1];
                operand = $"{operand}.";

                Display = $"{displaySplit[0]} {displaySplit[1]} {operand}";
            }
        }

        /// <summary>
        /// Adds a digit to number displayed on calculator.
        /// </summary>
        /// <param name="digit">Digit to be added.</param>
        public void AddDigit(int digit)
        {
            var displaySplit = Display.Split(" ");

            if (displaySplit.Length == 1)
            {
                var operand = displaySplit[displaySplit.Length - 1];
                operand = AppendDigit(operand, digit.ToString());
                Display = operand;
            }
            else if (displaySplit.Length == 2)
            {
                Display = $"{displaySplit[0]} {displaySplit[1]} {digit}";
            }
            else
            {
                var operand = displaySplit[displaySplit.Length - 1];
                operand = AppendDigit(operand, digit.ToString());

                Display = $"{displaySplit[0]} {displaySplit[1]} {operand}";
            }
        }

        /// <summary>
        /// Adds an operator to display.
        /// </summary>
        /// <param name="op">Operator to be added.</param>
        public void AddOperator(string op)
        {
            if (!_operators.Contains(op))
                return;

            var displaySplit = Display.Split(" ");

            switch (displaySplit.Length)
            {
                case 1:
                case 2:
                    Display = $"{displaySplit[0]} {op}";
                    break;
                default:
                    break;
                    
            }
        }

        /// <summary>
        /// Evaluates the expresssion.
        /// </summary>
        public void Compute()
        {
            var displaySplit = Display.Split(" ");
            if (displaySplit.Length != 3)
                return;

            var rpn = $"{displaySplit[0]} {displaySplit[2]} {displaySplit[1]}";

            var result = Whole ? _calculator.Compute<int>(rpn).ToString() : _calculator.Compute<float>(rpn).ToString();
            if (_lastException is null)
            {
                Display = result;
            }
            else
            {
                throw _lastException;
            }
        }

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="ex">Exception from error.</param>
        public void SendError(Exception ex)
        {
            _logger.LogError($"An error occured while evaluating the expression. Error: {JsonConvert.SerializeObject(ex, Formatting.Indented)}");
            _lastException = ex;
        }

        private string AppendDigit(string operand, string digit)
        {
            if (operand[0] == '0' && operand.Length == 1)
                return digit;
            return $"{operand}{digit}";
        }
    }
}
