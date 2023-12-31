﻿static class Helpers
{
    public static string[] ReadAsArray(string file)
    {
        List<string> lines = [];

        StreamReader reader = new(file);

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
    public static ulong GCD(ulong a, ulong b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }

    public static ulong LCM(ulong a, ulong b)
    {
        return (a * b) / GCD(a, b);
    }

    public static ulong LCM(ulong[] input)
    {
        if (input.Length == 2)
        {
            return LCM(input[0], input[1]);
        }

        return LCM(input[0], LCM(input.Skip(1).ToArray()));
    }
}

