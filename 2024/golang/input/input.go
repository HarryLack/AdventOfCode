package input

import (
	"bufio"
	"io"
	"iter"
	"os"
	"strconv"
)

func InputDay(day int) io.Reader {
	data, err := os.Open("../inputs/day" + strconv.Itoa(day) + ".txt")
	if err != nil {
		panic(err)
	}

	return data
}

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
