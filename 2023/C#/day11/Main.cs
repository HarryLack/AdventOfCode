using Coord = (int x, int y);
using SpaceThing = (char c, long w, long h);

namespace AoC.day11
{
    static partial class Main
    {
        public static string[] ExpandInput(string[] input)
        {
            //Find colToExpand to expand
            List<int> colToExpand = [];
            for (int i = 0; i < input.Length; i++)
            {
                bool hasGalaxy = input.Any((line) => line[i] == '#');
                if (!hasGalaxy)
                {
                    colToExpand.Add(i);
                }
            }

            //
            List<string> lines = [];
            foreach (var lineIn in input)
            {
                string lineOut = "";

                foreach (var (c, i) in lineIn.Select((c, i) => (c, i)))
                {
                    if (colToExpand.Contains(i))
                    {
                        lineOut += c;
                    }
                    lineOut += c;
                }


                lines.Add(lineOut);
                //do stuff
                if (!lineIn.Contains('#'))
                {
                    lines.Add(lineOut);
                }
            }

            int galaxyCount = 1;
            foreach (var line in lines)
            {
                foreach (var c in line)
                {

                }
            }

            return [.. lines];
        }

        public static SpaceThing[][] ExpandInput2(string[] input, int expandRatio)
        {
            //Find colToExpand to expand
            List<int> colToExpand = [];
            for (int i = 0; i < input.Length; i++)
            {
                bool hasGalaxy = input.Any((line) => line[i] == '#');
                if (!hasGalaxy)
                {
                    colToExpand.Add(i);
                }
            }

            //
            List<SpaceThing[]> lines = [];
            foreach (var lineIn in input)
            {
                List<SpaceThing> lineOut = [];

                foreach (var (c, i) in lineIn.Select((c, i) => (c, i)))
                {
                    if (colToExpand.Contains(i))
                    {
                        lineOut.Add((c, expandRatio, 1));
                    }
                    else
                    {
                        lineOut.Add((c, 1, 1));
                    }

                }



                //do stuff
                if (!lineIn.Contains('#'))
                {
                    SpaceThing[] transformed = lineOut.Select(line =>
                    {
                        var result = line;
                        result.h = expandRatio;
                        return result;
                    }).ToArray();
                    lines.Add(transformed);
                }
                else
                {
                    lines.Add([.. lineOut]);
                }
            }

            return [.. lines];
        }

        static Dictionary<int, Coord> ExtractGalaxies(string[] input)
        {
            Dictionary<int, Coord> galaxies = [];

            foreach (var (line, y) in input.Select((l, i) => (l, i)))
            {
                foreach (var (c, x) in line.Select((c, i) => (c, i)))
                {
                    if (c == '#')
                    {
                        galaxies.Add(galaxies.Count + 1, new Coord(x, y));
                    }
                }
            }

            return galaxies;
        }
        readonly static (int x, int y)[] neighbourOffsets = [
            (-1, 0),
            (1, 0),
            (0, 1),
            (0, -1),
        ];
        static Dictionary<Coord, int> FloodFill(Coord start, char[][] input)
        {
            List<Coord> working = [start];
            HashSet<Coord> done = [];

            Dictionary<Coord, int> distances = [];

            distances[start] = 0;

            while (working.Count > 0)
            {
                var current = working[0];
                int currentDistance = distances[current];
                working.Remove(current);
                var currentVal = input[current.y][current.x];
                if (done.Contains(current))
                {
                    continue;
                }

                foreach (var (x, y) in neighbourOffsets)
                {
                    int nX = current.x + x;
                    int nY = current.y + y;

                    if (nY >= 0 && nY < input.Length)
                    {
                        if (nX >= 0 && nX < input[nY]?.Length)
                        {
                            var target = input[nY][nX];

                            Coord neighbourCoord = (x: nX, y: nY);

                            working.Add(neighbourCoord);

                            if (distances.TryGetValue(neighbourCoord, out int val))
                            {
                                bool isCloser = val > currentDistance;

                                if (isCloser)
                                {
                                    distances[neighbourCoord] = currentDistance + 1;
                                }
                            }
                            else
                            {
                                distances[neighbourCoord] = currentDistance + 1;
                            }
                        }
                    }
                }

                done.Add(current);
            }

            return distances;
        }

        static Dictionary<Coord, long> FloodFill2(Coord start, SpaceThing[][] input)
        {
            List<Coord> working = [start];
            HashSet<Coord> done = [];

            Dictionary<Coord, long> distances = [];

            distances[start] = 0;

            while (working.Count > 0)
            {
                var current = working[0];
                long currentDistance = distances[current];
                working.Remove(current);
                var currentVal = input[current.y][current.x];
                if (done.Contains(current))
                {
                    continue;
                }

                foreach (var (x, y) in neighbourOffsets)
                {
                    int nX = current.x + x;
                    int nY = current.y + y;

                    if (nY >= 0 && nY < input.Length)
                    {
                        if (nX >= 0 && nX < input[nY]?.Length)
                        {
                            var target = input[nY][nX];

                            Coord neighbourCoord = (x: nX, y: nY);

                            working.Add(neighbourCoord);

                            if (distances.TryGetValue(neighbourCoord, out long val))
                            {
                                bool isCloser = val > currentDistance;

                                if (isCloser)
                                {
                                    distances[neighbourCoord] = currentDistance + (target.w * target.h);
                                }
                            }
                            else
                            {
                                distances[neighbourCoord] = currentDistance + (target.w * target.h);
                            }
                        }
                    }
                }

                done.Add(current);
            }

            return distances;
        }


        static int FindPairs((int, Coord) start, Dictionary<int, Coord> input, string[] universe)
        {
            //Get unchecked galaxies as targets
            var targets = input.Where((g) => g.Key > start.Item1);
            int count = 0;

            // Find length of paths
            var filled = FloodFill(start.Item2, Utils.Cast.StringArrayToCharArrayArray(universe));
            foreach (var (i, v) in targets)
            {
                count += filled[v];
            }

            return count;
        }

        static long FindPairs2((int, Coord) start, Dictionary<int, Coord> input, SpaceThing[][] universe)
        {
            //Get unchecked galaxies as targets
            var targets = input.Where((g) => g.Key > start.Item1);
            long count = 0;

            // Find length of paths
            var filled = FloodFill2(start.Item2, universe);
            foreach (var (i, v) in targets)
            {
                count += filled[v];
            }

            return count;
        }

        public static int Part1(string[] input)
        {
            int count = 0;
            var universe = ExpandInput(input);
            var galaxies = ExtractGalaxies(universe);


            foreach (var (i, v) in galaxies)
            {
                count += FindPairs((i, v), galaxies, universe);
            }

            return count;
        }
        public static long Part2(string[] input, int ratio)
        {
            long count = 0;
            var universe = ExpandInput2(input, ratio);
            var galaxies = ExtractGalaxies(input);


            foreach (var (i, v) in galaxies)
            {
                count += FindPairs2((i, v), galaxies, universe);
            }

            return count;
        }
        public static void Answer()
        {
            Console.WriteLine("Hello, Day 11!");
            string[] input = Utils.File.ReadAsArray(@"..\..\..\..\inputs\day11.txt");
            Console.WriteLine("My Part 1 result is " + Part1(input));
            Console.WriteLine("My Part 2 result is " + Part2(input, 1_000_000));
        }

    }
}