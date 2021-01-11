using System;

namespace _02._Easter_Guests
{
    class Program
    {
        static void Main()
        {
            const double eggPrice = 0.45;
            const double kozunakPrice = 4.0;

            int guestsNum = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int kozunakNumber = 0;
            int eggsNum = guestsNum * 2;
            double totalPrice = 0;
            
            if (guestsNum % 3 == 0)
            {
                kozunakNumber = guestsNum / 3;
            }
            else
            {
                kozunakNumber = guestsNum / 3 + 1;
            }

            totalPrice = kozunakNumber * kozunakPrice + eggsNum * eggPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Lyubo bought {kozunakNumber} Easter bread and {eggsNum} eggs.");
                Console.WriteLine($"He has {budget - totalPrice:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {totalPrice - budget:f2} lv. more.");
            }
        }
    }
}
