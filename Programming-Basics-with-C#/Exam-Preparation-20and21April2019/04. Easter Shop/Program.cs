using System;

namespace _04._Easter_Shop
{
    class Program
    {
        static void Main()
        {
            int eggsNum = int.Parse(Console.ReadLine());

            string typeOfAction = Console.ReadLine();

            int eggsSold = 0;

            while (typeOfAction != "Close")
            {
                int inputNum = int.Parse(Console.ReadLine());

                if (typeOfAction == "Buy")
                {
                    
                    if (eggsNum - inputNum < 0)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggsNum}.");
                        break;
                    }
                    eggsNum -= inputNum;
                    eggsSold += inputNum;
                }
                else
                {
                    eggsNum += inputNum;
                }
                typeOfAction = Console.ReadLine();
            }

            if (typeOfAction == "Close")
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{eggsSold} eggs sold.");
            }
        }
    }
}
