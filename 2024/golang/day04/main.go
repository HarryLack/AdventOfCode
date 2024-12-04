package day4

import (
	"aoc-2024/input"
	"fmt"
	"iter"
)

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	chars := [][]rune{}

	for line := range input {
		lineChars := make([]rune, len(line))
		for i, char := range line {
			lineChars[i] = char
		}
		chars = append(chars, lineChars)
	}

	if debug {
		fmt.Println(chars)
	}

	rows := len(chars)
	cols := len(chars[0])

	for i, line := range chars {
		// fmt.Println(line)
		for j, char := range line {
			// fmt.Println(char)
			// Only check from X as starting letter
			if char != 'X' {
				continue
			}
			left_safe := j >= 3
			right_safe := j+3 < cols
			up_safe := i >= 3
			down_safe := i+3 < rows

			// Left
			if left_safe {
				str := string(char) + string(line[j-1]) + string(line[j-2]) + string(line[j-3])
				if debug {
					fmt.Println("Left:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
			// Right
			if right_safe {
				str := string(char) + string(line[j+1]) + string(line[j+2]) + string(line[j+3])
				if debug {
					fmt.Println("Left:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
			// Up
			if up_safe {
				str := string(char) + string(chars[i-1][j]) + string(chars[i-2][j]) + string(chars[i-3][j])
				if debug {
					fmt.Println("Up:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
			// Down
			if down_safe {
				str := string(char) + string(chars[i+1][j]) + string(chars[i+2][j]) + string(chars[i+3][j])
				if debug {
					fmt.Println("Down:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
			// Up Left
			if up_safe && left_safe {
				str := string(char) + string(chars[i-1][j-1]) + string(chars[i-2][j-2]) + string(chars[i-3][j-3])
				if debug {
					fmt.Println("Up Left:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
			// Up Right
			if up_safe && right_safe {
				str := string(char) + string(chars[i-1][j+1]) + string(chars[i-2][j+2]) + string(chars[i-3][j+3])
				if debug {
					fmt.Println("Up Right:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
			// Down Left
			if down_safe && left_safe {
				str := string(char) + string(chars[i+1][j-1]) + string(chars[i+2][j-2]) + string(chars[i+3][j-3])
				if debug {
					fmt.Println("Down Left:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
			// Down Right
			if down_safe && right_safe {
				str := string(char) + string(chars[i+1][j+1]) + string(chars[i+2][j+2]) + string(chars[i+3][j+3])
				if debug {
					fmt.Println("Down Right:", str)
				}
				if str == "XMAS" {
					total = total + 1
				}
			}
		}
	}

	return total
}

func part2(input iter.Seq[string], debug bool) int {
	total := 0

	chars := [][]rune{}

	for line := range input {
		lineChars := make([]rune, len(line))
		for i, char := range line {
			lineChars[i] = char
		}
		chars = append(chars, lineChars)
	}

	if debug {
		fmt.Println(chars)
	}

	rows := len(chars)
	cols := len(chars[0])

	for i, line := range chars {
		for j, char := range line {
			// Only check from X as starting letter
			if char != 'A' {
				continue
			}
			left_safe := j >= 1
			right_safe := j+1 < cols
			up_safe := i >= 1
			down_safe := i+1 < rows

			if !(left_safe && right_safe && up_safe && down_safe) {
				continue
			}

			// Down Right
			left_right := string(chars[i-1][j-1]) + string(char) + string(chars[i+1][j+1])
			if debug {
				fmt.Println("left_right", left_right)
			}
			right_left := string(chars[i-1][j+1]) + string(char) + string(chars[i+1][j-1])
			if debug {
				fmt.Println("right_left", right_left)
			}
			left_right_correct := left_right == "MAS" || left_right == "SAM"
			right_left_correct := right_left == "MAS" || right_left == "SAM"
			if left_right_correct && right_left_correct {
				total = total + 1
			}
		}
	}

	return total
}

func Solve() {
	reader := input.InputDay(4)
	lines := input.AsLines(reader)

	reader2 := input.InputDay(4)
	lines2 := input.AsLines(reader2)

	println("=== Day 4 ===")
	fmt.Printf("Part 1: %v \n", part1(lines, false))
	fmt.Printf("Part 2: %v \n", part2(lines2, false))
}
