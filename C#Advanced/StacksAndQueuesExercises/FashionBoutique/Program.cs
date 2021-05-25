using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stackOfClothes = new Stack<int>(clothes);

            int racksCounter = 1;
            int currentRackCapacity = rackCapacity;

            while (stackOfClothes.Count > 0)
            {
                int currentCloth = stackOfClothes.Peek();

                if (currentRackCapacity - currentCloth >= 0)
                {
                    stackOfClothes.Pop();
                    currentRackCapacity -= currentCloth;
                }
                else
                {
                    racksCounter++;
                    currentRackCapacity = rackCapacity;
                    stackOfClothes.Pop();
                    currentRackCapacity -= currentCloth;
                }
            }

            Console.WriteLine(racksCounter);
        }
    }
}
