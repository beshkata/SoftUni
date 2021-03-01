using System;

namespace RandomizeWords
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .Split();

            Random rand = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randNum = rand.Next(0, words.Length);
                string currentWord = words[randNum];
                words[randNum] = words[i];
                words[i] = currentWord;
            }

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
