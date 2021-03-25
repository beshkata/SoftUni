using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main()
        {
            string pattern = @"[^|$%.]*%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)*\|[^|$%.]*?(?<price>\d+\.?\d*)\$";

            double totalIncome = 0.0;
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of shift")
                {
                    break;
                }

                Regex regex = new Regex(pattern);

                Match info = regex.Match(line);

                if (!info.Success)
                {
                    continue;
                }

                string name = info.Groups["name"].Value;
                string product = info.Groups["product"].Value;
                int count = int.Parse(info.Groups["count"].Value);
                double price = double.Parse(info.Groups["price"].Value);

                double currentIncome = count * price;

                Console.WriteLine($"{name}: {product} - {currentIncome:f2}");

                totalIncome += currentIncome;
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
