package day4

import (
	"aoc-2025/input"
	"fmt"
	"iter"
)

type Digit struct {
	val int
	idx int
}
type Coord struct {
	x int
	y int
}

var neighbours = [8]Coord{
	{-1, -1}, {0, -1}, {1, -1},
	{-1, 0} /*{0,0},*/, {1, 0},
	{-1, 1}, {0, 1}, {1, 1},
}

func part1(input iter.Seq[string], debug bool) int {
	total := 0

	thingMap := [][]rune{}
	//Create map
	for line := range input {
		if len(line) == 0 {
			break
		}
		map_line := []rune{}
		for _, char := range line {
			map_line = append(map_line, char)
		}
		thingMap = append(thingMap, map_line)
	}
	if debug {
		fmt.Println(thingMap)
	}

	for y, row := range thingMap {
	col:
		for x, val := range row {
			if val != '@' {
				continue
			}
			adjacent := 0
			for _, coord := range neighbours {
				// Check y underflow
				if y+coord.y < 0 {
					continue
				}
				// Check y overflow
				if y+coord.y >= len(thingMap) {
					continue
				}
				// Check x underflow
				if x+coord.x < 0 {
					continue
				}
				// Check x overflow
				if x+coord.x >= len(row) {
					continue
				}

				new := Coord{coord.x + x, coord.y + y}

				if thingMap[new.y][new.x] == '@' {
					adjacent++
				}
				if adjacent > 4 {
					continue col
				}
			}
			if adjacent < 4 {
				if debug {
					fmt.Println(Coord{x, y}, "is a thing")
				}
				total++
			}
		}
	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func part2(input iter.Seq2[int, string], debug bool) int {
	total := 0

	thingMapMap := make(map[Coord]int)

	//Create map
	for row, line := range input {
		if len(line) == 0 {
			break
		}
		for col, char := range line {
			if char == '@' {
				thingMapMap[Coord{col, row}] = 0
			}
		}
	}
	if debug {
		fmt.Println(thingMapMap)
	}
	done := false
	for !done {
		rem := []Coord{}
		for roll, _ := range thingMapMap {
			adjacent := 0
			for _, coord := range neighbours {
				new := Coord{coord.x + roll.x, coord.y + roll.y}
				_, prs := thingMapMap[new]
				if prs {
					adjacent++
				}
			}
			thingMapMap[roll] = adjacent
			if adjacent < 4 {
				rem = append(rem, roll)
			}
		}

		total += len(rem)

		for _, coord := range rem {
			delete(thingMapMap, coord)
		}

		if len(rem) == 0 {
			done = true
		}
	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func Solve() {
	reader := input.InputDay(4)
	lines := input.AsLines(reader)

	reader2 := input.InputDay(4)
	lines2 := input.AsLinesIndexed(reader2)

	println("=== Day 4 ===")
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("Part2: %v \n", part2(lines2, false))
}
