using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> potatoCircle = new Queue<string>(children);
            int counter = 1;

            while (potatoCircle.Count > 1)
            {
                string kid = potatoCircle.Dequeue();

                if (counter == n)
                {
                    counter = 1;
                    Console.WriteLine($"Removed {kid}");
                }
                else
                {
                    potatoCircle.Enqueue(kid);
                    counter++;
                }
            }

            Console.WriteLine($"Last is {potatoCircle.Dequeue()}");
        }
    }
}
