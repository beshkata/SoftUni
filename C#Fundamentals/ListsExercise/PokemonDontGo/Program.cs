using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main()
        {
            List<int> pokemons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int sum = 0;
            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                bool isLessThanZero = false;
                bool isGreaterThanCount = false;

                if (index < 0)
                {
                    isLessThanZero = true;
                    index = 0;
                }

                if (index > pokemons.Count - 1)
                {
                    isGreaterThanCount = true;
                    index = pokemons.Count - 1;
                }

                int element = pokemons[index];

                if (isLessThanZero)
                {
                    sum += pokemons[index];
                    pokemons.RemoveAt(0);
                    int lastElement = pokemons[pokemons.Count - 1];
                    pokemons.Insert(0, lastElement);
                }
                else if (isGreaterThanCount)
                {
                    sum += pokemons[index];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    int firstElement = pokemons[0];
                    pokemons.Add(firstElement);
                }
                else
                {
                    sum += pokemons[index];
                    pokemons.RemoveAt(index);
                }

                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= element)
                    {
                        pokemons[i] += element;
                    }
                    else
                    {
                        pokemons[i] -= element;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
