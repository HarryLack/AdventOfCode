package day6

import (
	"aoc-2025/input"
	"strings"
	"testing"
)

func TestPart1(t *testing.T) {
	test_input := `123 328  51 64
 45 64  387 23
  6 98  215 314
*   +   *   + `

	test_reader := strings.NewReader(test_input)

	want := 4277556

	result := part1(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestPart2(t *testing.T) {
	test_stuff := []string{
		"123 328  51 64 ",
		" 45 64  387 23 ",
		"  6 98  215 314",
		"*   +   *   +  ",
	}

	test_reader := strings.NewReader(strings.Join(test_stuff, "\n"))

	want := 3263827

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
