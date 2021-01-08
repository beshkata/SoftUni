using System;

namespace _04._Food_for_Pets
{
    class Program
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            double totalAmountFood = double.Parse(Console.ReadLine());

            int dogSum = 0;
            int catSum = 0;
            double cookies = 0.0;

            for (int i = 1; i <= days; i++)
            {
                int dogFood = int.Parse(Console.ReadLine());
                int catFood = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    cookies += (dogFood + catFood) * 0.1;
                }
                dogSum += dogFood;
                catSum += catFood;
            }

            Console.WriteLine($"Total eaten biscuits: {Math.Round(cookies)}gr.");
            Console.WriteLine($"{1.0 * (dogSum + catSum) / totalAmountFood * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{1.0 * dogSum / (dogSum + catSum) * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{1.0 * catSum / (dogSum + catSum) * 100:f2}% eaten from the cat.");
        }
    }
}
