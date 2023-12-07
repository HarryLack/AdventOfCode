using System;
using System.Diagnostics.SymbolStore;

struct PartNumber
{
    public List<Tuple<int, int>> Indices { get; set; } = [];
    public int PartID { get; set; }

    public PartNumber()
    {
    }
}

static partial class Day3
{

    readonly static string[] arrayedInput = [
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598.."
    ];

    static bool IsDigit(string input)
    {
        int _;
        return int.TryParse(input, out _);
    }

    static bool IsSpecialChar(char input)
    {
        return input != '.' && !IsDigit(input.ToString());
    }

    public static PartNumber[] FindPartNumbers(string[] input)
    {
        List<PartNumber> result = [];
        PartNumber? res = null;
        string currentNum = "";

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                char ch = input[i][j];
                if (IsDigit(ch.ToString()))
                {
                    res ??= new();
                    res?.Indices.Add(new Tuple<int, int>(i, j));
                    currentNum += ch;
                }
                else
                {
                    if (res is PartNumber part && currentNum != "")
                    {
                        part.PartID = int.Parse(currentNum);
                        result.Add(part);

                        currentNum = "";
                        res = null;
                    }
                }
            }

            // Local variable scoping is kinda weird
            if (res is PartNumber endPart && currentNum != "")
            {
                endPart.PartID = int.Parse(currentNum);
                result.Add(endPart);

                currentNum = "";
                res = null;
            }
        }
        return [.. result];
    }

    public static Tuple<int, int>[] FindSymbols(string[] input)
    {
        List<Tuple<int, int>> result = [];

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                char ch = input[i][j];
                if (IsSpecialChar(ch))
                {
                    Tuple<int, int> res = new(i, j);
                    result.Add(res);
                }
            }
        }

        return result.ToArray();
    }

    public static Tuple<int, int>[] OffsetSymbol(Tuple<int, int> input)
    {
        List<Tuple<int, int>> indices = [];

        int item1 = input.Item1;
        int item2 = input.Item2;

        indices.Add(new(item1 - 1, item2 - 1));
        indices.Add(new(item1 - 1, item2));
        indices.Add(new(item1 - 1, item2 + 1));
        indices.Add(new(item1, item2 - 1));
        indices.Add(new(item1, item2 + 1));
        indices.Add(new(item1 + 1, item2 - 1));
        indices.Add(new(item1 + 1, item2));
        indices.Add(new(item1 + 1, item2 + 1));

        return [.. indices];
    }

    public static bool CheckNeighbour(Tuple<int, int> index, Tuple<int, int> symbol)
    {
        var symbols = OffsetSymbol(symbol);
        foreach (var sym in symbols)
        {
            if (index.Equals(sym))
            {
                return true;
            }
        }

        return false;
    }

    public static bool ValidatePart(PartNumber part, Tuple<int, int> symbol)
    {
        bool validated = false;
        foreach (var index in part.Indices)
        {
            if (!validated)
            {
                validated = CheckNeighbour(index, symbol);
            };
        }

        return validated;
    }

    public static PartNumber[] FindValidParts(PartNumber[] parts, Tuple<int, int>[] symbols)
    {
        List<PartNumber> validParts = [];

        foreach (PartNumber part in parts)
        {
            bool validated = false;
            foreach (Tuple<int, int> symbol in symbols)
            {
                if (!validated && ValidatePart(part, symbol))
                {
                    validParts.Add(part);
                    validated = true;
                }
            }
        }

        return [.. validParts];

    }

    public static int Part1(string[] input)
    {
        int count = 0;
        var symbols = FindSymbols(input);
        var parts = FindPartNumbers(input);
        var valids = FindValidParts(parts, symbols);
        foreach (var item in valids)
        {
            count += item.PartID;
            if(item.PartID == 640534)
            {
                Console.WriteLine("uh oh");
            }
        }
        return count;
    }

    public static void Answer()
    {
        Console.WriteLine("Hello, Day 3!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\day3.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
    }

}