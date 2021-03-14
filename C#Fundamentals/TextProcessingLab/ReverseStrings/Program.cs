using System;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "end")
            {
                string reversedWord = GetReversedWord(word);

                Console.WriteLine($"{word} = {reversedWord}");

                word = Console.ReadLine();
            }
        }

        private static string GetReversedWord(string word)
        {
            char[] wordToCharArr = word.ToCharArray();
            wordToCharArr = wordToCharArr.Reverse()
                .ToArray();
            string result = string.Concat(wordToCharArr);
            return result;
        }
    }
}
