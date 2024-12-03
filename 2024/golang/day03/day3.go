package day3

import (
	"aoc-2024/input"
	"fmt"
	"iter"
	"regexp"
	"strconv"
	"strings"
)

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	reg := regexp.MustCompile(`mul\((\d{1,3}),(\d{1,3})\)`)
	for line := range input {
		if debug {
			fmt.Println(line)
		}
		for _, submatches := range reg.FindAllStringSubmatch(line, -1) {
			if debug {
				fmt.Println(submatches)
			}
			a, err := strconv.Atoi(submatches[1])
			if err != nil {
				panic(err)
			}
			b, err := strconv.Atoi(submatches[2])
			if err != nil {
				panic(err)
			}
			if debug {
				fmt.Println("a:", a, "b:", b, "mult:", a*b)
			}
			total = total + (a * b)
		}
	}

	return total
}

func part2(input iter.Seq[string], debug bool) int {
	total := 0

	reg := regexp.MustCompile(`mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)`)
	enabled := true
	for line := range input {
		if debug {
			fmt.Println(line)
		}
		for _, submatches := range reg.FindAllStringSubmatch(line, -1) {
			if debug {
				fmt.Println(submatches)
			}
			if submatches[0] == "do()" {
				enabled = true
				continue
			}
			if submatches[0] == "don't()" {
				enabled = false
				continue
			}
			if strings.Contains(submatches[0], "mul(") && enabled == false {
				continue
			}
			if debug {
				fmt.Println(enabled)
			}

			a, err := strconv.Atoi(submatches[1])
			if err != nil {
				panic(err)
			}
			b, err := strconv.Atoi(submatches[2])
			if err != nil {
				panic(err)
			}
			if debug {
				fmt.Println("a:", a, "b:", b, "mult:", a*b)
			}
			total = total + (a * b)
		}
	}

	return total
}

func Solve() {
	reader := input.InputDay(3)
	lines := input.AsLines(reader)

	reader2 := input.InputDay(3)
	lines2 := input.AsLines(reader2)

	println("=== Day 3 ===")
	fmt.Printf("Part 1: %v \n", part1(lines, false))
	fmt.Printf("Part 2: %v \n", part2(lines2, false))
}
