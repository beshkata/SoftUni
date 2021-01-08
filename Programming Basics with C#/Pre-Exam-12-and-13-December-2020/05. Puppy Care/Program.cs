using System;

namespace _05._Puppy_Care
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine()) * 1000;
            string input = Console.ReadLine();

            int totalFoodEaten = 0;

            while (input != "Adopted")
            {
                totalFoodEaten += int.Parse(input);
                input = Console.ReadLine();
            }

            if (totalFoodEaten > food)
            {
                Console.WriteLine($"Food is not enough. You need {totalFoodEaten - food} grams more.");
            }
            else
            {
                Console.WriteLine($"Food is enough! Leftovers: {food - totalFoodEaten} grams.");
            }
        }
    }
}
