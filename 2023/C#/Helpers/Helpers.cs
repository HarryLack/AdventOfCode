static class Helpers
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
}

