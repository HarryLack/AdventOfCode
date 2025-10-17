package day9

import (
	"strings"
	"testing"
)

func TestDay1(t *testing.T) {
	test_input := `2333133121414131402`

	test_reader := strings.NewReader(test_input)

	want := 1928

	result := part1(test_reader, true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}
func TestDay1a(t *testing.T) {
	test_input := `12345`

	test_reader := strings.NewReader(test_input)

	want := 60

	result := part1(test_reader, true)

	if result != want {
		t.Fatalf(`part1 = %v, want = %v`, result, want)
	}
}

func TestDay2(t *testing.T) {
	test_input := `2333133121414131402`

	test_reader := strings.NewReader(test_input)

	want := 2854

	result := part2(test_reader, true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
func TestDay2a(t *testing.T) {
	test_input := ``

	test_reader := strings.NewReader(test_input)

	want := 9

	result := part2(test_reader, true)

	if result != want {
		t.Fatalf(`part2 = %v, want = %v`, result, want)
	}
}
