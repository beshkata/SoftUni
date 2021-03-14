using System;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bandedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var bandWord in bandedWords)
            {
                string replacement = new string('*', bandWord.Length);

                while (text.Contains(bandWord))
                {
                    text = text.Replace(bandWord, replacement);
                }
            }

            Console.WriteLine(text);
        }
    }
}
