package day6

import (
	"strings"
	"testing"
)

func TestDay1(t *testing.T) {
	test_input := `....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...`

	test_reader := strings.NewReader(test_input)

	want := 41

	result := part1(test_reader, true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestDay2(t *testing.T) {
	test_input := `....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...`

	test_reader := strings.NewReader(test_input)

	want := 6

	result := part2(test_reader, true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
