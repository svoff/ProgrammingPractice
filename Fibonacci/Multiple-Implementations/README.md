# Multiple Fibonacci Implementations

This solution demonstrates various approaches to calculating Fibonacci numbers, each with different time and space complexity characteristics.

## Implementations

### 1. Recursive (`RecursiveFibonacci`)
- **Time Complexity**: O(2^n) - Exponential
- **Space Complexity**: O(n) - Due to call stack
- **Description**: Simple recursive implementation following the mathematical definition
- **Use Case**: Educational purposes; demonstrates the naive approach

### 2. Iterative (`IterativeFibonacci`)
- **Time Complexity**: O(n) - Linear
- **Space Complexity**: O(1) - Constant
- **Description**: Bottom-up iterative approach using only two variables
- **Use Case**: Most efficient for general purpose use

### 3. Memoized Recursive (`MemoizedFibonacci`)
- **Time Complexity**: O(n) - Linear (with memoization)
- **Space Complexity**: O(n) - For memoization cache + call stack
- **Description**: Recursive with caching to avoid redundant calculations
- **Use Case**: When you need to calculate multiple Fibonacci numbers

### 4. Dynamic Programming (`DynamicProgrammingFibonacci`)
- **Time Complexity**: O(n) - Linear
- **Space Complexity**: O(n) - For the array
- **Description**: Bottom-up approach building a table of results
- **Use Case**: When you need all Fibonacci numbers up to n

### 5. Matrix Exponentiation (`MatrixFibonacci`)
- **Time Complexity**: O(log n) - Logarithmic
- **Space Complexity**: O(log n) - Due to recursion in matrix exponentiation
- **Description**: Uses matrix multiplication and fast exponentiation
- **Use Case**: Most efficient for very large n values

## Running the Solution

### Build the Solution
```bash
dotnet build
```

### Run Tests
```bash
dotnet test
```

### Run Performance Benchmark
```bash
dotnet run --project FibonacciBenchmark
```

## Performance Results

The benchmark demonstrates clear performance differences:

- **Iterative**: Fastest and most memory efficient
- **Matrix Exponentiation**: Best for very large numbers (O(log n))
- **Dynamic Programming**: Good balance, useful when you need all values up to n
- **Memoized Recursive**: Good for multiple calculations, but higher memory overhead
- **Recursive**: Exponential time complexity, only suitable for small inputs

## Test Coverage

The test suite includes:
- Correctness verification for known Fibonacci values
- Consistency testing across all implementations
- Edge case handling (negative inputs)
- Large number testing for efficient implementations
- Unique naming verification

## Key Insights

1. **Recursive** approach demonstrates the importance of algorithm optimization
2. **Iterative** shows how simple changes can dramatically improve performance
3. **Memoization** illustrates the time-space tradeoff in optimization
4. **Matrix multiplication** shows advanced mathematical approaches to optimization
5. **Dynamic Programming** demonstrates systematic bottom-up problem solving