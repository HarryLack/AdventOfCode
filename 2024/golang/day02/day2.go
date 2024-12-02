package day2

import (
	"aoc-2024/input"
	"aoc-2024/utils"
	"fmt"
	"iter"
	"slices"
	"strconv"
	"strings"
)

func sliceAtoi(string_slice []string) ([]int, error) {
	int_slice := make([]int, 0, len(string_slice))
	for _, a := range string_slice {
		i, err := strconv.Atoi(a)
		if err != nil {
			return int_slice, err
		}
		int_slice = append(int_slice, i)
	}
	return int_slice, nil
}

func part1(input iter.Seq[string], debug bool) int {
	total := 0
	for report := range input {
		levels, err := sliceAtoi(strings.Split(report, " "))
		if err != nil {
			panic(err)
		}

		// Ascending
		sort_clone := slices.Clone(levels[0:])
		slices.Sort(sort_clone)
		// Descending
		rev_sort_clone := slices.Clone(levels[0:])
		slices.Sort(rev_sort_clone)
		slices.Reverse(rev_sort_clone)

		if debug {
			fmt.Printf("Levels: %v	Sort: %v	Rev: %v\n", levels, sort_clone, rev_sort_clone)
		}

		equal := slices.Equal(levels, sort_clone) || slices.Equal(levels, rev_sort_clone)

		if !equal {
			continue
		}

		diffs := make([]int, 0, len(levels))
		for idx, val := range levels {
			if idx == (len(levels) - 1) {
				continue
			}

			diff := utils.Abs(val - levels[idx+1])
			if utils.Abs(diff) < 1 || utils.Abs(diff) > 3 {
				break
			}
			diffs = append(diffs, diff)
		}

		if debug {
			fmt.Printf("Diffs: %v\n", diffs)
		}

		if len(diffs) < len(levels)-1 {
			continue
		}

		total = total + 1
	}

	return total
}

func part2(input iter.Seq[string], debug bool) int {
	total := 0

	for report := range input {
		levels, err := sliceAtoi(strings.Split(report, " "))
		if err != nil {
			panic(err)
		}

		for i := range levels {
			levels := slices.Concat(levels[0:i], levels[i+1:])

			// Ascending
			sort_clone := slices.Clone(levels[0:])
			slices.Sort(sort_clone)
			// Descending
			rev_sort_clone := slices.Clone(levels[0:])
			slices.Sort(rev_sort_clone)
			slices.Reverse(rev_sort_clone)

			if debug {
				fmt.Printf("Levels: %v	Sort: %v	Rev: %v\n", levels, sort_clone, rev_sort_clone)
			}

			equal := slices.Equal(levels, sort_clone) || slices.Equal(levels, rev_sort_clone)

			if !equal {
				continue
			}

			diffs := make([]int, 0, len(levels))
			for idx, val := range levels {
				if idx == (len(levels) - 1) {
					continue
				}

				diff := utils.Abs(val - levels[idx+1])
				if utils.Abs(diff) < 1 || utils.Abs(diff) > 3 {
					break
				}
				diffs = append(diffs, diff)
			}

			if debug {
				fmt.Printf("Diffs: %v\n", diffs)
			}

			if len(diffs) < len(levels)-1 {
				continue
			}

			total = total + 1
			break
		}
	}

	return total
}

func Solve() {
	reader := input.InputDay(2)
	lines := input.AsLines(reader)

	reader2 := input.InputDay(2)
	lines2 := input.AsLines(reader2)

	println("=== Day 2 ===")
	fmt.Printf("Part 1: %v \n", part1(lines, false))
	fmt.Printf("Part 2: %v \n", part2(lines2, false))
}
