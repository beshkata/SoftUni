using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Town
    {
        public Town(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }
        public string Name { get; set; }

        public int Gold { get; set; }

        public int Population { get; set; }

        public void Plunder(int populationKilled, int goldStolen)
        {
            Population -= populationKilled;
            Gold -= goldStolen;

            Console.WriteLine($"{Name} plundered! {goldStolen} gold stolen, {populationKilled} citizens killed.");

        }

        public void Prosper(int goldAdded)
        {
            if (goldAdded < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
                return;
            }

            Gold += goldAdded;
            Console.WriteLine($"{goldAdded} gold added to the city treasury. {Name} now has {Gold} gold.");
        }

        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, Town> towns = new Dictionary<string, Town>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sail")
                {
                    break;
                }

                string[] townInfo = input.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string name = townInfo[0];
                int population = int.Parse(townInfo[1]);
                int gold = int.Parse(townInfo[2]);

                if (towns.ContainsKey(name))
                {
                    towns[name].Population += population;
                    towns[name].Gold += gold;

                    continue;
                }

                Town town = new Town(name, population, gold);
                towns.Add(town.Name, town);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string name = tokens[1];

                if (!towns.ContainsKey(name))
                {
                    continue;
                }

                if (command == "Plunder")
                {
                    int populationKilled = int.Parse(tokens[2]);
                    int goldStolen = int.Parse(tokens[3]);

                    towns[name].Plunder(populationKilled, goldStolen);

                    if (towns[name].Population <= 0 || towns[name].Gold <= 0)
                    {
                        Console.WriteLine($"{name} has been wiped off the map!");
                        towns.Remove(name);
                    }
                }
                else
                {
                    int goldAdded = int.Parse(tokens[2]);

                    towns[name].Prosper(goldAdded);
                }
            }

            Dictionary<string, Town> sorted = towns
                .OrderByDescending(x => x.Value.Gold)
                .ThenBy(x => x.Value.Name)
                .ToDictionary(k => k.Key, v => v.Value);

            if (sorted.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {sorted.Count} wealthy settlements to go to:");

                foreach (var town in sorted)
                {
                    Console.WriteLine(town.Value.ToString());
                }
            }
        }
    }
}
