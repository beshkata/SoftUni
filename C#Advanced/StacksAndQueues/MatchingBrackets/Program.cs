using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expresion = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (expresion[i] == ')')
                {
                    int startIndex = indexes.Pop();
                    Console.WriteLine(expresion.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
