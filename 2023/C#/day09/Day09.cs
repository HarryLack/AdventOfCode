static partial class Day09
{

    readonly static string[] arrayedTestInput = ["0 3 6 9 12 15", "1 3 6 10 15 21", "10 13 16 21 30 45"];

    static List<List<int>> CreateHistory(string input)
    {
        List<List<int>> rows = [];
        rows.Add(input.Split(' ', StringSplitOptions.TrimEntries).Select(int.Parse).ToList());

        var currentRow = rows[0];

        while (!currentRow.All(x => x == 0))
        {
            List<int> newRow = [];

            for (int i = 0; (i + 1) < currentRow.Count; i++)
            {
                newRow.Add(currentRow[i + 1] - currentRow[i]);
            }

            rows.Add(newRow);
            currentRow = newRow;
        }

        return [.. rows];
    }

    static int ExtrapolateValue(List<List<int>> input)
    {
        var history = input;
        history.Reverse();

        history[0].Add(0);

        for (int i = 0; (i + 1) < history.Count; i++)
        {
            var parentRow = history[i + 1];

            int current = history[i][^1];
            int leftParent = parentRow[^1];

            parentRow.Add(leftParent + current);
        }

        return history.Last().Last();
    }

    static int ExtrapolateValueBackwards(List<List<int>> input)
    {
        var history = input;
        history.Reverse();

        _ = history[0].Prepend(0);

        for (int i = 0; (i + 1) < history.Count; i++)
        {
            var parentRow = history[i + 1];

            int current = history[i][0];
            int rightParent = parentRow[0];

            history[i + 1] = parentRow.Prepend(rightParent - current).ToList();
        }

        return history.Last()[0];
    }


    public static int Part1(string[] input)
    {
        int count = 0;

        foreach (var item in input)
        {
            count += ExtrapolateValue(CreateHistory(item));
        }

        return count;
    }
    public static int Part2(string[] input)
    {
        int count = 0;

        foreach (var item in input)
        {
            count += ExtrapolateValueBackwards(CreateHistory(item));
        }

        return count;
    }
    public static void Answer()
    {
        Console.WriteLine("Hello, Day 9!");
        string[] input = Utils.File.ReadAsArray(@"..\..\..\..\inputs\Day9.txt");
        Console.WriteLine("My Part 1 result is " + Part1(input));
        Console.WriteLine("My Part 2 result is " + Part2(input));
    }

}