using System;

namespace CharsToString
{
    class Program
    {
        static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            Console.WriteLine(firstChar.ToString() + secondChar + thirdChar);
        }
    }
}
