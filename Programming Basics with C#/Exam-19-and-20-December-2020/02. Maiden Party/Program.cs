using System;

namespace _02._Maiden_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double maidenPartyPrice = double.Parse(Console.ReadLine());
            int love = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int key = int.Parse(Console.ReadLine());
            int picture = int.Parse(Console.ReadLine());
            int luck = int.Parse(Console.ReadLine());

            int count = love + rose + key + picture + luck;

            double profit = love * 0.6 + rose * 7.2 + key * 3.6 + picture * 18.2 + luck * 22.0;

            if (count >= 25)
            {
                profit = profit - (profit * 0.35);
            }

            profit = profit - (profit * 0.1);

            if (profit >= maidenPartyPrice)
            {
                Console.WriteLine($"Yes! {profit - maidenPartyPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {maidenPartyPrice - profit:f2} lv needed.");
            }
        }
    }
}
