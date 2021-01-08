using System;

namespace _06._Gold_Mine
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLocations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numLocations; i++)
            {
                double gold = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                double averageGold = 0;

                for (int j = 0; j < days; j++)
                {
                    averageGold += double.Parse(Console.ReadLine());
                }
                if (averageGold / days >= gold)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageGold / days:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {(gold - averageGold / days):f2} gold.");
                }
            }
        }
    }
}
