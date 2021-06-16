using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                trainers[trainerName].Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            List<Trainer> trainersList = new List<Trainer>();
            foreach (var trainer in trainers)
            {
                trainersList.Add(trainer.Value);
            }

            while (input != "End")
            {
                for (int i = 0; i < trainersList.Count; i++)
                {
                    if (trainersList[i].Pokemons.Any(p => p.Element == input))
                    {
                        trainersList[i].Badges++;
                    }
                    else
                    {
                        for (int k = 0; k < trainersList[i].Pokemons.Count; k++)
                        {
                            trainersList[i].Pokemons[k].Health -= 10;
                        }
                        trainersList[i].Pokemons = trainersList[i].Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
                input = Console.ReadLine();
            }

            trainersList = trainersList
                .OrderByDescending(t => t.Badges)
                .ToList();

            foreach (Trainer trainer1 in trainersList)
            {
                Console.WriteLine($"{trainer1.Name} {trainer1.Badges} {trainer1.Pokemons.Count}");
            }
        }

    }
}
