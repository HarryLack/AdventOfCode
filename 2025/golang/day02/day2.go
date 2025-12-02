package day2

import (
	"aoc-2025/input"
	"fmt"
	"iter"
	"slices"
	"strconv"
	"strings"
)

func isValid(val string) bool {
	if (len(val) % 2) != 0 {
		return true
	}

	first := val[:len(val)/2]
	second := val[len(val)/2:]
	return first != second
}

func chunk(val string, size int) []string {
	str := val
	chunks := make([]string, 0)
	for len(str) > 0 {
		c := str[:size]
		str = str[size:]
		chunks = append(chunks, c)
	}

	return chunks
}

func isValid2(val string) bool {
	for i := 1; i < len(val); i++ {
		if len(val)%i != 0 {
			continue
		}
		chunks := chunk(val, i)
		uniq := slices.Compact(chunks)
		if len(uniq) == 1 {
			return false
		}
	}
	return true
}

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	next, _ := iter.Pull(input)
	line, _ := next()

	ranges := strings.Split(line, ",")

	for _, r := range ranges {
		split := strings.Split(r, "-")
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

		for i := start_i; i <= end_i; i++ {
			if !isValid(strconv.Itoa(i)) {
				if debug {
					fmt.Println(i, "is Invalid")
				}
				total += i
			} else {
				if debug {
					fmt.Println(i, "is Valid")
				}
			}
		}
	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func part2(input iter.Seq[string], debug bool) int {
	total := 0

	next, _ := iter.Pull(input)
	line, _ := next()

	ranges := strings.Split(line, ",")

	for _, r := range ranges {
		split := strings.Split(r, "-")
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

		for i := start_i; i <= end_i; i++ {
			if !isValid2(strconv.Itoa(i)) {
				if debug {
					fmt.Println(i, "is Invalid")
				}
				total += i
			} else {
				if debug {
					fmt.Println(i, "is Valid")
				}
			}
		}
	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func Solve() {
	reader := input.InputDay(2)

	lines := input.AsLines(reader)

	reader2 := input.InputDay(2)
	lines2 := input.AsLines(reader2)

	println("=== Day 2 ===")
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("Part2: %v \n", part2(lines2, false))
}
