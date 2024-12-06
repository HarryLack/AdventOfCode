package input

import (
	"bufio"
	"io"
	"iter"
	"os"
	"strconv"
	"strings"
)

func InputDay(day int) io.Reader {
	data, err := os.Open("../inputs/day" + strconv.Itoa(day) + ".txt")
	if err != nil {
		panic(err)
	}

	return data
}

// https://github.com/nlowe/aoc2023/blob/master/challenge/input.go
func AsLines(r io.Reader) iter.Seq[string] {
	scanner := bufio.NewScanner(r)

	return func(yield func(string) bool) {
		for scanner.Scan() {
			if err := scanner.Err(); err != nil && err != io.EOF {
				panic(err)
			}

			if !yield(scanner.Text()) {
				return
			}
		}
	}
}

// https://github.com/nlowe/aoc2023/blob/master/challenge/input.go
func AsSections(r io.Reader) iter.Seq[string] {
	scanner := bufio.NewScanner(r)
	var section strings.Builder

	return func(yield func(string) bool) {
		for scanner.Scan() {
			if err := scanner.Err(); err != nil && err != io.EOF {
				panic(err)
			}

			line := scanner.Text()
			section.WriteString(line)

			if line == "" {
				if !yield(strings.TrimSpace(section.String())) {
					return
				}
				section.Reset()
			} else {
				section.WriteRune('\n')
			}
		}

		if section.Len() != 0 {
			yield(section.String())
		}
	}
}
