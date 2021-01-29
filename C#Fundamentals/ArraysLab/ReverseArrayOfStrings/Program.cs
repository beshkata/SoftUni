using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Array.Reverse(input);
            Console.WriteLine(string.Join(' ', input));
        }
    }
}
