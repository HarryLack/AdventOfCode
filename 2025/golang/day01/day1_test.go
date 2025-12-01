package day1

import (
	"aoc-2025/input"
	"strings"
	"testing"
)

func TestDay1(t *testing.T) {
	test_input := `L68
L30
R48
L5
R60
L55
L1
L99
R14
L82`

	test_reader := strings.NewReader(test_input)

	want := 3

	result := part1(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestDay2(t *testing.T) {
	test_input := `L68
L30
R48
L5
R60
L55
L1
L99
R14
L82`

	test_reader := strings.NewReader(test_input)

	want := 6

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
