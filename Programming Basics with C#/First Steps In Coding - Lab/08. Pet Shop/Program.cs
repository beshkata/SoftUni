using System;

namespace _08._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsNumber = int.Parse(Console.ReadLine());
            int numberOtherAnimals = int.Parse(Console.ReadLine());

            double finalSum = (dogsNumber * 2.5) + (numberOtherAnimals * 4);

            Console.WriteLine($"{finalSum} lv.");
        }
    }
}
