namespace FibonacciImplementations;

/// <summary>
/// Dynamic programming (bottom-up) implementation of Fibonacci calculation
/// Time complexity: O(n)
/// Space complexity: O(n) for the array
/// </summary>
public class DynamicProgrammingFibonacci : IFibonacci
{
    public string Name => "Dynamic Programming";

    public long Calculate(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        if (n == 0) return 0;
        if (n == 1) return 1;

        var dp = new long[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }
}