using IRace = (long time, long distance);

static partial class Day06
{

    readonly static string[] arrayedTestInput = [
        "Time:      7  15   30",
        "Distance:  9  40  200"
    ];
    // Part 1
    static long[] ExtractTimes(string[] input)
    {
        return input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
    }
    // Part 2
    static long ExtractTime(string[] input)
    {
        string time = input[0].Split(':', StringSplitOptions.TrimEntries)[1];
        return long.Parse(time.Replace(" ", ""));
    }
    // Part 1
    static long[] ExtractDistances(string[] input)
    {
        return input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
    }
    // Part 2
    static long ExtractDistance(string[] input)
    {
        return long.Parse(input[1].Split(':', StringSplitOptions.TrimEntries)[1].Replace(" ", ""));
    }
    // Part 1
    static IRace[] ExtractRaces(string[] input)
    {
        long[] times = ExtractTimes(input);
        long[] distances = ExtractDistances(input);

        return [.. times.Zip(distances, (a, b) => (time: a, distance: b))];
    }

    static IRace ExtractRace(string[] input)
    {
        long time = ExtractTime(input);
        long distance = ExtractDistance(input);

        return (time, distance);
    }

    static int CalculateWins(IRace race)
    {
        int count = 0;

        for (long i = 1; i < race.time; i++)
        {
            long speed = i;
            long move = race.time - i;
            long travelled = speed * move;
            if (travelled > race.distance)
            {
                count++;
            }
        }

        return count;
    }

    public static int Part1(string[] input)
    {
        int? count = null;

        IRace[] races = ExtractRaces(input);

        foreach (IRace race in races)
        {
            if (count == null)
            {
                count = CalculateWins(race);
            }
            else
            {
                count *= CalculateWins(race);
            }
        }

        return count ?? 0;
    }
    public static int Part2(string[] input)
    {
        IRace race = ExtractRace(input);
        return CalculateWins(race);
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 6!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\day6.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}