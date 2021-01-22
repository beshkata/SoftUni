using System;

namespace MetersToKilometers
{
    class Program
    {
        static void Main()
        {
            int meters = int.Parse(Console.ReadLine());

            decimal kilometers = meters / 1000M;
            Console.WriteLine("{0:f2}", kilometers);
        }
    }
}
