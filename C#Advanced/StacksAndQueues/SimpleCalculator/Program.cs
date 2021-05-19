using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> expresion = new Stack<string>();

            for (int i = input.Length-1; i >= 0; i--)
            {
                expresion.Push(input[i]);
            }

            

            while (expresion.Count > 1)
            {
                int firstNum = int.Parse(expresion.Pop());
                string sign = expresion.Pop();
                int secondNumber = int.Parse(expresion.Pop());

                int sum = 0;
                if (sign == "+")
                {
                    sum = firstNum + secondNumber;
                }
                else
                {
                    sum = firstNum - secondNumber;
                }

                expresion.Push(sum.ToString());
            }

            Console.WriteLine(expresion.Pop());
        }
    }
}
