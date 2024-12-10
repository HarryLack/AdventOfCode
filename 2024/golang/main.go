package main

import (
	"aoc-2024/day01"
	"aoc-2024/day02"
	"aoc-2024/day03"
	"aoc-2024/day04"
	"aoc-2024/day05"
	"aoc-2024/day06"
	"aoc-2024/day07"
	"fmt"
	"time"
)

func main() {
	start := time.Now()
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

	fmt.Printf("\nTotal: %v\n", time.Since(start))
}
