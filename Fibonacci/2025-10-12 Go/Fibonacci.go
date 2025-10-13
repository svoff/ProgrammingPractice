package main

import (
	"fmt"
	"os"
	"strconv"
)

func main() {
	n := 10
	if len(os.Args) > 1 {
		if val, err := strconv.Atoi(os.Args[1]); err == nil {
			n = val
		}
	}

	for i := 0; i < n; i++ {
		fmt.Println(Fib(i))
	}
}

func Fib(n int) int {
	if n == 0 {
		return 0
	} else if n == 1 {
		return 1
	} else {
		return Fib(n-1) + Fib(n-2)
	}
}
