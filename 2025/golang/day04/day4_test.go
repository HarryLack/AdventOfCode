package day4

import (
	"aoc-2025/input"
	"strings"
	"testing"
)

func TestPart1(t *testing.T) {
	test_input := `..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.`

	test_reader := strings.NewReader(test_input)

	want := 13

	result := part1(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}
func TestPart2(t *testing.T) {
	test_input := `..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.`

	test_reader := strings.NewReader(test_input)

	want := 43

	result := part2(input.AsLinesIndexed(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}
