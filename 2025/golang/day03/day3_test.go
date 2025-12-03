package day3

import (
	"aoc-2025/input"
	"strings"
	"testing"
)

func TestPart1(t *testing.T) {
	test_input := `987654321111111
811111111111119
234234234234278
818181911112111`

	test_reader := strings.NewReader(test_input)

	want := 357

	result := part1(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestPart2(t *testing.T) {
	test_input := `987654321111111
811111111111119
234234234234278
818181911112111`

	test_reader := strings.NewReader(test_input)

	want := 3121910778619

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
func TestPart2a(t *testing.T) {
	test_input := `987654321111111`

	test_reader := strings.NewReader(test_input)

	want := 987654321111

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2a = %v, want = %v`, result, want)
	}
}
func TestPart2b(t *testing.T) {
	test_input := `811111111111119`

	test_reader := strings.NewReader(test_input)

	want := 811111111119

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2b = %v, want = %v`, result, want)
	}
}
func TestPart2c(t *testing.T) {
	test_input := `234234234234278`

	test_reader := strings.NewReader(test_input)

	want := 434234234278

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2c = %v, want = %v`, result, want)
	}
}
func TestPart2d(t *testing.T) {
	test_input := `818181911112111`

	test_reader := strings.NewReader(test_input)

	want := 888911112111

	result := part2(input.AsLines(test_reader), true)

	if result != want {
		t.Fatalf(`part2d = %v, want = %v`, result, want)
	}
}
