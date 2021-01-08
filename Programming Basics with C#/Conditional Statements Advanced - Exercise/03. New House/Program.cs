using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double totalPrice = 0.0;
            double finalPrice = 0.0;

            switch (flowerType)
            {
                case "Roses":
                    if (numberOfFlowers > 80)
                    {
                        totalPrice = (double)numberOfFlowers * 5;
                        finalPrice = totalPrice - totalPrice * 0.1;
                    }
                    else
                    {
                        finalPrice = (double)numberOfFlowers * 5;
                    }
                    break;
                case "Dahlias":
                    if (numberOfFlowers > 90)
                    {
                        totalPrice = (double)numberOfFlowers * 3.8;
                        finalPrice = totalPrice - totalPrice * 0.15;
                    }
                    else
                    {
                        finalPrice = (double)numberOfFlowers * 3.8;
                    }
                    break;
                case "Tulips":
                    if (numberOfFlowers > 80)
                    {
                        totalPrice = (double)numberOfFlowers * 2.8;
                        finalPrice = totalPrice - totalPrice * 0.15;
                    }
                    else
                    {
                        finalPrice = (double)numberOfFlowers * 2.8;
                    }
                    break;
                case "Narcissus":
                    if (numberOfFlowers < 120)
                    {
                        totalPrice = (double)numberOfFlowers * 3;
                        finalPrice = totalPrice + totalPrice * 0.15;
                    }
                    else
                    {
                        finalPrice = (double)numberOfFlowers * 3;
                    }
                    break;
                case "Gladiolus":
                    if (numberOfFlowers < 80)
                    {
                        totalPrice = (double)numberOfFlowers * 2.5;
                        finalPrice = totalPrice + totalPrice * 0.20;
                    }
                    else
                    {
                        finalPrice = (double)numberOfFlowers * 2.5;
                    }
                    break;
                default:
                    break;
            };

            if (budget >= finalPrice)
            {
                Console.WriteLine("Hey, you have a great garden with {0} {1} and {2:f2} leva left.", numberOfFlowers, flowerType, budget - finalPrice);
            }
            else
            {
                Console.WriteLine("Not enough money, you need {0:f2} leva more.", finalPrice - budget);
            }
        }
    }
}
