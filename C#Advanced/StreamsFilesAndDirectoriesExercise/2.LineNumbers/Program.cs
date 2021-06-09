using System;
using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        //Write a program that reads a text file
        //and inserts line numbers in front of each of its lines
        //and count all the letters and punctuation marks.
        //The result should be written to another text file. Use the static class File.
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");
            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = LetterCounter(lines[i]);
                int symbolsCount = SymbolsCounter(lines[i]);

                newLines[i] = $"Line{i + 1}: {lines[i]} ({lettersCount})({symbolsCount})";
            }

            File.WriteAllLines("output.txt", newLines);
        }

        private static int SymbolsCounter(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetterOrDigit(str[i]) && !char.IsWhiteSpace(str[i]))
                {
                    result++;
                }
            }
            return result;
        }

        private static int LetterCounter(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    result++;
                }
            }
            return result;

        }
    }
}
