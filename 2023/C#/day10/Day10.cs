using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;
using System.ComponentModel;
using Coord = (int x, int y);
using Directions = (bool North, bool South, bool East, bool West);

static partial class Day10
{
    enum Direction
    {
        North, South, East, West
    }

    readonly static Dictionary<char, Directions> pipes = new()
    {
        ['|'] = (true, true, false, false),
        ['-'] = (false, false, true, true),
        ['L'] = (true, false, true, false),
        ['J'] = (true, false, false, true),
        ['7'] = (false, true, false, true),
        ['F'] = (false, true, true, false),
        ['.'] = (false, false, false, false),
        ['S'] = (true, true, true, true)
    };

    readonly static (Direction dir, int x, int y)[] neighbourOffsets = [
        (Direction.West, -1, 0),
        (Direction.East, 1, 0),
        (Direction.South, 0, 1),
        (Direction.North, 0, -1),
    ];

    static bool ValidateConnection(Direction dir, char current, char target)
    {
        var currentPipe = pipes[current];
        var targetPipe = pipes[target];

        switch (dir)
        {
            case Direction.North:
                if (!currentPipe.North)
                {
                    return false;
                }
                break;
            case Direction.South:
                if (!currentPipe.South)
                {
                    return false;
                }
                break;
            case Direction.East:
                if (!currentPipe.East)
                {
                    return false;
                }
                break;
            case Direction.West:
                if (!currentPipe.West)
                {
                    return false;
                }
                break;
        }

        return dir switch
        {
            Direction.North => targetPipe.South,
            Direction.South => targetPipe.North,
            Direction.East => targetPipe.West,
            Direction.West => targetPipe.East,
            _ => false,
        };
    }

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
            if (currentVal == 0 || done.Contains(current))
            {
                continue;
            }

            foreach (var (dir, x, y) in neighbourOffsets)
            {
                int nX = current.x + x;
                int nY = current.y + y;

                if (nY >= 0 && nY < input.Length)
                {
                    if (nX >= 0 && nX < input[nY]?.Length)
                    {
                        var target = input[nY][nX];


                        Coord neighbourCoord = (x: nX, y: nY);

                        bool isValid = ValidateConnection(dir, currentVal, target);

                        // Console.WriteLine();
                        // Console.Write(currentVal); Console.WriteLine(current);
                        // Console.Write(target); Console.WriteLine(neighbourCoord);
                        // Console.WriteLine();
                        // Console.WriteLine();

                        if (!isValid)
                        {
                            continue;
                        }

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

    static Coord FindStart(char[][] input)
    {
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == 'S')
                {
                    return (x: j, y: i);
                }
            }
        }

        throw new Exception("No start point found");
    }

    readonly static string[] arrayedTestInput = [
        "..F7.",
        ".FJ|.",
        "SJ.L7",
        "|F--J",
        "LJ..."
    ];

    public static int Part1(string[] input)
    {
        char[][] map = Helpers.StringArrayToCharArrayArray(input);
        Coord start = FindStart(map);

        Dictionary<Coord, int> filled = FloodFill(start, map);

        return filled.Values.Max();
    }
    public static int Part2(string[] input)
    {
        int count = 0;

        return count;
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 10!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\Day10.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(Day10Tests.Tests.arrayedTestInput));
    }

}
