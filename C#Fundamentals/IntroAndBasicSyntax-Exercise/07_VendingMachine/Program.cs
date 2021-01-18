using System;

namespace _07_VendingMachine
{
    class Program
    {
        static void Main()
        {
            double moneySum = 0;
            string input = Console.ReadLine();

            while (input != "Start")
            {
                double coin = double.Parse(input);
                switch (coin)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1:
                    case 2:
                        moneySum += coin;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coin}");
                        break;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                bool isInvalidProduct = false;
                double moneyNeeded = 0.0;
                switch (input)
                {
                    case "Nuts":
                        moneyNeeded = 2.0;
                        break;
                    case "Water":
                        moneyNeeded = 0.7;
                        break;
                    case "Crisps":
                        moneyNeeded = 1.5;
                        break;
                    case "Soda":
                        moneyNeeded = 0.8;
                        break;
                    case "Coke":
                        moneyNeeded = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        isInvalidProduct = true;
                        break;
                }
                if (!isInvalidProduct)
                {
                    if (moneyNeeded <= moneySum)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        moneySum -= moneyNeeded;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {moneySum:f2}");
        }
    }
}
