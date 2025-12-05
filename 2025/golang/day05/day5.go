package day5

import (
	"aoc-2025/input"
	"aoc-2025/utils"
	"fmt"
	"iter"
	"slices"
	"strconv"
	"strings"
)

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	ranges := []utils.Range{}
	ingredients := []int{}

	for line := range input {
		if len(line) == 0 {
			continue
		}

		if strings.Contains(line, "-") {
			split := strings.Split(line, "-")
			if len(split) == 1 {
				fmt.Println(split, "is bad?")
			}
			start := split[0]
			end := split[1]

			start_i, err := strconv.Atoi(start)
			if err != nil {
				panic(err)
			}

			end_i, err := strconv.Atoi(end)
			if err != nil {
				panic(err)
			}
			ranges = append(ranges, utils.Range{Start: start_i, End: end_i})

		} else {
			ingredient, err := strconv.Atoi(line)
			if err != nil {
				panic(err)
			}
			ingredients = append(ingredients, ingredient)

			for _, r := range ranges {
				if ingredient >= r.Start && ingredient <= r.End {
					total++
					break
				}
			}
		}
	}

	if debug {
		fmt.Println("Ranges:", ranges)
		fmt.Println("Ingredients:", ingredients)
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func part2(input iter.Seq[string], debug bool) int {
	total := 0

	ranges := []utils.Range{}

	for line := range input {
		if len(line) == 0 {
			break
		}

		if strings.Contains(line, "-") {
			split := strings.Split(line, "-")
			if len(split) == 1 {
				fmt.Println(split, "is bad?")
			}
			start := split[0]
			end := split[1]

			start_i, err := strconv.Atoi(start)
			if err != nil {
				panic(err)
			}

			end_i, err := strconv.Atoi(end)
			if err != nil {
				panic(err)
			}
			ranges = append(ranges, utils.Range{Start: start_i, End: end_i})

		}
	}

	slices.SortStableFunc(ranges, func(a utils.Range, b utils.Range) int {
		return a.Start - b.Start
	})

	cur := ranges[0]
	for _, next := range ranges[1:] {
		if next.Start > cur.End {
			total += cur.End - cur.Start + 1
			cur = next
			continue
		}

		cur.End = max(cur.End, next.End)
	}
	total += cur.End - cur.Start + 1

	if debug {
		fmt.Println("Ranges:", ranges)
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func Solve() {
	reader := input.InputDay(5)
	lines := input.AsLines(reader)

	reader2 := input.InputDay(5)
	lines2 := input.AsLines(reader2)

	println("=== Day 5 ===")
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("Part2: %v \n", part2(lines2, false))
}
