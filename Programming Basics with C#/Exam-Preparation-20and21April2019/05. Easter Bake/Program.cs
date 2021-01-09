using System;

namespace _05._Easter_Bake
{
    class Program
    {
        static void Main()
        {
            int kozunakNum = int.Parse(Console.ReadLine());

            int totalFluor = 0;
            int totalSugar = 0;

            int sugarPackages = 0;
            int fluorPackages = 0;

            int maxFluor = 0;
            int maxSugar = 0;

            for (int i = 0; i < kozunakNum; i++)
            {
                int sugar = int.Parse(Console.ReadLine());
                if (sugar > maxSugar)
                {
                    maxSugar = sugar;
                }
                totalSugar += sugar;

                int fluor = int.Parse(Console.ReadLine());
                if (fluor > maxFluor)
                {
                    maxFluor = fluor;
                }
                totalFluor += fluor;
            }

            if (totalSugar % 950 != 0)
            {
                sugarPackages = totalSugar / 950 + 1;
            }
            else
            {
                sugarPackages = totalSugar / 950;
            }
            if (totalFluor % 750 != 0)
            {
                fluorPackages = totalFluor / 750 + 1;
            }
            else
            {
                fluorPackages = totalFluor / 750;
            }

            Console.WriteLine($"Sugar: {sugarPackages}");
            Console.WriteLine($"Flour: {fluorPackages}");
            Console.WriteLine($"Max used flour is {maxFluor} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
