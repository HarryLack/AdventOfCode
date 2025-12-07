package day7

import (
	"aoc-2025/input"
	"aoc-2025/utils"
	"fmt"
	"iter"
	"maps"
	"slices"
	"time"
)

func part1(input iter.Seq2[int, string], debug bool) int {
	total := 0

	max_y := -1
	start := utils.Coord{X: -1, Y: -1}
	splitters := make(map[int][]int)

	for row, line := range input {
		for col, char := range line {
			if char == 'S' {
				start = utils.Coord{X: col, Y: row}
			}
			if char == '^' {
				splitters[row] = append(splitters[row], col)
			}
		}
		if row > max_y {
			max_y = row
		}
	}

	if debug {
		fmt.Println("Start", start, "Splitters", splitters)
	}

	beams := map[int]bool{start.X: true}
	keys := slices.SortedStableFunc(maps.Keys(splitters), func(a int, b int) int {
		return a - b
	})
	for _, key := range keys {
		splits := splitters[key]
		for beam := range beams {
			if slices.Contains(splits, beam) {
				total++
				delete(beams, beam)
				beams[beam-1] = true
				beams[beam+1] = true
			}
		}
		if debug {
			fmt.Println("Key", key, "Beams:", beams)
		}
	}
	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func part2(input iter.Seq2[int, string], debug bool) int {
	total := 0

	max_y := -1
	start := utils.Coord{X: -1, Y: -1}
	splitters := make(map[int][]int)

	for row, line := range input {
		for col, char := range line {
			if char == 'S' {
				start = utils.Coord{X: col, Y: row}
			}
			if char == '^' {
				splitters[row] = append(splitters[row], col)
			}
		}
		if row > max_y {
			max_y = row
		}
	}

	if debug {
		fmt.Println("Start", start, "Splitters", splitters)
	}

	beams := map[int]int{start.X: 1}
	keys := slices.SortedStableFunc(maps.Keys(splitters), func(a int, b int) int {
		return a - b
	})
	for _, row := range keys {
		splits := splitters[row]
		for beam, count := range beams {
			if slices.Contains(splits, beam) {
				delete(beams, beam)
				beams[beam-1] += count
				beams[beam+1] += count
			}
		}
		if debug {
			fmt.Println("Key", row, "Beams:", beams)
		}
	}

	if debug {
		fmt.Println("Beams:", beams)
	}

	for _, beam := range beams {
		total += beam
	}

	if debug {
		fmt.Printf("Total: %v \n", total)
	}
	return total
}

func Solve() {
	reader := input.InputDay(7)

	lines := input.AsLinesIndexed(reader)

	reader2 := input.InputDay(7)
	lines2 := input.AsLinesIndexed(reader2)

	println("=== Day 7 ===")
	start := time.Now()
	prev := start
	fmt.Printf("Part1: %v \n", part1(lines, false))
	fmt.Printf("=== %v ===\n", time.Since(prev))
	prev = time.Now()
	fmt.Printf("Part2: %v \n", part2(lines2, false))
	fmt.Printf("=== %v ===\n", time.Since(prev))
	prev = time.Now()
	fmt.Printf("Sub-Total: %v\n", time.Since(start))
}
