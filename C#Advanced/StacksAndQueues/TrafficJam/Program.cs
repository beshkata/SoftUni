using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int carsCounter = 0;

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    int carsInQueue = carsToPass;
                    if (carsToPass > cars.Count)
                    {
                        carsInQueue = cars.Count;
                    }
                    for (int i = 0; i < carsInQueue; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carsCounter++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{carsCounter} cars passed the crossroads.");
        }
    }
}
