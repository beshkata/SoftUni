using System;
using System.Linq;

namespace TheLift
{
    class Program
    {
        static void Main()
        {
            int peopleOnQueue = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool isLiftFull = false;

            for (int i = 0; i < lift.Length; i++)
            {
                if (lift[i] + peopleOnQueue > 4)
                {
                    peopleOnQueue -= 4 - lift[i];
                    lift[i] = 4;

                    if (i == lift.Length-1)
                    {
                        Console.WriteLine($"There isn't enough space! {peopleOnQueue} people in a queue!");
                        isLiftFull = true;
                    }
                }
                else
                {
                    lift[i] += peopleOnQueue;
                    peopleOnQueue = 0;
                    break;
                }
            }

            int emptySpots = 0;

            if (isLiftFull == false)
            {
                foreach (int wagon in lift)
                {
                    if (wagon < 4)
                    {
                        emptySpots += 4 - wagon;
                    }
                }
            }

            if (emptySpots != 0)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            Console.WriteLine(string.Join(' ', lift));
        }
    }
}
