using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintCharBetween(firstChar, secondChar);
        }

        private static void PrintCharBetween(char firstChar, char secondChar)
        {
            char start = (char)Math.Min(firstChar, secondChar);
            char end = (char)Math.Max(firstChar, secondChar);

            for (int i = start+1; i < end; i++)
            {
                Console.Write($"{(char)i} ");
            }

        }
    }
}
