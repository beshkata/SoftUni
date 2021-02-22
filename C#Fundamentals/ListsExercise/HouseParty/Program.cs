using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>(commandsCount);

            for (int i = 0; i < commandsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string guestName = input[0];

                if (input.Length == 3)
                {
                    if (!guests.Contains(guestName))
                    {
                        guests.Add(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                }
                else
                {
                    bool isInList = guests.Remove(guestName);
                    if (!isInList)
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                }
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
