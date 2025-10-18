using System.Diagnostics;
using FibonacciImplementations;

namespace FibonacciBenchmark;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fibonacci Implementations Benchmark");
        Console.WriteLine("====================================");
        Console.WriteLine();

        var implementations = new List<IFibonacci>
        {
            new IterativeFibonacci(),
            new MemoizedFibonacci(),
            new DynamicProgrammingFibonacci(),
            new MatrixFibonacci(),
            new RecursiveFibonacci() // Last because it's slowest
        };

        // Test different input sizes
        var testCases = new[] { 10, 20, 30, 35 };

        foreach (var n in testCases)
        {
            Console.WriteLine($"Calculating Fibonacci({n}):");
            Console.WriteLine("Implementation".PadRight(25) + "Result".PadRight(15) + "Time (ms)");
            Console.WriteLine(new string('-', 50));

            foreach (var implementation in implementations)
            {
                // Skip recursive for large numbers to avoid excessive wait time
                if (implementation is RecursiveFibonacci && n > 35)
                {
                    Console.WriteLine($"{implementation.Name}".PadRight(25) + "SKIPPED".PadRight(15) + "(too slow)");
                    continue;
                }

                var stopwatch = Stopwatch.StartNew();
                long result;
                
                try
                {
                    result = implementation.Calculate(n);
                    stopwatch.Stop();
                    
                    Console.WriteLine($"{implementation.Name}".PadRight(25) + 
                                    $"{result}".PadRight(15) + 
                                    $"{stopwatch.ElapsedMilliseconds:F2}");
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"{implementation.Name}".PadRight(25) + 
                                    "ERROR".PadRight(15) + 
                                    $"{ex.Message}");
                }
            }
            
            Console.WriteLine();
        }

        // Performance comparison for moderate-sized numbers
        Console.WriteLine("Performance Comparison (average over 100 runs):");
        Console.WriteLine("================================================");
        
        const int testN = 25;
        const int iterations = 100;
        
        Console.WriteLine($"Calculating Fibonacci({testN}) - Average over {iterations} iterations:");
        Console.WriteLine("Implementation".PadRight(25) + "Average Time (ms)");
        Console.WriteLine(new string('-', 45));

        foreach (var implementation in implementations)
        {
            if (implementation is RecursiveFibonacci)
            {
                // Skip recursive for performance test as it's too slow
                Console.WriteLine($"{implementation.Name}".PadRight(25) + "SKIPPED (too slow)");
                continue;
            }

            var totalTime = 0.0;
            
            for (int i = 0; i < iterations; i++)
            {
                var stopwatch = Stopwatch.StartNew();
                implementation.Calculate(testN);
                stopwatch.Stop();
                totalTime += stopwatch.Elapsed.TotalMilliseconds;
            }

            var averageTime = totalTime / iterations;
            Console.WriteLine($"{implementation.Name}".PadRight(25) + $"{averageTime:F4}");
        }

        Console.WriteLine();
        Console.WriteLine("Note: Recursive implementation is excluded from larger tests due to exponential time complexity.");
    }
}
