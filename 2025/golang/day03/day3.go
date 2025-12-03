package day3

import (
	"aoc-2025/input"
	"fmt"
	"iter"
	"slices"
	"strconv"
	"strings"
)

type Digit struct {
	val int
	idx int
}

func findLargest(digits []rune) Digit {
	largest := Digit{-1, -1}
	for i, dig := range digits {
		dig_i := int(dig - '0')
		if dig_i > largest.val {
			largest = Digit{dig_i, i}
		}
	}

	return largest
}

func remove(slice []int, index int) []int {
	return append(slice[:index], slice[index+1:]...)
}

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	for line := range input {
		if len(line) <= 0 {
			continue
		}

		digits := []rune(line)

		largest := findLargest(digits[:len(digits)-1])
		second := findLargest(digits[largest.idx+1:])
		if debug {
			fmt.Println(line, largest, second)
		}
		total += largest.val*10 + second.val

	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func part2(input iter.Seq[string], debug bool) int {
	total := 0

	for line := range input {
		if len(line) <= 0 {
			continue
		}

		if debug {
			fmt.Println("Line:", line)
		}

		digits_r := []rune(line)
		digits_i := []int{}
		digits := []Digit{}
		for i, dig := range digits_r {
			dig_i := int(dig - '0')
			digits_i = append(digits_i, dig_i)
			digits = append(digits, Digit{dig_i, i})
		}

		final := []Digit{}
		prev := Digit{-1, -1}
		for len(final) < 12 {
			lim := len(digits) - 12 + len(final)
			window := make([]Digit, len(digits))
			copy(window, digits[prev.idx+1:lim+1])
			if debug {
				fmt.Println(prev.idx+1, lim, window)
				fmt.Println(digits)
			}
			slices.SortStableFunc(window, func(a Digit, b Digit) int {
				return b.val - a.val
			})
			final = append(final, window[0])
			prev = window[0]
		}
		// if debug {
		// 	fmt.Println("Final Pre-sort", final)
		// }
		// slices.SortStableFunc(final, func(a Digit, b Digit) int {
		// 	return a.idx - b.idx
		// })

		var big strings.Builder

		for _, dig := range final {
			big.WriteRune(digits_r[dig.idx])
		}

		sum, err := strconv.Atoi(big.String())
		if debug {
			fmt.Println("Digits:", digits, "\n", "Big string:", big.String(), "\n", "Val:", sum, "Final", final)
		}
		if err != nil {
			panic(err)
		}

		total += sum
	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func Solve() {
	reader := input.InputDay(3)

	lines := input.AsLines(reader)

	reader2 := input.InputDay(3)
	lines2 := input.AsLines(reader2)

	println("=== Day 3 ===")
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("Part2: %v \n", part2(lines2, false))
}
