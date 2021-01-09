using System;

namespace _06._Easter_Decoration
{
    class Program
    {
        static void Main()
        {
            int numberOfClients = int.Parse(Console.ReadLine());

            double totalBill = 0.0;

            for (int i = 0; i < numberOfClients; i++)
            {
                string input = Console.ReadLine();
                int itemCounter = 0;
                double currentBill = 0.0;

                while (input != "Finish")
                {
                    itemCounter++;
                    switch (input)
                    {
                        case "basket":
                            currentBill += 1.5;
                            break;
                        case "wreath":
                            currentBill += 3.80;
                            break;
                        case "chocolate bunny":
                            currentBill += 7.0;
                            break;
                    }

                    input = Console.ReadLine();
                }
                if (itemCounter % 2 == 0)
                {
                    currentBill -= currentBill * 0.2;
                }
                totalBill += currentBill;
                Console.WriteLine($"You purchased {itemCounter} items for {currentBill:f2} leva.");
            }

            Console.WriteLine($"Average bill per client is: {totalBill/numberOfClients:f2} leva.");
        }
    }
}
