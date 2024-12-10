package day7

import (
	"aoc-2024/input"
	"fmt"
	"io"
	"strconv"
	"strings"
)

func addOrMult(target int, current int, index int, numbers []int, debug bool) bool {
	if debug {
		fmt.Println("target:", target)
	}

	if index >= len(numbers) {
		return false
	}

	next := numbers[index]

	if (current*next) == target && index == len(numbers)-1 {
		return true
	} else if addOrMult(target, current*next, index+1, numbers, debug) {
		return true
	}
	if (current+next) == target && index == len(numbers)-1 {
		return true
	} else if addOrMult(target, current+next, index+1, numbers, debug) {
		return true
	}

	return false
}

func addMultConcat(target int, current int, index int, numbers []int, debug bool) bool {
	if debug {
		fmt.Println("target:", target)
	}

	if index >= len(numbers) {
		return false
	}

	next := numbers[index]

	if (current*next) == target && index == len(numbers)-1 {
		return true
	} else if addMultConcat(target, current*next, index+1, numbers, debug) {
		return true
	}
	if (current+next) == target && index == len(numbers)-1 {
		return true
	} else if addMultConcat(target, current+next, index+1, numbers, debug) {
		return true
	}

	cur_str := strconv.Itoa(current)
	next_str := strconv.Itoa(next)
	new_str := cur_str + next_str
	newVal, err := strconv.Atoi(new_str)
	if err != nil {
		panic(err)
	}

	if newVal == target && index == len(numbers)-1 {
		return true
	} else if addMultConcat(target, newVal, index+1, numbers, debug) {
		return true
	}

	return false
}

func part1(reader io.Reader, debug bool) int {
	total := 0

	for line := range input.AsLines(reader) {
		split := strings.Split(line, ": ")
		if debug {
			fmt.Println("value:", split[0], "numbers", split[1])
		}

		target, err := strconv.Atoi(split[0])
		if err != nil {
			panic(err)
		}

		numbers := []int{}
		for _, val := range strings.Split(split[1], " ") {
			res, err := strconv.Atoi(val)
			if err != nil {
				panic(err)
			}
			numbers = append(numbers, res)
		}

		if addOrMult(target, numbers[0], 1, numbers, debug) {
			total += target
		}
	}

	return total
}

func part2(reader io.Reader, debug bool) int {
	total := 0

	for line := range input.AsLines(reader) {
		split := strings.Split(line, ": ")
		if debug {
			fmt.Println("value:", split[0], "numbers", split[1])
		}

		target, err := strconv.Atoi(split[0])
		if err != nil {
			panic(err)
		}

		numbers := []int{}
		for _, val := range strings.Split(split[1], " ") {
			res, err := strconv.Atoi(val)
			if err != nil {
				panic(err)
			}
			numbers = append(numbers, res)
		}

		if addMultConcat(target, numbers[0], 1, numbers, debug) {
			total += target
		}
	}

	return total
}

func Solve() {
	reader := input.InputDay(7)
	reader2 := input.InputDay(7)

	println("=== Day 7 ===")
	fmt.Printf("Part 1: %v \n", part1(reader, false))
	fmt.Printf("Part 2: %v \n", part2(reader2, false))
}
