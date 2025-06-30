namespace FibonacciTests;

using FibonacciImplementations;

public class FibonacciTests
{
    private readonly List<IFibonacci> _implementations;

    public FibonacciTests()
    {
        _implementations = new List<IFibonacci>
        {
            new RecursiveFibonacci(),
            new IterativeFibonacci(),
            new MemoizedFibonacci(),
            new DynamicProgrammingFibonacci(),
            new MatrixFibonacci()
        };
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(6, 8)]
    [InlineData(7, 13)]
    [InlineData(8, 21)]
    [InlineData(9, 34)]
    [InlineData(10, 55)]
    [InlineData(15, 610)]
    [InlineData(20, 6765)]
    public void Calculate_ShouldReturnCorrectFibonacciNumber_ForAllImplementations(int n, long expected)
    {
        foreach (var implementation in _implementations)
        {
            var result = implementation.Calculate(n);
            Assert.Equal(expected, result);
        }
    }

    [Fact]
    public void Calculate_ShouldThrowArgumentException_ForNegativeInput()
    {
        foreach (var implementation in _implementations)
        {
            Assert.Throws<ArgumentException>(() => implementation.Calculate(-1));
        }
    }

    [Fact]
    public void Calculate_ShouldReturnConsistentResults_AcrossAllImplementations()
    {
        // Test first 25 Fibonacci numbers (avoid too large numbers for recursive implementation)
        for (int n = 0; n < 25; n++)
        {
            long? expectedResult = null;
            
            foreach (var implementation in _implementations)
            {
                var result = implementation.Calculate(n);
                
                if (expectedResult == null)
                {
                    expectedResult = result;
                }
                else
                {
                    Assert.Equal(expectedResult.Value, result);
                }
            }
        }
    }

    [Fact]
    public void AllImplementations_ShouldHaveUniqueName()
    {
        var names = _implementations.Select(impl => impl.Name).ToList();
        Assert.Equal(names.Count, names.Distinct().Count());
    }

    [Fact]
    public void Calculate_ShouldHandleLargerNumbers_ForEfficientImplementations()
    {
        // Test larger numbers for efficient implementations (excluding recursive)
        var efficientImplementations = _implementations
            .Where(impl => !(impl is RecursiveFibonacci))
            .ToList();

        const int largeN = 40;
        const long expectedResult = 102334155; // F(40)

        foreach (var implementation in efficientImplementations)
        {
            var result = implementation.Calculate(largeN);
            Assert.Equal(expectedResult, result);
        }
    }
}