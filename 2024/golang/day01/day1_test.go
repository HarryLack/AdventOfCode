package day1

import (
	"aoc-2024/input"
	"strings"
	"testing"
)

func TestDay1(t *testing.T) {
	test_input := `3   4
4   3
2   5
1   3
3   9
3   3`

	test_reader := strings.NewReader(test_input)

	want := 11

	result := part1(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestDay2(t *testing.T) {
	test_input := `3   4
4   3
2   5
1   3
3   9
3   3`

	test_reader := strings.NewReader(test_input)

	want := 31

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}