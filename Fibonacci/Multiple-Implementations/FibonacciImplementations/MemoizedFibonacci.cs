namespace FibonacciImplementations;

/// <summary>
/// Memoized recursive implementation of Fibonacci calculation
/// Time complexity: O(n)
/// Space complexity: O(n) for memoization cache + O(n) for call stack
/// </summary>
public class MemoizedFibonacci : IFibonacci
{
    public string Name => "Memoized Recursive";

    public long Calculate(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        
        var memo = new Dictionary<int, long>();
        return CalculateWithMemo(n, memo);
    }

    private long CalculateWithMemo(int n, Dictionary<int, long> memo)
    {
        if (memo.ContainsKey(n))
            return memo[n];

        long result;
        if (n == 0)
            result = 0;
        else if (n == 1)
            result = 1;
        else
            result = CalculateWithMemo(n - 1, memo) + CalculateWithMemo(n - 2, memo);

        memo[n] = result;
        return result;
    }
}