package day

import (
	"aoc-2025/input"
	"fmt"
	"iter"
	"time"
)

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}
func part2(input iter.Seq[string], debug bool) int {
	total := 0

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func Solve() {
	reader := input.InputDay(-1)

	lines := input.AsLines(reader)

	reader2 := input.InputDay(-1)
	lines2 := input.AsLines(reader2)

	println("=== Day X ===")
	start := time.Now()
	prev := start
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("=== %v ===\n", time.Since(prev))
	prev = time.Now()
	fmt.Printf("Part2: %v \n", part2(lines2, false))
	fmt.Printf("=== %v ===\n", time.Since(prev))
	prev = time.Now()
	fmt.Printf("Sub-Total: %v\n", time.Since(start))
}
