using RangeMaps = System.Collections.Generic.Dictionary<string, Range[]>;
readonly struct Range(uint Start, uint Source, uint Length)
{
    private readonly uint Start = Start;
    private readonly uint Source = Source;
    private readonly uint Length = Length;

    public uint MapValue(uint value)
    {
        if (!InRange(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        uint diff = value - this.Source;

        return this.Start + diff;
    }

    public bool InRange(uint value)
    {
        return (value >= this.Source) && (value < this.Source + this.Length);
    }
}

static partial class Day5
{
    static uint[] ExtractSeeds(string input)
    {
        string seeds = input.Split(":")[1];
        return Array.ConvertAll(seeds.Trim().Split(" "), uint.Parse);
    }
    static Tuple<string, Range[]> ConvertToMap(List<string> input)
    {
        List<Range> ranges = [];

        foreach (string s in input.Skip(1))
        {
            var elms = Array.ConvertAll(s.Split(" "), uint.Parse);
            ranges.Add(new(elms[0], elms[1], elms[2]));
        }

        return new(input[0], [.. ranges]);
    }
    public static RangeMaps ExtractMaps(IEnumerable<string> input)
    {
        RangeMaps maps = [];

        List<string> working = [];

        foreach (var line in input)
        {
            if (line != "")
            {
                working.Add(line);
            }
            else if (working.Count > 0)
            {
                var map = ConvertToMap(working);
                maps.Add(map.Item1, map.Item2);
                working = [];
            }
        }

        if (working.Count > 0)
        {
            var map = ConvertToMap(working);
            maps.Add(map.Item1, map.Item2);
        }

        return maps;
    }
    static uint ApplyMapToValue(uint value, Range[] map)
    {
        foreach (var range in map)
        {
            if (range.InRange(value))
            {
                var temp = range.MapValue(value);
                return temp;
            }
        }
        return value;
    }
    static uint MapSeed(uint seed, RangeMaps maps)
    {
        uint calc = seed;
        foreach (var map in maps)
        {
            calc = ApplyMapToValue(calc, map.Value);
        }
        return calc;
    }
    public static uint Part1(string[] input)
    {
        uint count = uint.MaxValue;
        uint[] seeds = ExtractSeeds(input[0]);
        RangeMaps maps = ExtractMaps(input.Skip(1));

        foreach (var seed in seeds)
        {
            uint res = MapSeed(seed, maps);
            if (res < count)
            {
                count = res;
            }
        }

        return count;
    }
    public static int Part2(string[] input)
    {
        return 0;
    }

    readonly static string[] arrayedTestInput = [
        "seeds: 79 14 55 13",
        "",
        "seed-to-soil map:",
        "50 98 2",
        "52 50 48",
        "",
        "soil-to-fertilizer map:",
        "0 15 37",
        "37 52 2",
        "39 0 15",
        "",
        "fertilizer-to-water map:",
        "49 53 8",
        "0 11 42",
        "42 0 7",
        "57 7 4",
        "",
        "water-to-light map:",
        "88 18 7",
        "18 25 70",
        "",
        "light-to-temperature map:",
        "45 77 23",
        "81 45 19",
        "68 64 13",
        "",
        "temperature-to-humidity map:",
        "0 69 1",
        "1 0 69",
        "",
        "humidity-to-location map:",
        "60 56 37",
        "56 93 4"
    ];

    public static void Answer()
    {
        Console.WriteLine("Hello, Day 5!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\day5.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(arrayedTestInput));
    }

}