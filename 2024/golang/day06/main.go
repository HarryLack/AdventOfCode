package day6

import (
	"aoc-2024/input"
	"fmt"
	"io"
)

func checkInMap(gMap [][]rune, pos [2]int) bool {
	return pos[0] >= 0 && pos[0] < len(gMap[0]) && pos[1] >= 0 && pos[1] < len(gMap)
}

func part1(reader io.Reader, debug bool) int {
	total := 0

	lines := input.AsLines(reader)
	guardMap := [][]rune{}
	guardPos := [2]int{0, 0}

	//Create map
	for line := range lines {
		map_line := []rune{}
		for i, char := range line {
			map_line = append(map_line, char)
			if char == '^' {
				guardPos = [2]int{i, len(guardMap)}
			}
		}
		guardMap = append(guardMap, map_line)
	}

	//Traverse map
	inMap := checkInMap(guardMap, guardPos)

	iterer := 0
	for inMap && iterer < 1_000_000 {
		x := guardPos[0]
		y := guardPos[1]
		checkPos := [2]int{-1, -1}
		switch guardMap[y][x] {
		case '^':
			checkPos = [2]int{x, y - 1}
		case 'v':
			checkPos = [2]int{x, y + 1}
		case '>':
			checkPos = [2]int{x + 1, y}
		case '<':
			checkPos = [2]int{x - 1, y}
		}
		if debug {
			fmt.Println("check", checkPos)
		}
		if checkInMap(guardMap, checkPos) {
			if guardMap[checkPos[1]][checkPos[0]] == '#' {
				switch guardMap[y][x] {
				case '^':
					guardMap[y][x] = '>'
				case 'v':
					guardMap[y][x] = '<'
				case '>':
					guardMap[y][x] = 'v'
				case '<':
					guardMap[y][x] = '^'
				}
				continue
			} else {
				guardMap[checkPos[1]][checkPos[0]] = guardMap[y][x]
			}
		}
		guardMap[y][x] = 'X'
		guardPos = checkPos
		inMap = checkInMap(guardMap, guardPos)
		iterer += 1
	}
	for _, line := range guardMap {
		if debug {
			fmt.Println(string(line))
		}
		for _, char := range line {
			if char == 'X' {
				total += 1
			}
		}
	}

	return total
}

func printMap(area [][]rune) {
	for _, line := range area {
		fmt.Println(string(line))
	}
}

func traverseLoop(area [][]rune, startPos [2]int, debug bool) bool {
	iterer := 0
	areaMap := make([][]rune, len(area))
	for i := range area {
		areaMap[i] = make([]rune, len(area[i]))
		copy(areaMap[i], area[i])
	}
	tPos := [2]int{startPos[0], startPos[1]}
	inMap := checkInMap(areaMap, tPos)
	for inMap && iterer < (len(area)*len(area)) {
		x := tPos[0]
		y := tPos[1]
		checkPos := [2]int{-1, -1}
		switch areaMap[y][x] {
		case '^':
			checkPos = [2]int{x, y - 1}
		case 'v':
			checkPos = [2]int{x, y + 1}
		case '>':
			checkPos = [2]int{x + 1, y}
		case '<':
			checkPos = [2]int{x - 1, y}
		}

		if checkInMap(areaMap, checkPos) {
			if areaMap[checkPos[1]][checkPos[0]] == '#' {
				switch areaMap[y][x] {
				case '^':
					areaMap[y][x] = '>'
				case 'v':
					areaMap[y][x] = '<'
				case '>':
					areaMap[y][x] = 'v'
				case '<':
					areaMap[y][x] = '^'
				}
				continue
			} else {
				areaMap[checkPos[1]][checkPos[0]] = areaMap[y][x]
			}
		}
		areaMap[y][x] = 'X'
		tPos = checkPos
		inMap = checkInMap(areaMap, tPos)
		iterer += 1
	}

	if inMap {
		if debug {
			printMap(areaMap)
		}
		return true
	}

	if debug {
		printMap(areaMap)
	}
	return false
}

func part2(reader io.Reader, debug bool) int {
	total := 0

	lines := input.AsLines(reader)
	guardMap := [][]rune{}
	guardPos := [2]int{0, 0}
	//Create map
	for line := range lines {
		map_line := []rune{}
		for i, char := range line {
			map_line = append(map_line, char)
			if char == '^' {
				guardPos = [2]int{i, len(guardMap)}
			}
		}
		guardMap = append(guardMap, map_line)
	}

	//Traverse map
	for y, line := range guardMap {
		if debug {
			fmt.Println(string(line))
		}
		for x, char := range line {
			if char == '#' || char == '^' || char == 'v' || char == '<' || char == '>' {
				continue
			}
			areaMap := make([][]rune, len(guardMap))
			for i := range guardMap {
				areaMap[i] = make([]rune, len(guardMap[i]))
				copy(areaMap[i], guardMap[i])
			}
			areaMap[y][x] = '#'
			if debug {
				fmt.Println(y, x)
			}
			loops := traverseLoop(areaMap, guardPos, debug)
			if loops {
				total += 1
			}
		}
	}

	return total
}

func Solve() {
	reader := input.InputDay(6)
	reader2 := input.InputDay(6)

	println("=== Day 6 ===")
	fmt.Printf("Part 1: %v \n", part1(reader, false))
	fmt.Printf("Part 2: %v \n", part2(reader2, false))
}
