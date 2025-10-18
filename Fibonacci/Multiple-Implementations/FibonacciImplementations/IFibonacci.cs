namespace FibonacciImplementations;

/// <summary>
/// Interface for Fibonacci number calculation implementations
/// </summary>
public interface IFibonacci
{
    /// <summary>
    /// Calculate the nth Fibonacci number
    /// </summary>
    /// <param name="n">The position in the Fibonacci sequence (0-based)</param>
    /// <returns>The nth Fibonacci number</returns>
    long Calculate(int n);
    
    /// <summary>
    /// Name of the implementation for identification
    /// </summary>
    string Name { get; }
}
