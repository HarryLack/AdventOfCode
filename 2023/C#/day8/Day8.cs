using System.Diagnostics;
using CamelMap = System.Collections.Generic.Dictionary<string, (string L, string R)>;

static partial class Day8
{
    readonly static string[] arrayedTestInput = [
        "RL",
        "",
        "AAA = (BBB, CCC)",
        "BBB = (DDD, EEE)",
        "CCC = (ZZZ, GGG)",
        "DDD = (DDD, DDD)",
        "EEE = (EEE, EEE)",
        "GGG = (GGG, GGG)",
        "ZZZ = (ZZZ, ZZZ)"
    ];
    readonly static string[] arrayedTestInputPart2 = [
        "LR",
        "",
        "11A = (11B, XXX)",
        "11B = (XXX, 11Z)",
        "11Z = (11B, XXX)",
        "22A = (22B, XXX)",
        "22B = (22C, 22C)",
        "22C = (22Z, 22Z)",
        "22Z = (22B, 22B)",
        "XXX = (XXX, XXX)"
    ];

    static CamelMap ParseNodes(string[] input)
    {
        CamelMap map = [];

        foreach (string line in input)
        {
            string key = line.Split("=", StringSplitOptions.TrimEntries)[0];
            string[] destinations = line.Split("=", StringSplitOptions.TrimEntries)[1].Replace("(", "").Replace(")", "").Split(",", StringSplitOptions.TrimEntries);
            map.Add(key, (L: destinations[0], R: destinations[1]));
        }

        return map;
    }
    static string DoStep(char instruction, CamelMap map, string current)
    {
        if (instruction == 'L')
        {
            return map[current].L;
        }
        else
        {
            return map[current].R;
        }
    }

    public static int Part1(string[] input)
    {
        int count = 0;
        char[] instructions = [.. input[0].Trim()];
        int len = instructions.Length;
        var map = ParseNodes(input.Skip(2).ToArray());
        string start = "AAA";
        string current = start;
        string end = "ZZZ";

        while (current != end)
        {
            char instruction = instructions[count % len];
            current = DoStep(instruction, map, current);
            count++;
        }
        return count;
    }

    static string[] FindStarts(string[] nodes)
    {
        List<string> starts = [];

        foreach (var node in nodes)
        {
            if (node.EndsWith('A'))
            {
                starts.Add(node);
            }
        }

        return [.. starts];
    }

    static (int entry, int loopSize) FindLoop(char[] instructions, CamelMap map, string startNode)
    {
        int count = 0;
        int? entry = null;
        int loop = 0;
        int len = instructions.Length;
        string current = startNode;
        bool done = false;
        string? end = null;

        while (!done)
        {
            char instruction = instructions[count % len];
            current = DoStep(instruction, map, current);
            count++;

            if (entry != null)
            {
                loop++;
                if (current == end)
                {
                    done = true;
                }
            }

            if (current.EndsWith('Z'))
            {
                entry ??= count;
                end ??= current;
            }
        }

        if (entry == null || end == null)
        {
            throw new Exception("Error finding loop");
        }

        return ((int)entry, loopSize: loop);
    }

    public static ulong Part2(string[] input)
    {
        ulong count = 0;
        char[] instructions = [.. input[0].Trim()];
        int len = instructions.Length;
        var map = ParseNodes(input.Skip(2).ToArray());
        string[] nodes = FindStarts([.. map.Keys]);

        List<(int entry, int loopSize)> loops = [];

        foreach (var node in nodes)
        {
            loops.Add(FindLoop(instructions, map, node));
        }

        count = Helpers.LCM(loops.Select(loop => (ulong)loop.loopSize).ToArray());
        return count;
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 8!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\Day8.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}