using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            if (tickets.Length == 0)
            {
                return;
            }

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string ticketPattern = @"([@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10})";

                string left = ticket.Substring(0, 10);
                string right = ticket.Substring(10, 10);

                Match matchLeft = Regex.Match(left, ticketPattern);
                Match matchRight = Regex.Match(right, ticketPattern);

                if (!matchLeft.Success || !matchRight.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                char leftSymbol = matchLeft.Value[0];
                char rightSymbol = matchRight.Value[0];

                if (leftSymbol != rightSymbol)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                int symbolCount = Math.Min(matchLeft.Length, matchRight.Length);

                if (symbolCount == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{leftSymbol} Jackpot!");
                }
                else if(symbolCount >= 6)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {symbolCount}{leftSymbol}");
                }
            }
        }
    }
}
