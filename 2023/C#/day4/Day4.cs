using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

struct Scratchcard
{
    public readonly int Id;
    public readonly int[] WinningNumbers;
    public readonly int[] Numbers;
    public readonly int Matches;
    public readonly int Score;
    public int Copies { get; set; } = 1;
    public Scratchcard(int Id, int[] WinningNumbers, int[] Numbers)
    {
        this.Id = Id;
        this.WinningNumbers = WinningNumbers;
        this.Numbers = Numbers;
        this.Matches = Numbers.Intersect(WinningNumbers).ToArray().Length;
        this.Score = this.Matches switch
        {
            0 => this.Matches,
            _ => (int)Math.Pow(2, (this.Matches - 1)),
        };
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
        return cards.Sum(card => card.Score);
    }

    public static int Part2(string[] input)
    {
        Scratchcard[] cards = ExtractCards(input);

        foreach (var card in cards)
        {
            if (card.Matches > 0)
            {
                for (int i = 1; i <= card.Matches; i++)
                {
                    cards[card.Id - 1 + i].Copies += card.Copies;
                }
            }
        }

        return cards.Sum(card => card.Copies);
    }

    public static void Answer()
    {
        Console.WriteLine("Hello, Day 4!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\day4.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}