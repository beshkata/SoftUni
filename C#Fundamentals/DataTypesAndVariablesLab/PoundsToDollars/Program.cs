using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main()
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal dollars = pounds * 1.31M;

            Console.WriteLine("{0:f3}", dollars);
        }
    }
}
