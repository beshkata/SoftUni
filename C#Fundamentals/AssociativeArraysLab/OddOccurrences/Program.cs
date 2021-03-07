using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split();

            Dictionary<string, int> countByWords = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (countByWords.ContainsKey(word) == false)
                {
                    countByWords.Add(word, 0);
                }

                countByWords[word]++;
            }

            foreach (var kvp in countByWords)
            {
                if (kvp.Value % 2 == 1)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }    
        }
    }
}
