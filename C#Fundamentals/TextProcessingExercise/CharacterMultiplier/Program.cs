using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();

            int result = MultiplyChars(words[0], words[1]);

            Console.WriteLine(result);
        }

        private static int MultiplyChars(string firstString, string secondString)
        {
            int minLenght = Math.Min(firstString.Length, secondString.Length);

            int sum = 0;

            for (int i = 0; i < minLenght; i++)
            {
                sum += firstString[i] * secondString[i];
            }

            if (firstString.Length > secondString.Length)
            {
                sum += SumChars(firstString, minLenght);
            }
            else if (secondString.Length > firstString.Length)
            {
                sum += SumChars(secondString, minLenght);
            }

            return sum;
        }

        private static int SumChars(string str, int index)
        {
            int result = 0;

            for (int i = index; i < str.Length; i++)
            {
                result += str[i];
            }

            return result;
        }
    }
}
