using System;

namespace VowelsCount
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int result = GetVowelsCount(input);

            Console.WriteLine(result);
        }

        private static int GetVowelsCount(string str)
        {
            int result = 0;
            str = str.ToLower();

            foreach (char symbol in str)
            {
                if (symbol == 'a' ||
                    symbol == 'e' ||
                    symbol == 'i' ||
                    symbol == 'o' ||
                    symbol == 'u' ||
                    symbol == 'y')
                {
                    result++;
                }
            }
            return result;
        }
    }
}
