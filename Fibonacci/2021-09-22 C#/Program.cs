using System;

public class FibonacciRecursive
  {
      static void Main(string[] args)
      {
          int n = (args.Length == 0) ? 10 : Convert.ToInt32(args[0]);
          
          for (int i = 0; i < n; ++i)
            Console.WriteLine(Fib(i));
      }

      private static int Fib(int n)
      {
          if (n == 0)
            return 0;
          else if (n == 1)
            return 1;
          else return (Fib(n-1) + Fib(n-2));
      }
  }