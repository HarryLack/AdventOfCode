package day7

import (
	"strings"
	"testing"
)

func TestDay1(t *testing.T) {
	test_input := `190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20`

	test_reader := strings.NewReader(test_input)

	want := 3749

	result := part1(test_reader, true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestDay2(t *testing.T) {
	test_input := `190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20`

	test_reader := strings.NewReader(test_input)

	want := 11387

	result := part2(test_reader, true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
