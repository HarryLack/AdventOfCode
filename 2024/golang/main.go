package main

import (
	day1 "aoc-2024/day01"
	day2 "aoc-2024/day02"
	day3 "aoc-2024/day03"
	day4 "aoc-2024/day04"
	day5 "aoc-2024/day05"
	day6 "aoc-2024/day06"
	day7 "aoc-2024/day07"
	day8 "aoc-2024/day08"
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
		case "3":
			day3.Solve()
			fmt.Printf("=== %v ===\n", time.Since(start))
		case "4":
			day4.Solve()
			fmt.Printf("=== %v ===\n", time.Since(start))
		case "5":
			day5.Solve()
			fmt.Printf("=== %v ===\n", time.Since(start))
		case "6":
			day6.Solve()
			fmt.Printf("=== %v ===\n", time.Since(start))
		case "7":
			day7.Solve()
			fmt.Printf("=== %v ===\n", time.Since(start))
		case "8":
			day8.Solve()
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
		day3.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
		day4.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
		day5.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
		day6.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
		day7.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
		day8.Solve()
		fmt.Printf("=== %v ===\n", time.Since(prev))
		prev = time.Now()
	}

	fmt.Printf("\nTotal: %v\n", time.Since(start))
}
