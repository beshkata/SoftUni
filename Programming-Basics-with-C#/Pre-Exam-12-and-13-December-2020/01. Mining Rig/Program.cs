using System;

namespace _01._Mining_Rig
{
    class Program
    {
        static void Main(string[] args)
        {
            int videoPrice = int.Parse(Console.ReadLine());
            int conectorPrice = int.Parse(Console.ReadLine());
            double elPerDayPrice = double.Parse(Console.ReadLine());
            double profitPerDay = double.Parse(Console.ReadLine());

            double totalVideoPrice = videoPrice * 13;
            double totalConectorPrice = conectorPrice * 13;

            double totalPrice = totalConectorPrice + totalVideoPrice + 1000;
            double totalProfitPerDay = (profitPerDay - elPerDayPrice) * 13;

            Console.WriteLine(totalPrice);
            if (totalPrice % totalProfitPerDay != 0)
            {
                Console.WriteLine((int)(totalPrice / totalProfitPerDay + 1));
            }
            else
            {
                Console.WriteLine((int)(totalPrice / totalProfitPerDay));
            }
        }
    }
}
