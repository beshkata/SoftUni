using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] tokens = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string commandName = tokens[0];
                string filterType = tokens[1];
                string argument = tokens[2];

                if (commandName =="Add filter")
                {
                    filters.Add($"{filterType};{argument}");
                }
                else if (commandName == "Remove filter")
                {
                    filters.Remove($"{filterType};{argument}");

                }
                input = Console.ReadLine();
            }

            foreach (string filter in filters)
            {
                string[] tokens = filter
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                string filterType = tokens[0];
                string argument = tokens[1];

                switch (filterType)
                {
                    case "Starts with":
                        names = names.Where(p => !p.StartsWith(argument)).ToList();
                        break;
                    case "Ends with":
                        names = names.Where(p => !p.EndsWith(argument)).ToList();
                        break;
                    case "Length":
                        names = names.Where(p => p.Length != int.Parse(argument)).ToList();
                        break;
                    case "Contains":
                        names = names.Where(p => !p.Contains(argument)).ToList();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', names));
        }
    }
}
