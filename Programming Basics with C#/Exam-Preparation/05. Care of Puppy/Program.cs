using System;

namespace _05._Care_of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine()) * 1000;

            string input = Console.ReadLine();
            int eatenFood = 0;

            while (input != "Adopted")
            {
                eatenFood += int.Parse(input);
                input = Console.ReadLine();
            }

            if (eatenFood <= totalFood)
            {
                Console.WriteLine($"Food is enough! Leftovers: {totalFood - eatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {eatenFood - totalFood} grams more.");
            }
        }
    }
}
