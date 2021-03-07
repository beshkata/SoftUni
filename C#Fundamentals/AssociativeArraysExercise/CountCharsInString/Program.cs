using System;
using System.Collections.Generic;

namespace CountCharsInString
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Dictionary<char, int> countToChars = new Dictionary<char, int>();

            foreach (char letter in text)
            {
                if (letter == ' ')
                {
                    continue;
                }
                if (countToChars.ContainsKey(letter) == false)
                {
                    countToChars.Add(letter, 0);
                }

                countToChars[letter]++;
            }

            foreach (var kvp in countToChars)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
