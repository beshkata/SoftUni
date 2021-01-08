using System;

namespace _04._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int personsCount = int.Parse(Console.ReadLine());

            double boatRent = 0.0;
            double discount = 0.0;
            double totalCost = 0.0;

            switch (season)
            {
                case "Spring":
                    boatRent = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    boatRent = 4200;
                    break;
                case "Winter":
                    boatRent = 2600;
                    break;
                default:
                    break;
            }

            if (personsCount <= 6)
            {
                discount = boatRent * 0.1;
            }
            else if (personsCount > 6 && personsCount <= 11)
            {
                discount = boatRent * 0.15;
            }
            else
            {
                discount = boatRent * 0.25;
            }


            totalCost = boatRent - discount;
            if (personsCount % 2 == 0 && season != "Autumn")
            {
                totalCost = totalCost - (totalCost * 0.05);
            }

            if (budget >= totalCost)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.", budget - totalCost);
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.", totalCost - budget);
            }
        }
    }
}
