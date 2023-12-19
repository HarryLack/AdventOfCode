using System.Text.RegularExpressions;

static partial class Day01
{
    enum NumberDigit
    {
        one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9,
    }

    private static string[] ReadAsArray()
    {
        List<string> lines = [];

        StreamReader reader = new(@"..\..\..\..\inputs\Day1.txt");

        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (line != null)
            {
                lines.Add(line);
            }
        }

        return [.. lines];
    }

    public static int ExtractDigits(string input)
    {
        char? first = null;
        char? last = null;

        foreach (char c in input)
        {
            if (!Char.IsNumber(c))
            {
                continue;
            }
            first ??= c;
            last = c;
        }

        if (first != null && last != null)
        {
            string res = first.ToString() + last.ToString();
            int resval = Int32.Parse(res);
            return resval;
        }

        throw new Exception("Could not extract digits from input");
    }

    public static int CountDigits()
    {
        int count = 0;
        string[] inputs = ReadAsArray();
        foreach (string input in inputs)
        {
            count += ExtractDigits(input);
        }

        return count;
    }

    [GeneratedRegex(@"(?=([1-9]|one|two|three|four|five|six|seven|eight|nine))")]
    private static partial Regex NumberMatcher();

    public static int ExtractNumbers(string input)
    {
        Regex matcher = NumberMatcher();

        MatchCollection matches = matcher.Matches(input);

        string? first = matches[0].Groups[1]?.ToString();
        string? last = matches[^1].Groups[1]?.ToString();

        if (first != null && last != null)
        {
            if (Enum.IsDefined(typeof(NumberDigit), first.ToLower()))
            {
                int NumberAsDigit = (int)(NumberDigit)Enum.Parse(typeof(NumberDigit), first);
                first = NumberAsDigit.ToString();
            }
            if (Enum.IsDefined(typeof(NumberDigit), last.ToLower()))
            {
                int NumberAsDigit = (int)(NumberDigit)Enum.Parse(typeof(NumberDigit), last);
                last = NumberAsDigit.ToString();
            }
            string res = Int32.Parse(first).ToString() + Int32.Parse(last).ToString();

            return Int32.Parse(res);
        }

        throw new Exception("Could not extract numbers from input");
    }

    public static int CountNumbers()
    {
        int count = 0;
        string[] inputs = ReadAsArray();
        foreach (string input in inputs)
        {
            count += ExtractNumbers(input);
        }

        return count;
    }

    public static void Answer()
    {
        Console.WriteLine("Hello, Day 1!");
        Console.WriteLine("My Part 1 result is " + CountDigits());
        Console.WriteLine("My Part 2 result is " + CountNumbers());
    }
}