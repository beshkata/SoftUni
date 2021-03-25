using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0);

            string patternDigit = @"\d";
            string patternLetter = @"[A-Za-z]";

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of race")
                {
                    break;
                }

                int distance = GetDistance(line, patternDigit);
                string name = GetName(line, patternLetter);

                if (racers.ContainsKey(name))
                {
                    racers[name] += distance;
                }
            }

            string[] sorted = racers
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => x.Key)
                .ToArray();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }

        private static string GetName(string line, string patternLetter)
        {
            StringBuilder sb = new StringBuilder();
            Regex regex = new Regex(patternLetter);

            var letters = regex.Matches(line);

            foreach (Match letter in letters)
            {
                sb.Append(letter.Value);
            }

            return sb.ToString();
        }

        private static int GetDistance(string line, string patternDigit)
        {
            int sum = 0;
            Regex regex = new Regex(patternDigit);

            var digits = regex.Matches(line);

            foreach (Match digit in digits)
            {
                sum += int.Parse(digit.Value);
            }

            return sum;
        }
    }
}
