using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = tokens[0];
                string[] predicateArgs = tokens
                    .Skip(1)
                    .ToArray();

                Predicate<string> predicate = GetPredicate(predicateArgs);

                if (cmdType == "Remove")
                {
                    names.RemoveAll(predicate);
                }
                else if (cmdType == "Double")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        string currName = names[i];
                        if (predicate(currName))
                        {
                            names.Insert(i + 1, currName);
                            i++;
                        }
                    }
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            string prType = predicateArgs[0];
            string prArg = predicateArgs[1];

            Predicate<string> predicate = null;

            if (prType == "StartsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.StartsWith(prArg);
                });
            }
            else if (prType == "EndsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.EndsWith(prArg);
                });
            }
            else if (prType == "Length")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(prArg);
                });
            }

            return predicate;
        }
    }
}
