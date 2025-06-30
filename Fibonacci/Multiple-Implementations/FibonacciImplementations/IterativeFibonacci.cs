namespace FibonacciImplementations;

/// <summary>
/// Iterative implementation of Fibonacci calculation
/// Time complexity: O(n)
/// Space complexity: O(1)
/// </summary>
public class IterativeFibonacci : IFibonacci
{
    public string Name => "Iterative";

    public long Calculate(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        if (n == 0) return 0;
        if (n == 1) return 1;

        long prev2 = 0;
        long prev1 = 1;
        long current = 0;

        for (int i = 2; i <= n; i++)
        {
            current = prev1 + prev2;
            prev2 = prev1;
            prev1 = current;
        }

        return current;
    }
}