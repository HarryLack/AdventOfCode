using IRace = (int time, int distance);

static partial class Day6
{

    readonly static string[] arrayedTestInput = [
        "Time:      7  15   30",
        "Distance:  9  40  200"
    ];

    static int[] ExtractTimes(string[] input)
    {
        return input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
    }
    static int[] ExtractDistances(string[] input)
    {
        return input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
    }

    static IRace[] ExtractRaces(string[] input)
    {
        int[] times = ExtractTimes(input);
        int[] distances = ExtractDistances(input);

        return [.. times.Zip(distances, (a, b) => (time: a, distance: b))];
    }

    static int CalculateWins(IRace race)
    {
        int count = 0;

        for (int i = 1; i < race.time; i++)
        {
            int speed = i;
            int move = race.time - i;
            int travelled = speed * move;
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

        int count = int.MaxValue;

        return count;
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 6!");
        string[] input = Helpers.ReadAsArray(@"..\..\..\..\inputs\day6.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        //Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}