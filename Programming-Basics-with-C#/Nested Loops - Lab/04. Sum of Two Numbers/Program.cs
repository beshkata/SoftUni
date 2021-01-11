using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int magicalNum = int.Parse(Console.ReadLine());
            bool isFound = false;

            int counter = 0;

            for (int i = firstNum; i <= secondNum; i++)
            {
                for (int j = firstNum; j <= secondNum; j++)
                {
                    counter++;
                    if (i + j == magicalNum)
                    {
                        isFound = true;
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicalNum})");
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicalNum}");
            }
        }
    }
}
