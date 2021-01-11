using System;

namespace _01._Supplies_for_School
{
    class Program
    {
        static void Main()
        {
            const decimal penPrice = 5.80m;
            const decimal markerPrice = 7.20m;
            const decimal cleaningSolution = 1.20m;

            int numberPen = int.Parse(Console.ReadLine());
            int numberMarker = int.Parse(Console.ReadLine());
            decimal volumeCleaningSolution = decimal.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            decimal totalPrice = penPrice * numberPen + markerPrice * numberMarker + cleaningSolution * volumeCleaningSolution;

            decimal finalPrice = totalPrice - (totalPrice * discount / 100);
            Console.WriteLine($"{finalPrice:f3}");
        }
    }
}
