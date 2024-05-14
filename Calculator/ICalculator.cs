namespace Calculator
{
    /// <summary>
    /// Interface for calculator.
    /// </summary>
    public interface ICalculator
    {
        
        T Compute<T>(string expression);
        public event Action<Exception> OnError;
    }
}