using System.Text.RegularExpressions;

readonly struct Scratchcard
{
    public readonly int Id;
    public readonly int[] WinningNumbers;
    public readonly int[] Numbers;
    public readonly int Value;

    public Scratchcard(int Id, int[] WinningNumbers, int[] Numbers)
    {
        this.Id = Id;
        this.WinningNumbers = WinningNumbers;
        this.Numbers = Numbers;
        this.Value = this.Calc();
    }

    int Calc()
    {
        int score = this.Numbers.Intersect(this.WinningNumbers).ToArray().Length;

        switch (score)
        {
            case 0:
            case 1:
                return score;
            default:
                return (int)Math.Pow(2, (score - 1));
        }
    }
}

static partial class Day4
{
    [GeneratedRegex("[0-9]+")]
    private static partial Regex NumberMatcher();

    public static Scratchcard[] ExtractCards(string[] input)
    {
        List<Scratchcard> cards = [];
        Regex numberMatcher = NumberMatcher();
        foreach (string line in input)
        {
            var split1 = line.Split(':');
            var id = int.Parse(numberMatcher.Match(split1[0]).Value);
            var split2 = split1[1].Split("|");
            var winningNumbers = numberMatcher.Matches(split2[0]).ToArray();
            var numbers = numberMatcher.Matches(split2[1]).ToArray();
            Scratchcard card = new(id, Array.ConvertAll(winningNumbers, n => int.Parse(n.Value)), Array.ConvertAll(numbers, n => int.Parse(n.Value)));
            cards.Add(card);
        }

        return [.. cards];
    }

    public static int Part1(string[] input)
    {
        Scratchcard[] cards = ExtractCards(input);
        return cards.Sum(card => card.Value);
    }

    public static int Part2(string[] input)
    {
        return 0;
    }


    readonly static string[] arrayedTestInput = [
    "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
        "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
        "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
];

    public static void Answer()
    {
        Console.WriteLine("Hello, Day 4!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\day4.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        //Console.WriteLine("My Part 2 result is " + Part2(input));
    }


}