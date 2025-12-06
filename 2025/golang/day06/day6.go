package day6

import (
	"aoc-2025/input"
	"aoc-2025/utils"
	"fmt"
	"iter"
	"slices"
	"strconv"
	"strings"
)

type Calc struct {
	fields   []string
	operator rune
}

func doCalcCalc(calc Calc) int {
	inter := []int{}

	for _, field := range calc.fields {
		val, err := strconv.Atoi(field)
		if err != nil {
			continue
		}
		inter = append(inter, val)
	}

	return doCalc(inter, calc.operator)
}

func doCalc(fields []int, operator rune) int {
	if len(fields) == 0 {
		return 0
	}
	total := fields[0]
	for _, field := range fields[1:] {
		switch operator {
		case '+':
			total += field
		case '*':
			total *= field
		}
	}
	return total
}

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	calcs := make(map[int][]int)

	for line := range input {
		if len(line) == 0 {
			continue
		}

		fields := strings.Fields(line)
		for col, field := range fields {
			val, err := strconv.Atoi(field)
			if err != nil {
				total += doCalc(calcs[col], []rune(field)[0])
			} else {
				new := append(calcs[col], val)
				calcs[col] = new
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

	rows := [][]rune{}
	for line := range input {
		if len(line) == 0 {
			continue
		}
		runed := []rune(line)
		slices.Reverse(runed)
		rows = append(rows, runed)
	}

	vals := []string{}
	ops := []rune{}
	for i := 0; i < len(rows[0]); i++ {
		col := ""
		for _, row := range rows {
			if row[i] == ' ' {
				continue
			}
			if row[i] == '+' || row[i] == '*' {
				ops = append(ops, row[i])
			} else {
				col += string(row[i])
			}
		}
		vals = append(vals, col)
	}

	for i, val := range utils.ChunkByValue(vals, "") {
		if debug {
			fmt.Println(i, val, ops)
		}
		calc := Calc{val, ops[i]}
		temp := doCalcCalc(calc)
		total += temp
	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func Solve() {
	reader := input.InputDay(6)
	lines := input.AsLines(reader)

	reader2 := input.InputDay(6)
	lines2 := input.AsLines(reader2)

	println("=== Day 6 ===")
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("Part2: %v \n", part2(lines2, false))
}
