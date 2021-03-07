using System;
using System.Collections.Generic;

namespace WordSynonyms
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < count; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (synonyms.ContainsKey(word) == false)
                {
                    synonyms.Add(word, new List<string>());
                }
                synonyms[word].Add(synonym);
            }

            foreach (var kvp in synonyms)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
