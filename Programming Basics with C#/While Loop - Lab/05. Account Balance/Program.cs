using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double balance = 0.0;

            while (input != "NoMoreMoney")
            {
                if (double.Parse(input) < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {double.Parse(input):f2}");
                balance += double.Parse(input);
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
