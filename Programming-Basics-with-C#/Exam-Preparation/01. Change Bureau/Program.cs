using System;

namespace _01._Change_Bureau
{
    class Program
    {
        static void Main()
        {
            const decimal bitcoinPrice = 1168.0m;
            const decimal usdolarPrice = 1.76m;
            const decimal uanPrice = 0.15m * usdolarPrice;
            const decimal euroPrice = 1.95m;

            int bitcoinNum = int.Parse(Console.ReadLine());
            decimal uanNumber = decimal.Parse(Console.ReadLine());
            decimal commision = decimal.Parse(Console.ReadLine());

            decimal sumLeva = uanNumber * uanPrice + bitcoinNum * bitcoinPrice;
            decimal sumEuro = sumLeva / euroPrice;

            Console.WriteLine($"{sumEuro - (sumEuro * commision / 100):f2}");
        }
    }
}
