using System;
using System.Linq;

namespace HeartDelivery
{
    class Program
    {
        static void Main()
        {
            int[] houses = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int currentHouse = 0;

            string line = Console.ReadLine();

            while (line != "Love!")
            {
                string[] jumpParam = line.Split();
                int jumpLenght = int.Parse(jumpParam[1]);

                currentHouse += jumpLenght;
                if (currentHouse >= houses.Length)
                {
                    currentHouse = 0;
                }
                if (houses[currentHouse] == 0)
                {
                    Console.WriteLine($"Place {currentHouse} already had Valentine's day.");
                }
                else
                {
                    houses[currentHouse] -= 2;
                    if (houses[currentHouse] == 0)
                    {
                        Console.WriteLine($"Place {currentHouse} has Valentine's day.");
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {currentHouse}.");

            int housesNeededHeartsCount = 0;

            for (int i = 0; i < houses.Length; i++)
            {
                if (houses[i] != 0)
                {
                    housesNeededHeartsCount++;
                }
            }

            if (housesNeededHeartsCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {housesNeededHeartsCount} places.");
            }
        }
    }
}
