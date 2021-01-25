using System;

namespace IntegerOperations
{
    class Program
    {
        static void Main()
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            long thirdNumber = long.Parse(Console.ReadLine());
            long forthNumber = long.Parse(Console.ReadLine());

            long result = (firstNumber + secondNumber) / thirdNumber * forthNumber;

            Console.WriteLine(result);
        }
    }
}
