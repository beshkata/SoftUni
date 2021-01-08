using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = firstNum; i <= secondNum; i++)
            {
                string str = i.ToString();

                for (int j = 0; j < str.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        evenSum += int.Parse(str[j].ToString());
                    }
                    else
                    {
                        oddSum += int.Parse(str[j].ToString());
                    }
                }
                if (evenSum == oddSum)
                {
                    Console.Write(i + " ");
                }
                evenSum = 0;
                oddSum = 0;
            }
        }
    }
}
