using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int freeCapacity = 255;
            int totalWaterAdded = 0;
            for (int i = 0; i < n; i++)
            {
                int waterAdded = int.Parse(Console.ReadLine());
                if (freeCapacity < waterAdded)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    freeCapacity -= waterAdded;
                    totalWaterAdded += waterAdded;
                }
            }
            Console.WriteLine(totalWaterAdded);
        }
    }
}
