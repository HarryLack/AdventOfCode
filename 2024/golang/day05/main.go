package day5

import (
	"aoc-2024/input"
	"fmt"
	"io"
	"slices"
	"strconv"
	"strings"
)

func part1(reader io.Reader, debug bool) int {
	total := 0

	sections := input.AsSections(reader)
	rules := make(map[int][]int)
	updates := [][]int{}

	sec_num := 0
	for section := range sections {
		lines := strings.Split(section, "\n")

	liner:
		for _, line := range lines {
			if debug {
				fmt.Println("\n", "line:", line)
			}
			if sec_num == 0 {
				str_nums := strings.Split(line, "|")
				nums := [2]int{}

				first, _ := strconv.Atoi(str_nums[0])
				nums[0] = first
				second, _ := strconv.Atoi(str_nums[1])
				nums[1] = second

				if debug {
					fmt.Println("nums:", nums)
				}

				rules[first] = append(rules[first], second)
			} else {
				if len(line) == 0 {
					continue
				}
				str_nums := strings.Split(line, ",")
				nums := []int{}

				for _, val := range str_nums {
					i_val, _ := strconv.Atoi(val)
					for _, val := range nums {
						if slices.Contains(rules[i_val], val) {
							if debug {
								fmt.Println("cont")
							}
							continue liner
						}
					}

					nums = append(nums, i_val)
				}

				updates = append(updates, nums)

				mid := len(nums) / 2
				if debug {
					fmt.Println(nums, mid)
				}
				total += nums[mid]
				if debug {

					fmt.Println(total)
				}
			}
		}

		sec_num += 1
	}

	return total
}

func part2(reader io.Reader, debug bool) int {
	total := 0

	sections := input.AsSections(reader)
	rules := make(map[int][]int)
	bad_updates := [][]int{}

	sec_num := 0
	for section := range sections {
		lines := strings.Split(section, "\n")

	liner:
		for _, line := range lines {
			if debug {
				fmt.Println("\n", "line:", line)
			}
			if sec_num == 0 {
				str_nums := strings.Split(line, "|")
				nums := [2]int{}

				first, _ := strconv.Atoi(str_nums[0])
				nums[0] = first
				second, _ := strconv.Atoi(str_nums[1])
				nums[1] = second

				if debug {
					fmt.Println("nums:", nums)
				}

				rules[first] = append(rules[first], second)
			} else {
				if len(line) == 0 {
					continue
				}
				str_nums := strings.Split(line, ",")
				nums := []int{}

				for _, val := range str_nums {
					i_val, _ := strconv.Atoi(val)
					nums = append(nums, i_val)
				}

				if debug {
					fmt.Println(nums)
				}

				for idx, val := range nums {
					i_val := val
					for i := 0; i < idx; i++ {
						num := nums[i]
						if slices.Contains(rules[i_val], num) {
							if debug {
								fmt.Println("bad")
							}
							bad_updates = append(bad_updates, nums)

							continue liner
						}
					}

				}

			}
		}
		if debug {
			fmt.Println("bad", bad_updates)
		}

		for _, update := range bad_updates {
			slices.SortFunc(update, func(a, b int) int {
				if rules[a] != nil {
					if slices.Contains(rules[a], b) {
						return -1
					}
				}
				return 0
			})
			mid := len(update) / 2
			if debug {
				fmt.Println(update, mid)
			}
			total += update[mid]
			if debug {

				fmt.Println(total)
			}
		}

		sec_num += 1
	}

	return total
}

func Solve() {
	reader := input.InputDay(5)
	reader2 := input.InputDay(5)

	println("=== Day 5 ===")
	fmt.Printf("Part 1: %v \n", part1(reader, false))
	fmt.Printf("Part 2: %v \n", part2(reader2, false))
}
