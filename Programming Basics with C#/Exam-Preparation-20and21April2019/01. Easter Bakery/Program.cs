using System;

namespace _01._Easter_Bakery
{
    class Program
    {
        static void Main()
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double flourVolume = double.Parse(Console.ReadLine());
            double sugarVolume = double.Parse(Console.ReadLine());
            int eggsPackages = int.Parse(Console.ReadLine());
            int yeastPackages = int.Parse(Console.ReadLine());

            double sugarPrice = flourPrice - flourPrice * 0.25;
            double eggsPrice = flourPrice + flourPrice * 0.1;
            double yeastPrice = sugarPrice - sugarPrice * 0.8;

            double totalPrice = flourVolume * flourPrice + sugarVolume * sugarPrice + eggsPackages * eggsPrice +
                yeastPackages * yeastPrice;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
