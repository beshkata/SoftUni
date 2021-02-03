using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main()
        {
            int result = GetFibonacci(int.Parse(Console.ReadLine()));
            Console.WriteLine(result);
        }
        static int GetFibonacci(int n)
        {
            
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                int fibonacciN = GetFibonacci(n - 1) + GetFibonacci(n - 2);
                return fibonacciN;
            }
        }
    }
}
