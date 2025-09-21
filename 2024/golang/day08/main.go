package day8

import (
	"aoc-2024/input"
	"fmt"
	"io"
	"math"
	"strconv"
)

func part1(reader io.Reader, debug bool) int {
	total := 0

	nodeMap := [][]rune{}
	antennas := make(map[rune][][2]int)

	for line := range input.AsLines(reader) {
		if debug {
			fmt.Println(line)
		}
		//Create map
		mapLine := []rune{}
		for i, char := range line {
			mapLine = append(mapLine, char)
			if char != '.' {
				antennas[char] = append(antennas[char], [2]int{i, len(nodeMap)})
			}
		}
		nodeMap = append(nodeMap, mapLine)
	}

	inRange := func(point [2]int) bool {
		return point[0] >= 0 && point[0] < len(nodeMap[0]) && point[1] >= 0 && point[1] < len(nodeMap)
	}

	for freq := range antennas {
		if debug {
			fmt.Println("freq", strconv.QuoteRune(freq), antennas[freq])
		}
		// Do antinodes
		for i, node := range antennas[freq] {
			baseNode := node
			if debug {
				fmt.Println("checking", node)
			}
			for _, compNode := range antennas[freq][(i + 1):] {
				if debug {
					fmt.Println("comp", compNode)
				}
				slope := float64(compNode[1]-baseNode[1]) / float64(compNode[0]-baseNode[0])
				if debug {
					fmt.Println("slope", slope)
				}
				baseAntiNode := [2]float64{-1, -1}
				compAntiNode := [2]float64{-1, -1}
				if slope > 0 {
					xDiff := float64(compNode[0] - baseNode[0])
					yDiff := xDiff * slope
					if debug {
						fmt.Println("xDiff", xDiff, "yDiff", yDiff)
					}
					baseAntiNode = [2]float64{float64(baseNode[0]) - xDiff, float64(baseNode[1]) - yDiff}
					compAntiNode = [2]float64{float64(compNode[0]) + xDiff, float64(compNode[1]) + yDiff}
				} else {
					xDiff := float64(compNode[0] - baseNode[0])
					yDiff := xDiff * slope
					if debug {
						fmt.Println("xDiff", xDiff, "yDiff", yDiff)
					}
					baseAntiNode = [2]float64{float64(baseNode[0]) - xDiff, float64(baseNode[1]) - yDiff}
					compAntiNode = [2]float64{float64(compNode[0]) + xDiff, float64(compNode[1]) + yDiff}
				}
				if debug {
					fmt.Println("anti", baseAntiNode)
					fmt.Println("comp anti", compAntiNode)
				}

				baseAntiNodeInt := [2]int{int(baseAntiNode[0]), int(baseAntiNode[1])}
				if baseAntiNode[0] == math.Trunc(baseAntiNode[0]) && baseAntiNode[1] == math.Trunc(baseAntiNode[1]) {
					if inRange(baseAntiNodeInt) {
						nodeMap[baseAntiNodeInt[1]][baseAntiNodeInt[0]] = '#'
					}
				}
				compAntiNodeInt := [2]int{int(compAntiNode[0]), int(compAntiNode[1])}
				if compAntiNode[0] == math.Trunc(compAntiNode[0]) && compAntiNode[1] == math.Trunc(compAntiNode[1]) {
					if inRange(compAntiNodeInt) {
						nodeMap[compAntiNodeInt[1]][compAntiNodeInt[0]] = '#'
					}
				}
			}
		}
	}

	for _, row := range nodeMap {
		str := ""
		for _, char := range row {
			if char == '#' {
				total += 1
			}
			str += string(char)
		}
		if debug {
			fmt.Println(str)
		}
	}

	return total
}

func part2(reader io.Reader, debug bool) int {
	total := 0

	nodeMap := [][]rune{}
	antennas := make(map[rune][][2]int)

	for line := range input.AsLines(reader) {
		if debug {
			fmt.Println(line)
		}
		//Create map
		mapLine := []rune{}
		for i, char := range line {
			mapLine = append(mapLine, char)
			if char != '.' {
				antennas[char] = append(antennas[char], [2]int{i, len(nodeMap)})
			}
		}
		nodeMap = append(nodeMap, mapLine)
	}

	inRange := func(point [2]int) bool {
		return point[0] >= 0 && point[0] < len(nodeMap[0]) && point[1] >= 0 && point[1] < len(nodeMap)
	}

	for freq := range antennas {
		if debug {
			fmt.Println(freq, antennas[freq])
		}
		// Do antinodes
		for i, node := range antennas[freq] {
			if i == len(antennas[freq])-1 {
				continue
			}
			baseNode := node
			for j, compNode := range antennas[freq] {
				if i == j {
					continue
				}
				slopeRatios := [2]int{(compNode[0] - baseNode[0]), (compNode[1] - baseNode[1])}
				// reduce to a ratio against 1?
				newNode := [2]int{baseNode[0] + slopeRatios[0], baseNode[1] + slopeRatios[1]}
				for inRange(newNode) {
					if debug {
						fmt.Println(newNode)
					}
					nodeMap[newNode[1]][newNode[0]] = '#'

					newNode = [2]int{newNode[0] + slopeRatios[0], newNode[1] + slopeRatios[1]}
				}
				newNode = [2]int{newNode[0] - slopeRatios[0], newNode[1] - slopeRatios[1]}
				for inRange(newNode) {
					if debug {
						fmt.Println(newNode)
					}
					nodeMap[newNode[1]][newNode[0]] = '#'

					newNode = [2]int{newNode[0] - slopeRatios[0], newNode[1] - slopeRatios[1]}
				}
			}
		}
	}

	for _, row := range nodeMap {
		str := ""
		for _, char := range row {
			if char == '#' {
				total += 1
			}
			str += string(char)
		}
		if debug {
			fmt.Println(str)
		}
	}

	return total
}

func Solve() {
	reader := input.InputDay(8)
	reader2 := input.InputDay(8)

	println("=== Day 8 ===")
	fmt.Printf("Part 1: %v \n", part1(reader, false))
	fmt.Printf("Part 2: %v \n", part2(reader2, false))
}
