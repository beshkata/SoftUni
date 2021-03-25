using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main()
        {
            string pattern = @"(?<day>\d{2})([\/.-])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            var dates = regex.Matches(input);

            foreach (Match date in dates)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}
