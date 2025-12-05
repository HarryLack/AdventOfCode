package day5

import (
	"aoc-2025/input"
	"strings"
	"testing"
)

func TestPart1(t *testing.T) {
	test_input := `3-5
10-14
16-20
12-18

1
5
8
11
17
32`

	test_reader := strings.NewReader(test_input)

	want := 3

	result := part1(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestPart2(t *testing.T) {
	test_input := `3-5
10-14
16-20
12-18

1
5
8
11
17
32`

	test_reader := strings.NewReader(test_input)

	want := 14

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
