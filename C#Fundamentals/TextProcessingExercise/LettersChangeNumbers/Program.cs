using System;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double sum = 0.0;

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];

                char firstLetter = currentWord[0];
                char lastLetter = currentWord[currentWord.Length - 1];
                double number = double.Parse(currentWord.Substring(1, currentWord.Length - 2));
                int letterPosition = 0;
                if (char.IsUpper(firstLetter))
                {
                    letterPosition = firstLetter - 64;

                    number /= letterPosition;
                }
                else
                {
                    letterPosition = firstLetter - 96;
                    number *= letterPosition;
                }

                if (char.IsUpper(lastLetter))
                {
                    letterPosition = lastLetter - 64;
                    number -= letterPosition;
                }
                else
                {
                    letterPosition = lastLetter - 96;
                    number += letterPosition;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
