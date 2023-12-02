using System.IO;
using System.Runtime.CompilerServices;

static class Day1
{
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
            if (first == null)
            {
                first = c;
            }
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

    public static int Count()
    {
        int count = 0;
        string? line;

        StreamReader reader = new StreamReader(@"..\..\..\..\inputs\Day1.txt");

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            if (line != null)
            {
                count += ExtractDigits(line);
            }
        }

        return count;
    }

    public static void Answer()
    {
        Console.WriteLine("Hello, Day 1!");
        Console.WriteLine("My result is " + Count());
    }
}