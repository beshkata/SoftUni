using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@|#)([A-Za-z]{3,})(\1)(\1)([A-Za-z]{3,})(\1)";

            string text = Console.ReadLine();
            List<string> mirrorWords = new List<string>();

            MatchCollection matchCollection = Regex.Matches(text, pattern);

            if (matchCollection.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine($"{matchCollection.Count} word pairs found!");

            foreach (Match match in matchCollection)
            {
                if (IsMirrorWords(match.Groups[2].Value, match.Groups[5].Value))
                {
                    string words = $"{match.Groups[2].Value} <=> {match.Groups[5].Value}";
                    mirrorWords.Add(words);
                }
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }

        private static bool IsMirrorWords(string firstWord, string secondWord)
        {
            if (firstWord.Length != secondWord.Length)
            {
                return false;
            }

            char[] second = secondWord
                .Reverse()
                .ToArray();

            for (int i = 0; i < second.Length; i++)
            {
                if (firstWord[i] != second[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
