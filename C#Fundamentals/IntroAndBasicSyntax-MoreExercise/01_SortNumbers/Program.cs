using System;

namespace _01_SortNumbers
{
    class Program
    {
        static void Main()
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double thirdNum = double.Parse(Console.ReadLine());

            if (firstNum >= secondNum && firstNum >= thirdNum)
            {
                Console.WriteLine(firstNum);
                if (secondNum >= thirdNum)
                {
                    Console.WriteLine(secondNum);
                    Console.WriteLine(thirdNum);
                }
                else
                {
                    Console.WriteLine(thirdNum);
                    Console.WriteLine(secondNum);
                }
            }
            else if (secondNum >= firstNum && secondNum >= thirdNum)
            {
                Console.WriteLine(secondNum);
                if (firstNum >= thirdNum)
                {
                    Console.WriteLine(firstNum);
                    Console.WriteLine(thirdNum);
                }
                else
                {
                    Console.WriteLine(thirdNum);
                    Console.WriteLine(firstNum);
                }
            }
            else
            {
                Console.WriteLine(thirdNum);
                if (firstNum >= secondNum)
                {
                    Console.WriteLine(firstNum);
                    Console.WriteLine(secondNum);
                }
                else
                {
                    Console.WriteLine(secondNum);
                    Console.WriteLine(firstNum);
                }

            }
        }
    }
}
