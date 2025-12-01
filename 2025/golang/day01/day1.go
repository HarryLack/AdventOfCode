package day1

import (
	"aoc-2025/input"
	"fmt"
	"iter"
	"strconv"
)

func abs(num int) int {
	if num < 0 {
		return -num
	}
	return num
}

type Entry struct {
	dir byte
	val int
}

func part1(input iter.Seq[string], debug bool) int {
	position := 50
	entries := []Entry{}

	for line := range input {
		if len(line) <= 0 {
			continue
		}
		dir := line[0]
		val := line[1:]
		i_val, err := strconv.Atoi(val)
		if err != nil {
			panic(err)
		}

		entries = append(entries, Entry{dir, i_val})

	}

	total := 0
	for _, entry := range entries {
		if debug {
			fmt.Printf("Position: %v	Dir: %c	Val: %v \n", position, entry.dir, entry.val)
		}

		if entry.dir == 'R' {
			position += entry.val
		}
		if entry.dir == 'L' {
			diff := 100 - entry.val
			position += diff
		}

		position = position % 100

		if position == 0 {
			total += 1
		}
	}
	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func part2(input iter.Seq[string], debug bool) int {
	position := 50
	entries := []Entry{}

	for line := range input {
		if len(line) <= 0 {
			continue
		}
		dir := line[0]
		val := line[1:]
		i_val, err := strconv.Atoi(val)
		if err != nil {
			panic(err)
		}

		entries = append(entries, Entry{dir, i_val})

	}

	total := 0
	for _, entry := range entries {
		if debug {
			fmt.Printf("Position: %v	Dir: %c	Val: %v \n", position, entry.dir, entry.val)
		}

		for i := 0; i < entry.val; i++ {
			if entry.dir == 'R' {
				position++
			}
			if entry.dir == 'L' {
				position--
			}

			position = position % 100
			if position == 0 {
				total += 1
			}
		}

	}
	if debug {
		fmt.Printf("Total: %v \n", total)
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
