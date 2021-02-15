using System;
using System.Text;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(IsPalindrome(input).ToString().ToLower());
                input = Console.ReadLine();
            }
        }

        private static bool IsPalindrome(string str)
        {
            char[] strToChar = str.ToCharArray();
            Array.Reverse(strToChar);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(strToChar);

            string leftToRight = str;
            string rightToLeft = stringBuilder.ToString();

            return leftToRight == rightToLeft;
        }
    }
}
