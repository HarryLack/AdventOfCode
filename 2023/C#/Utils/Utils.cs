namespace Utils
{
    static class File
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

            reader.Close();

            return [.. lines];
        }
    }

    static class Maths
    {
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
            return a * b / GCD(a, b);
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

    static class Cast
    {
        public static char[][] StringArrayToCharArrayArray(string[] input)
        {
            List<char[]> rows = [];

            foreach (var line in input)
            {
                List<char> row = [];

                foreach (var ch in line)
                {
                    row.Add(ch);
                }

                rows.Add([.. row]);
            }

            return [.. rows];
        }
    }
}