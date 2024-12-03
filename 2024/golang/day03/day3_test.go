package day3

import (
	"aoc-2024/input"
	"strings"
	"testing"
)

func TestDay1(t *testing.T) {
	test_input := `xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))`

	test_reader := strings.NewReader(test_input)

	want := 161

	result := part1(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestDay2(t *testing.T) {
	test_input := `xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))`

	test_reader := strings.NewReader(test_input)

	want := 48

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
