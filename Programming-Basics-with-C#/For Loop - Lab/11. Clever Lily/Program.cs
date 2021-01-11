using System;

namespace _11._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int lilyAge = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            int numberOfToys = 0;
            double lilysMoney = 0.0;
            int counter = 1;

            for (int i = 1; i <= lilyAge; i++)
            {
                if (i % 2 == 0)
                {
                    lilysMoney += 10 * counter - 1;
                    counter++;
                }
                else
                {
                    numberOfToys++;
                }
            }
            lilysMoney = lilysMoney + numberOfToys * toyPrice;

            if (lilysMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {lilysMoney - washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - lilysMoney:f2}");
            }
        }
    }
}
