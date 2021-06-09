using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _3.WordCount
{
    //Write a program that reads a list of words from the file words.txt
    //and finds how many times each of the words is contained in another file text.txt.
    //Matching should be case-insensitive. Write the results in file actualResults.txt.
    //Sort the words by frequency in descending order and then compare the result with the file expectedResult.txt.
    //Use the File class.
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            words = WordsToLower(words);

            string[] text = File.ReadAllLines("text.txt");

            Dictionary<string, int> countWords = new Dictionary<string, int>();

            countWords = FillDictionary(words, countWords);
            char[] symbols = { '!', ',', '?', '"', ';', ':', '.', '\'', '-', ' ' };

            for (int i = 0; i < text.Length; i++)
            {
                string[] currentLine = text[i].Split(symbols, StringSplitOptions.RemoveEmptyEntries);
                currentLine = WordsToLower(currentLine);

                foreach (string word in currentLine)
                {
                    if (countWords.ContainsKey(word))
                    {
                        countWords[word]++;
                    }
                }
            }
            string[] actualResult = DictionaryToStringArr(countWords);
            File.WriteAllLines("actualResult.txt", actualResult);

            countWords = countWords
                .OrderByDescending(v => v.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            string[] expectedResult = DictionaryToStringArr(countWords);
            File.WriteAllLines("expectedResult.txt", expectedResult);
        }

        private static string[] DictionaryToStringArr(Dictionary<string, int> countWords)
        {
            string[] result = new string[countWords.Count];
            int counter = 0;

            foreach (var word in countWords)
            {
                result[counter] = $"{word.Key} - {word.Value}";
                counter++;
            }
            return result;
        }

        private static string[] WordsToLower(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
            return words;
        }

        private static Dictionary<string, int> FillDictionary(string[] words, Dictionary<string, int> countWords)
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
    }
}
