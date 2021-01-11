using System;

namespace _01._Cat_Diet
{
    class Program
    {
        static void Main(string[] args)
        {
            const int fat = 9;
            const int protein = 4;
            const int carbs = 4;

            int fatPcent = int.Parse(Console.ReadLine());
            int proteinPcent = int.Parse(Console.ReadLine());
            int carbPcent = int.Parse(Console.ReadLine());
            int totalCal = int.Parse(Console.ReadLine());
            int aquaPcent = int.Parse(Console.ReadLine());

            double totalFatGr = 1.0 * (totalCal * fatPcent / 100) / fat;
            double totalProteinGr = 1.0 * (totalCal * proteinPcent / 100) / protein;
            double totalCarbGr = 1.0 * (totalCal * carbPcent / 100) / carbs;

            double foodWeight = totalFatGr + totalProteinGr + totalCarbGr;

            double calPerGrFood = totalCal / foodWeight;

            Console.WriteLine($"{calPerGrFood * (100 - aquaPcent) / 100:f4}");
        }
    }
}
