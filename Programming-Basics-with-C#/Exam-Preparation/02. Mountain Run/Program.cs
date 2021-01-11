using System;

namespace _02._Mountain_Run
{
    class Program
    {
        static void Main()
        {
            double recordInSec = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double speed = double.Parse(Console.ReadLine());

            double totalTime = distance * speed + (int)(distance / 50) * 30;

            if (recordInSec <= totalTime)
            {
                Console.WriteLine($"No! He was {totalTime - recordInSec:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
        }
    }
}
