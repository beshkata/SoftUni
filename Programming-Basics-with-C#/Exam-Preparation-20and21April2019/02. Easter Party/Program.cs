using System;

namespace _02._Easter_Party
{
    class Program
    {
        static void Main()
        {
            int guestsNum = int.Parse(Console.ReadLine());
            double pricePerGuest = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double totalPrice = pricePerGuest * guestsNum;

            if (guestsNum >= 10 && guestsNum <= 15)
            {
                totalPrice = guestsNum * (pricePerGuest - pricePerGuest * 0.15);
            }
            else if (guestsNum < 21 && guestsNum > 15)
            {
                totalPrice = guestsNum * (pricePerGuest - pricePerGuest * 0.20);
            }
            else if (guestsNum > 20)
            {
                totalPrice = guestsNum * (pricePerGuest - pricePerGuest * 0.25);
            }

            totalPrice += budget * 0.1; // cake price

            if (totalPrice <= budget)
            {
                Console.WriteLine($"It is party time! {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {totalPrice - budget:f2} leva needed.");
            }
        }
    }
}
