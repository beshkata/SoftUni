using System;

namespace _02._Beer_And_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string fanName = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beerNum = int.Parse(Console.ReadLine());
            int chipsPacks = int.Parse(Console.ReadLine());

            double beerPrice = beerNum * 1.20;
            double chipsPrice = beerPrice * 0.45;

            double totalChipsPrice = chipsPrice * chipsPacks;

            if (totalChipsPrice - (int)totalChipsPrice != 0)
            {
                totalChipsPrice = (int)(totalChipsPrice + 1);
            }
            else
            {
                totalChipsPrice = (int)totalChipsPrice;
            }

            double totalPrice = beerPrice + totalChipsPrice;
            if (budget < totalPrice)
            {
                Console.WriteLine($"{fanName} needs {totalPrice - budget:f2} more leva!");
            }
            else
            {
                Console.WriteLine($"{fanName} bought a snack and has {budget - totalPrice:f2} leva left.");
            }
        }
    }
}
