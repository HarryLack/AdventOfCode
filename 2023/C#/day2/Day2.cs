using System.Text.RegularExpressions;

struct Cubes(int red, int green, int blue)
{
    public int red = red;
    public int green = green;
    public int blue = blue;
}

struct Game(int id, Cubes cubes)
{
    public int Id { get; set; } = id;
    public Cubes Cubes { get; set; } = cubes;
}

static partial class Day2
{
    private static readonly Dictionary<string, int> rules = new()
    {
        {"red", 12}, { "green",13}, { "blue",14}
    };

    [GeneratedRegex(@"(?<count>\d*).(?<colour>red|blue|green)")]
    private static partial Regex CubesMatcher();
    static Cubes ParseCubes(string input)
    {
        Regex cubeMatcher = CubesMatcher();
        MatchCollection cubesMatch = cubeMatcher.Matches(input);

        int red = 0;
        int green = 0;
        int blue = 0;

        foreach (Match match in cubesMatch.Cast<Match>())
        {
            int val = Int32.Parse(match.Groups[1].Value);
            switch (match.Groups[2].Value)
            {
                case "red":
                    if (val > red)
                    {
                        red = val;
                    }
                    break;
                case "green":
                    if (val > green)
                    {
                        green = val;
                    }
                    break;
                case "blue":
                    if (val > blue)
                    {
                        blue = val;
                    }
                    break;
                default:
                    break;
            }
        }

        return new(red, green, blue);
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex IDMatcher();
    public static Game ParseGame(string line)
    {
        Regex idMatcher = IDMatcher();
        string[] split1 = line.Split(':');
        Match idMatch = idMatcher.Match(split1[0]);
        int id = Int32.Parse(idMatch.Value);
        Cubes cubes = ParseCubes(split1[1]);
        return new(id, cubes);
    }

    public static bool IsValidGame(Game? game)
    {
        if (game == null || game?.Cubes.red > rules["red"] || game?.Cubes.green > rules["green"] || game?.Cubes.blue > rules["blue"])
        {
            return false;
        }

        return true;
    }

    static int Part1()
    {
        int count = 0;
        string[] inputs = Helpers.ReadAsArray(@"..\..\..\..\inputs\day2.txt");

        foreach (string line in inputs)
        {
            Game game = Day2.ParseGame(line);
            bool isValid = Day2.IsValidGame(game);

            if (isValid)
            {
                count += game.Id;
            }
        }

        return count;
    }

    public static void Answer()
    {
        Console.WriteLine("Hello, Day 2!");
        Console.WriteLine("My Part 1 result is " + Part1());
    }

}