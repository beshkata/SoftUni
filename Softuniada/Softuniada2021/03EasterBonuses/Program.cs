using System;
using System.Linq;

namespace _03EasterBonuses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalBonuses = 0;

            while (input != "stop")
            {
                string name = input;
                int[] taskFinished = Console.ReadLine()
                    .Split(',')
                    .Select(s => s.Trim())
                    .Select(int.Parse)
                    .ToArray();
                int[] products = new int[taskFinished.Length];

                for (int i = 0; i < taskFinished.Length; i++)
                {
                    int product = 1;

                    for (int j = 0; j < taskFinished.Length; j++)
                    {
                        if (j != i)
                        {
                            product *= taskFinished[j];
                        }
                    }
                    products[i] = product;
                }

                int totalSum = products.Sum();
                totalBonuses += totalSum;

                Console.WriteLine($"{name} has a bonus of {totalSum} lv.");

                input = Console.ReadLine();
            }
            Console.WriteLine($"The amount of all bonuses is {totalBonuses} lv.");
        }
    }
}
