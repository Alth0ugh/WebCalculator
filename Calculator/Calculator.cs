using Calculator.Exceptions;
using Calculator.Operators;
using System.Numerics;

namespace Calculator
{
    /// <summary>
    /// Class containing calculator logic for simple calculator.
    /// </summary>
    public class Calculator : ICalculator
    {
        private const string _operatorConversionExceptionMessage = "Operand conversion failed from the expression.";
        private const string _invalidNumberOfTokensExceptionMessage = "Expression has invalid number of tokens.";
        private const string _invalidOperatorExceptionMessage = "Operator {0} not supported.";
        public event Action<Exception>? OnError;

        private readonly Dictionary<string, IOperator<float>> _operator = new Dictionary<string, IOperator<float>>()
        {
            { "+", new AdditionOperator<float>() },
            { "-", new SubtractionOperator<float>() },
            { "*", new ProductOperator<float>() },
            { "/", new DivisionOperator<float>() }
        };

        /// <summary>
        /// Evaluates an expression in Reverse Polish Notation. Only simple expressions are supported.
        /// </summary>
        /// <typeparam name="T">Return numeric type. Only float or int are supported. </typeparam>
        /// <param name="expression">Expression in RPN.</param>
        /// <returns>Value of the expression.</returns>
        public T Compute<T>(string expression)
        {
            if (typeof(T) != typeof(float) && typeof(T) != typeof(int))
            {
                OnError?.Invoke(new OutputTypeException($"Unsupported output type {typeof(T)}"));
                return default;
            }
            var splitExpression = expression.Split(" ");

            // Only for purposes of this application, normally here would be logic for parsing infix notation
            // and evaluation of RPN
            if (splitExpression.Length != 3)
            {
                var exception = new ExpressionException(_invalidNumberOfTokensExceptionMessage);
                OnError?.Invoke(exception);
                return default;
            }

            var operand1 = splitExpression[0];
            var operand2 = splitExpression[1];
            var op = splitExpression[2];

            var result = ApplyOperator(operand1, operand2, op);

            if (typeof(T) == typeof(int))
            {
                result = (float)Math.Round(result);
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        /// <summary>
        /// Applies operator to two numbers.
        /// </summary>
        /// <param name="operand1">First operand.</param>
        /// <param name="operand2">Second operand.</param>
        /// <param name="op">Operation.</param>
        /// <returns>Result of an operation.</returns>
        private float ApplyOperator(string operand1, string operand2, string op)
        {
            if (!_operator.ContainsKey(op))
            {
                var exception = new ExpressionException(string.Format(_invalidOperatorExceptionMessage, op));
                OnError?.Invoke(exception);
                return default;
            }

            try
            {
                var convertedOperand1 = float.Parse(operand1);
                var convertedOperand2 = float.Parse(operand2);

                return _operator[op].Apply(convertedOperand1, convertedOperand2);
            }
            catch (InvalidCastException ex)
            {
                var exception = new OperandConversionException(_operatorConversionExceptionMessage, ex);
                OnError?.Invoke(exception);
                return default;
            }
            catch (FormatException ex)
            {
                var exception = new OperandConversionException(_operatorConversionExceptionMessage, ex);
                OnError?.Invoke(exception);
                return default;
            }
            catch (OverflowException ex)
            {
                var exception = new OperandConversionException(_operatorConversionExceptionMessage, ex);
                OnError?.Invoke(exception);
                return default;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
                return default;
            }
        }
    }
}