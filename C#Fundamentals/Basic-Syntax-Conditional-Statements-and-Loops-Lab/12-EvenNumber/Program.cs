﻿using System;

namespace _12_EvenNumber
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            while (num % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                num = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {Math.Abs(num)}");
        }
    }
}