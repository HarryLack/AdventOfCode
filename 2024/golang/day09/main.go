package day9

import (
	"aoc-2024/input"
	"fmt"
	"io"
	"strconv"
)

func part1(reader io.Reader, debug bool) int {
	total := 0

	reader_bytes, err := io.ReadAll(reader)
	if err != nil {
		panic(err)
	}

	if debug {
		fmt.Println(string(reader_bytes))
	}

	file_ids := []string{}
	file_id := 0
	for index, b := range reader_bytes {
		if b == '\n' {
			break
		}
		count, err := strconv.Atoi(string(b))
		if err != nil {
			panic(err)
		}
		slice := make([]string, count)
		if index%2 == 0 {
			for i := range count {
				slice[i] = strconv.Itoa(file_id)
			}
			file_ids = append(file_ids, slice...)
			file_id += 1
		} else {
			for i := range count {
				slice[i] = "."
			}
			file_ids = append(file_ids, slice...)
		}
	}

	head := 0
	tail := len(file_ids) - 1

	if debug {
		fmt.Println("ID'd:", file_ids, "head", head, "tail", tail)
	}

	for head < tail {
		for file_ids[head] != "." {
			head += 1
		}
		for file_ids[tail] == "." {
			tail -= 1
		}
		if head > tail {
			break
		}
		file_ids[head] = file_ids[tail]
		file_ids[tail] = "."

		if debug {
			fmt.Println(file_ids, "head", head, "tail", tail)
		}
	}

	if debug {
		fmt.Println("Processed:", file_ids, "head", head, "tail", tail)
	}

	for index, v := range file_ids {
		if v == "." {
			break
		}
		val, err := strconv.Atoi(v)
		if err != nil {
			panic(err)
		}

		total += index * val
	}
	if debug {
		fmt.Println("Result:", total)
	}
	return total
}

func part2(reader io.Reader, debug bool) int {
	total := 0

	return total
}

func Solve() {
	reader := input.InputDay(9)
	reader2 := input.InputDay(9)

	println("=== Day 9 ===")
	fmt.Printf("Part 1: %v \n", part1(reader, false))
	fmt.Printf("Part 2: %v \n", part2(reader2, false))
}
