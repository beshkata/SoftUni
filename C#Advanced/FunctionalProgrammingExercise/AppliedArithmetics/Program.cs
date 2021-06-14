using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


           
            string input = Console.ReadLine();

            while (input != "end")
            {
                number = ApplyCommand(number, input);
                input = Console.ReadLine();
            }
        }

        static Func<int, int> Add = n => n = n + 1;

        static Func<int, int> Multiply = n => n = n * 2;

        static Func<int, int> Subtract = n => n = n - 1;

        static Action<int[]> Print = n => Console.WriteLine(string.Join(' ', n));



        private static int[] ApplyCommand(int[] number, string command)
        {
            if (command == "add")
            {
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] = Add(number[i]);
                }
            }
            else if (command == "multiply")
            {
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] = Multiply(number[i]);
                }

            }
            else if (command == "subtract")
            {
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] = Subtract(number[i]);
                }


            }
            else
            {
                Print(number);
            }
            return number;
        }
    }
}
