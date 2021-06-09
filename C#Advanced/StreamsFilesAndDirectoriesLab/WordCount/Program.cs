using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("words.txt");
            string line = "";

            using (reader)
            {
                line = reader.ReadLine();
            }

            string[] words = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            words = WordsToLower(words);

            Dictionary<string, int> countWords = new Dictionary<string, int>();
            FillDictionary(countWords, words);

            reader = new StreamReader("text.txt");

            using (reader)
            {
                line = reader.ReadLine();
                char[] symbols = { '!', ',', '?', '"', ';', ':', '.', '\'', '-', ' ' };
                while (line != null)
                {
                    string[] currentLine = line.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                    currentLine = WordsToLower(currentLine);

                    foreach (string word in currentLine)
                    {
                        if (countWords.ContainsKey(word))
                        {
                            countWords[word]++;
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            countWords = countWords
                .OrderByDescending(v => v.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            using (StreamWriter writer = new StreamWriter("CountWords.txt"))
            {
                foreach (var word in countWords)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        private static Dictionary<string, int> FillDictionary(Dictionary<string, int> countWords, string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (!countWords.ContainsKey(words[i]))
                {
                    countWords.Add(words[i], 0);
                }
            }
            return countWords;
        }

        private static string[] WordsToLower(string[] words)
        {

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
            return words;
        }
    }
}
