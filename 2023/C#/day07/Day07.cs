using CamelGame = (string hand, int bid);

enum CamelCard
{
    T = 10, J = 11, Q = 12, K = 13, A = 14
}
enum JokerCard
{
    T = 10, J = 1, Q = 12, K = 13, A = 14
}
enum HandType
{
    HighCard, Pair, TwoPair, ThreeKind, FullHouse, FourKind, FiveKind
}

static partial class Day07
{
    static CamelGame[] ExtractGames(string[] input)
    {
        List<CamelGame> games = [];
        foreach (string line in input)
        {
            string[] game = line.Split(" ");
            games.Add(new(game[0], int.Parse(game[1])));
        }

        return [.. games];
    }

    static bool IsHighCard(string input)
    {
        return input.Distinct().SequenceEqual(input);
    }

    static int FindPairs(string input)
    {
        var pairs = input.GroupBy(c => c);
        int count = 0;
        foreach (var pair in pairs)
        {
            if (pair.ToArray().Length == 2)
            {
                count++;
            }
        }

        return count;
    }

    static bool IsThreeKind(string input)
    {
        return input.Any(c => input.AsSpan().Count(c) == 3);
    }

    static bool IsFullHouse(string input)
    {
        return !IsHighCard(input) && FindPairs(input) == 1 && IsThreeKind(input) && !IsFourKind(input) && !IsFiveKind(input);
    }

    static bool IsFourKind(string input)
    {
        return input.Any(c => input.AsSpan().Count(c) == 4);
    }

    static bool IsFiveKind(string input)
    {
        return input.All(c => c == input[0]);
    }

    static HandType RateHand(string hand)
    {
        if (IsFiveKind(hand))
        {
            return HandType.FiveKind;
        }

        if (IsFourKind(hand))
        {
            return HandType.FourKind;
        }

        if (IsFullHouse(hand))
        {
            return HandType.FullHouse;
        }

        if (IsThreeKind(hand))
        {
            return HandType.ThreeKind;
        }

        switch (FindPairs(hand))
        {
            case 1:
                return HandType.Pair;
            case 2:
                return HandType.TwoPair;
            default:
                break;
        }

        if (IsHighCard(hand))
        {
            return HandType.HighCard;
        }

        throw new Exception("Invalid hand");
    }

    static HandType RateJokerHand(string hand)
    {
        int jokerCount = hand.Where(c => c == 'J').ToArray().Length;
        HandType type = RateHand(hand);
        if (type == HandType.FiveKind || jokerCount == 0 || jokerCount == 5)
        {
            return type;
        }

        string baseHand = hand.Replace("J", "");
        HandType baseType = RateHand(baseHand);

        return baseType switch
        {
            HandType.HighCard => jokerCount switch
            {
                1 => HandType.Pair,
                2 => HandType.ThreeKind,
                3 => HandType.FourKind,
                4 => HandType.FiveKind,
                _ => throw new Exception("Invalid hand")
            }
            ,
            HandType.Pair => jokerCount switch
            {
                1 => HandType.ThreeKind,
                2 => HandType.FourKind,
                3 => HandType.FiveKind,
                _ => throw new Exception("Invalid hand")
            },
            HandType.TwoPair => jokerCount switch
            {
                1 => HandType.FullHouse,
                _ => throw new Exception("Invalid hand")
            },
            HandType.ThreeKind => jokerCount switch
            {
                1 => HandType.FourKind,
                2 => HandType.FiveKind,
                _ => throw new Exception("Invalid hand")
            },
            HandType.FullHouse => HandType.FullHouse,
            HandType.FourKind => jokerCount switch
            {
                1 => HandType.FiveKind,
                _ => throw new Exception("Invalid hand")
            },
            HandType.FiveKind => HandType.FiveKind,
            _ => throw new Exception("Invalid hand")
        };
    }

    static int TieBreak(CamelGame a, CamelGame b)
    {
        foreach (var (First, Second) in a.hand.Zip(b.hand))
        {
            if (First != Second)
            {
                CamelCard val1 = (CamelCard)Enum.Parse(typeof(CamelCard), First.ToString());
                CamelCard val2 = (CamelCard)Enum.Parse(typeof(CamelCard), Second.ToString());
                return val1 > val2 ? 1 : -1;
            }
        }

        return 0;
    }

    static int TieBreakJoker(CamelGame a, CamelGame b)
    {
        foreach (var (First, Second) in a.hand.Zip(b.hand))
        {
            if (First != Second)
            {
                CamelCard val1 = (CamelCard)Enum.Parse(typeof(JokerCard), First.ToString());
                CamelCard val2 = (CamelCard)Enum.Parse(typeof(JokerCard), Second.ToString());
                return val1 > val2 ? 1 : -1;
            }
        }

        return 0;
    }

    public static int Part1(string[] input)
    {
        int count = 0;
        CamelGame[] games = ExtractGames(input);

        Array.Sort(games, (a, b) =>
        {
            HandType aType = RateHand(a.hand);
            HandType bType = RateHand(b.hand);

            if (aType == bType)
            {
                return TieBreak(a, b);
            }

            var res = aType > bType;
            return aType > bType ? 1 : -1;
        });

        for (int i = 0; i < games.Length; i++)
        {
            count += (games[i].bid) * (i + 1);
        }

        return count;
    }
    public static int Part2(string[] input)
    {
        int count = 0;
        CamelGame[] games = ExtractGames(input);

        Array.Sort(games, (a, b) =>
        {
            HandType aType = RateJokerHand(a.hand);
            HandType bType = RateJokerHand(b.hand);

            if (aType == bType)
            {
                return TieBreakJoker(a, b);
            }

            var res = aType > bType;
            return aType > bType ? 1 : -1;
        });

        for (int i = 0; i < games.Length; i++)
        {
            count += (games[i].bid) * (i + 1);
        }

        return count;
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 7!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\Day7.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}