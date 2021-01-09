using System;

namespace _01._Easter_Lunch
{
    class Program
    {
        static void Main()
        {
            const double kozunakPrice = 3.20;
            const double eggsPrice = 4.35; // per package with 12 eggs
            const double cookiesPrice = 5.40; // per kilo 
            const double eggsPaintPrice = 0.15; // per eggs

            int kozunakNum = int.Parse(Console.ReadLine());
            int eggsPackages = int.Parse(Console.ReadLine());
            int cookiesVolume = int.Parse(Console.ReadLine());

            double totalPrice = kozunakPrice * kozunakNum + eggsPrice * eggsPackages + cookiesPrice * cookiesVolume +
                eggsPaintPrice * eggsPackages * 12;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
