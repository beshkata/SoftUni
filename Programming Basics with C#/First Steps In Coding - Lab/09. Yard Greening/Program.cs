using System;

namespace _09._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            const double pricePerSqM = 7.61;

            double size = double.Parse(Console.ReadLine());

            double wholeSum = size * pricePerSqM;

            double discount = wholeSum * 0.18;

            double finalSum = wholeSum - discount;

            Console.WriteLine($"The final price is: {finalSum} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
