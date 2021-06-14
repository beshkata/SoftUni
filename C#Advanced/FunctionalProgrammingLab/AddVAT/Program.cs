using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = d => d *= 1.2;
            List<double> numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat)
                .ToList();
            foreach (var item in numbers)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
