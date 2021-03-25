using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^>>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            List<string> names = new List<string>();

            double totalSum = 0.0;

            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }

                names.Add(match.Groups["name"].Value);

                totalSum += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}
