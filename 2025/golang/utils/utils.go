package utils

type Range struct {
	Start int
	End   int
}

type Coord struct {
	X int
	Y int
}

var Neighbours = [8]Coord{
	{-1, -1}, {0, -1}, {1, -1},
	{-1, 0} /*{0,0},*/, {1, 0},
	{-1, 1}, {0, 1}, {1, 1},
}

func Abs(num int) int {
	if num < 0 {
		return -num
	}
	return num
}

// https://go.dev/blog/slices-intro
func AppendByte(slice []byte, data ...byte) []byte {
	m := len(slice)
	n := m + len(data)
	if n > cap(slice) { // if necessary, reallocate
		// allocate double what's needed, for future growth.
		newSlice := make([]byte, (n+1)*2)
		copy(newSlice, slice)
		slice = newSlice
	}
	slice = slice[0:n]
	copy(slice[m:n], data)
	return slice
}

func ChunkByValue[S ~[]E, E comparable](s S, v E) []S {
	ret := []S{}
	cur := S{}
	for _, val := range s {
		if val == v {
			ret = append(ret, cur)
			cur = S{}
		} else {
			cur = append(cur, val)
		}
	}
	if len(cur) > 0 {
		ret = append(ret, cur)
	}
	return ret
}
