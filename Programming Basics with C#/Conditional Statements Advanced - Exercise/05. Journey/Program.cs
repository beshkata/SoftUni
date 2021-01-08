﻿using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (season == "summer")
                {
                    Console.WriteLine("Camp - {0:f2}", budget * 0.3);
                }
                else
                {
                    Console.WriteLine("Hotel - {0:f2}", budget * 0.7);
                }
            }
            else if (budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    Console.WriteLine("Camp - {0:f2}", budget * 0.4);
                }
                else
                {
                    Console.WriteLine("Hotel - {0:f2}", budget * 0.8);
                }
            }
            else if (budget > 1000)
            {
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine("Hotel - {0:f2}", budget * 0.9);
            }
        }
    }
}
