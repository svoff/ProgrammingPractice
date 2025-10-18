namespace FibonacciImplementations;

/// <summary>
/// Matrix exponentiation implementation of Fibonacci calculation
/// Time complexity: O(log n)
/// Space complexity: O(log n) due to recursion in matrix exponentiation
/// </summary>
public class MatrixFibonacci : IFibonacci
{
    public string Name => "Matrix Exponentiation";

    public long Calculate(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        if (n == 0) return 0;
        if (n == 1) return 1;

        var baseMatrix = new long[,] { { 1, 1 }, { 1, 0 } };
        var result = MatrixPower(baseMatrix, n - 1);
        
        return result[0, 0];
    }

    private long[,] MatrixPower(long[,] matrix, int power)
    {
        if (power == 1)
        {
            return (long[,])matrix.Clone();
        }

        if (power % 2 == 0)
        {
            var half = MatrixPower(matrix, power / 2);
            return MatrixMultiply(half, half);
        }
        else
        {
            return MatrixMultiply(matrix, MatrixPower(matrix, power - 1));
        }
    }

    private long[,] MatrixMultiply(long[,] a, long[,] b)
    {
        return new long[,]
        {
            { a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0], a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1] },
            { a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0], a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1] }
        };
    }
}