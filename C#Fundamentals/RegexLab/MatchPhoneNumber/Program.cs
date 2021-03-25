using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<code>\+359)(\ |-)2(\2)\d{3}(\2)\d{4}\b";

            string phoneNumbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(phoneNumbers, pattern);

            string[] phones = matches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
