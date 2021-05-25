using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> petrolPumps = new Queue<int[]>(n);

            for (int i = 0; i < n; i++)
            {
                int[] currentPetrolPump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                petrolPumps.Enqueue(currentPetrolPump);
            }

            int indexOfPump = 0;
            
            while (true)
            {
                int currentPetrolInTank = 0;
                bool hasSuccess = true;
                foreach (int[] pump in petrolPumps)
                {
                    currentPetrolInTank += pump[0];
                    int distance = pump[1];

                    if (currentPetrolInTank < distance)
                    {
                        indexOfPump++;
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        hasSuccess = false;
                        break;
                    }
                    else
                    {
                        currentPetrolInTank -= distance;
                    }
                }
                if (hasSuccess)
                {
                    Console.WriteLine(indexOfPump);
                    return;
                }
            }
        }
    }
}
