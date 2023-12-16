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

    static Dictionary<string, (string L, string R)> ParseNodes(string[] input)
    {
        Dictionary<string, (string L, string R)> map = [];

        foreach (string line in input)
        {
            string key = line.Split("=", StringSplitOptions.TrimEntries)[0];
            string[] destinations = line.Split("=", StringSplitOptions.TrimEntries)[1].Replace("(", "").Replace(")", "").Split(",", StringSplitOptions.TrimEntries);
            map.Add(key, (L: destinations[0], R: destinations[1]));
        }

        return map;
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
            if (instruction == 'L')
            {
                current = map[current].L;
            }
            else
            {
                current = map[current].R;
            }

            count++;
        }

        return count;
    }

    public static int Part2(string[] input)
    {
        int? count = null;

        return count ?? 0;
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 8!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\Day8.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}