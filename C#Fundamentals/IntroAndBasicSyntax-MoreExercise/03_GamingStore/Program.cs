using System;

namespace _03_GamingStore
{
    class Program
    {
        static void Main()
        {
            double currentMoney = double.Parse(Console.ReadLine());

            double startMoney = currentMoney;
            double gamePrice = 0.0;
            string input = Console.ReadLine();

            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;
                    default:
                        gamePrice = 0.0;
                        break;
                }
                if (gamePrice == 0.0)
                {
                    Console.WriteLine("Not Found");
                }
                else
                {
                    if (currentMoney - gamePrice < 0)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        currentMoney -= gamePrice;
                        Console.WriteLine($"Bought {input}");
                        if (currentMoney == 0.0)
                        {
                            Console.WriteLine("Out of money!");
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            if (currentMoney != 0.0)
            {
                Console.WriteLine($"Total spent: ${startMoney - currentMoney:f2}. Remaining: ${currentMoney:f2}");
            }
        }
    }
}
