using System;

namespace _06_StrongNumber
{
    class Program
    {
        static void Main()
        {
            string numberStr = Console.ReadLine();

            int number = int.Parse(numberStr);
            int factorielsSum = 0;

            for (int i = 0; i < numberStr.Length; i++)
            {
                int digit = int.Parse(numberStr[i].ToString());
                int factoriel = 1;
                for (int j = 1; j <= digit; j++)
                {
                    factoriel *= j;
                }
                factorielsSum += factoriel;
            }

            if (number == factorielsSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
