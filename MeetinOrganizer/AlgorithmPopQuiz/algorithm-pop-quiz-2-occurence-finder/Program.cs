using System;
using System.Collections.Generic;

class Program
{
    static int FindOccurance(string t, string z)
    {
        int maxScore = 0;

        for (int i = 0; i < t.Length; i++)
        {
            for (int j = i + 1; j <= t.Length; j++)
            {
                string substring = t.Substring(i, j - i);
                int substringLength = substring.Length;
                int count = CountOccurrences(z, substring);

                int score = substringLength * count;
                if (score > maxScore)
                {
                    maxScore = score;
                }
            }
        }

        return maxScore;
    }

    static int CountOccurrences(string source, string pattern)
    {
        int count = 0;
        int i = 0;
        while ((i = source.IndexOf(pattern, i, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            i += pattern.Length;
            count++;
        }
        return count;
    }

    static void Main(string[] args)
    {
        string t = "acldm1labcdhsnd";
        string z = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";

        Console.WriteLine(FindOccurance(t, z));
    }
}
