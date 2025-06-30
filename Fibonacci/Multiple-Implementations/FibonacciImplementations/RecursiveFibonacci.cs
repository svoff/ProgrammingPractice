namespace FibonacciImplementations;

/// <summary>
/// Simple recursive implementation of Fibonacci calculation
/// Time complexity: O(2^n)
/// Space complexity: O(n) due to call stack
/// </summary>
public class RecursiveFibonacci : IFibonacci
{
    public string Name => "Recursive";

    public long Calculate(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        if (n == 0) return 0;
        if (n == 1) return 1;
        return Calculate(n - 1) + Calculate(n - 2);
    }
}