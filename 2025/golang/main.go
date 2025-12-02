package main

import (
	day1 "aoc-2025/day01"
	day2 "aoc-2025/day02"
	"fmt"
	"os"
	"time"
)

func main() {
	args := os.Args

	start := time.Now()
	if len(args) == 2 {
		switch args[1] {
		case "1":
			day1.Solve()
			fmt.Printf("=== %v ===\n", time.Since(start))
		case "2":
			day2.Solve()
			fmt.Printf("=== %v ===\n", time.Since(start))
		}
	} else {
		prev := start
		day1.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
		day2.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
	}

	fmt.Printf("\nTotal: %v\n", time.Since(start))
}
