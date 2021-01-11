using System;

namespace _04._Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int numComp = int.Parse(Console.ReadLine());

            double totalSales = 0;
            double averageRating = 0;
            for (int i = 0; i < numComp; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int rating = number % 10;
                averageRating += rating;
                int posibleSales = number / 10;

                switch (rating)
                {
                    case 3:
                        totalSales += posibleSales * 0.5;
                        break;
                    case 4:
                        totalSales += posibleSales * 0.7;
                        break;
                    case 5:
                        totalSales += posibleSales * 0.85;
                        break;
                    case 6:
                        totalSales += posibleSales * 1.0;
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine($"{totalSales:f2}");
            Console.WriteLine($"{averageRating / numComp:f2}");
        }
    }
}
