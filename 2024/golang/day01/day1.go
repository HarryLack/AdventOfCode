package day1

import (
	"aoc-2024/input"
	"fmt"
	"iter"
	"slices"
	"strconv"
	"strings"
)

func abs(num int) int {
	if num < 0 {
		return -num
	}
	return num
}

func part1(input iter.Seq[string], debug bool) int {
	firsts := []int{}
	seconds := []int{}

	for line := range input {
		entries := strings.Split(line, "   ")
		first, err := strconv.Atoi(entries[0])
		if err != nil {
			panic(err)
		}
		firsts = append(firsts, first)

		second, err := strconv.Atoi(entries[1])
		if err != nil {
			panic(err)
		}
		seconds = append(seconds, second)
	}

	slices.SortFunc(firsts, func(a, b int) int {
		return a - b
	})
	slices.SortFunc(seconds, func(a, b int) int {
		return a - b
	})

	total := 0
	for i := range len(firsts) {
		if debug {
			fmt.Printf("First: %v	Second: %v	Diff: %v \n", firsts[i], seconds[i], abs(firsts[i]-seconds[i]))
		}
		total = total + abs(firsts[i]-seconds[i])
	}
	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func part2(input iter.Seq[string], debug bool) int {
	firsts := []int{}
	seconds := []int{}
	total := 0

	values := make(map[int]int)

	for line := range input {
		entries := strings.Split(line, "   ")
		first, err := strconv.Atoi(entries[0])
		if err != nil {
			panic(err)
		}
		firsts = append(firsts, first)

		second, err := strconv.Atoi(entries[1])
		if err != nil {
			panic(err)
		}
		seconds = append(seconds, second)
	}

	for i := range firsts {
		first := firsts[i]
		if val, found := values[first]; found {
			total = total + val
			if debug {
				fmt.Printf("first: %v	", first)
			}
		} else {
			count := 0

			for j := range seconds {
				second := seconds[j]
				if second == first {
					count = count + 1
				}
			}
			res := first * count
			total = total + res
			values[first] = res
			if debug {
				fmt.Printf("first: %v	count: %v	res: %v		", first, count, res)
			}
		}

		if debug {
			fmt.Printf("Total: %v \n", total)
		}
	}

	return total
}

func Solve() {
	reader := input.InputDay(1)

	lines := input.AsLines(reader)
	
	reader2 := input.InputDay(1)
	lines2 := input.AsLines(reader2)

	println("=== Day 1 ===")
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("Part2: %v \n", part2(lines2, false))
}
