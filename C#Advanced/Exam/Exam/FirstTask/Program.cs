using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            while (ingredients.Count != 0 && freshnessLevel.Count != 0)
            {
                int ingradient = ingredients.Dequeue();
                if (ingradient == 0)
                {
                    continue;
                }

                int freshness = freshnessLevel.Pop();

                int dish = ingradient * freshness;

                if (dish == 150)
                {
                    dippingSauce++;
                    continue;
                }
                else if (dish == 250)
                {
                    greenSalad++;
                    continue;
                }
                else if (dish == 300)
                {
                    chocolateCake++;
                    continue;
                }
                else if (dish == 400)
                {
                    lobster++;
                    continue;
                }
                else
                {
                    ingradient += 5;
                    ingredients.Enqueue(ingradient);
                }
            }

            bool isSuccessful = dippingSauce > 0 && greenSalad > 0 && chocolateCake > 0 && lobster > 0;

            if (isSuccessful)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                int sum = 0;
                while (ingredients.Count != 0)
                {
                    sum += ingredients.Dequeue();
                }
                Console.WriteLine($"Ingredients left: {sum}");
            }
            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", dippingSauce);
            dishes.Add("Green salad", greenSalad);
            dishes.Add("Chocolate cake", chocolateCake);
            dishes.Add("Lobster", lobster);

            dishes = dishes
                .Where(d => d.Value > 0)
                .OrderBy(d => d.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var dish in dishes)
            {
                Console.WriteLine($"# {dish.Key} --> {dish.Value}");
            }
        }
    }
}
