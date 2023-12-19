using Microsoft.VisualStudio.TestPlatform.Utilities;
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

static partial class Day05
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

    public static Tuple<uint, uint>[] ExtractSeedRanges(uint[] seeds)
    {
        List<Tuple<uint, uint>> pairs = [];

        uint? start = null;
        uint? range = null;

        foreach (var val in seeds)
        {
            if (start == null)
            {
                start = val;
            }
            else if (range == null)
            {
                range = val;
            }

            if (start != null && range != null)
            {
                pairs.Add(new((uint)start, (uint)range));
                start = null;
                range = null;
            }
        }

        return [.. pairs];
    }
    static uint ProcessPair(Tuple<uint, uint> pair, RangeMaps maps)
    {
        uint count = uint.MaxValue;
        for (uint i = pair.Item1; i < pair.Item1 + pair.Item2; i++)
        {
            uint res = MapSeed(i, maps);
            if (res < count)
            {
                count = res;
            }
        }
        return count;
    }

    public static uint Part2(string[] input)
    {

        uint count = uint.MaxValue;
        uint[] seeds = ExtractSeeds(input[0]);
        RangeMaps maps = ExtractMaps(input.Skip(1));
        var pairs = ExtractSeedRanges(seeds);

        int prog = 0;

        foreach (var pair in pairs)
        {
            Console.WriteLine($"{prog}/{pairs.Length}");
            uint res = ProcessPair(pair, maps);
            if (res < count)
            {
                count = res;
            }
            prog++;

        }

        return count;
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 5!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\day5.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}