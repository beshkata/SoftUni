using System;
using System.Linq;
using System.IO;
using System.Text;

namespace EvenLines
{
    class Program
    {
        //Write a program that reads a text file and prints on the console its even lines.
        //Line numbers start from 0. Use StreamReader.
        //Before you print the result replace { "-", ",", ".", "!", "?"}
        //with "@" and reverse the order of the words.
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");

            char[] symbols = { '-', ',', '.', '!', '?' };

            int counter = 0;
            string line = string.Empty;

            using(reader)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        string[] currentLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        currentLine = Reverse(currentLine);

                        string output = string.Join(' ', currentLine);
                        output = ReplaceSymbols(output, symbols);
                        Console.WriteLine(output);
                    }
                    line = reader.ReadLine();
                    counter++;
                }
            }
        }

        private static string ReplaceSymbols(string output, char[] symbols)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < output.Length; i++)
            {
                if (symbols.Contains(output[i]))
                {
                    result.Append('@');
                }
                else
                {
                    result.Append(output[i]);
                }
            }
            return result.ToString();
        }

        private static string[] Reverse(string[] currentLine)
        {
            string[] reversed = new string[currentLine.Length];

            for (int i = 0; i < reversed.Length; i++)
            {
                reversed[i] = currentLine[currentLine.Length - i - 1];
            }

            return reversed;
        }
    }
}
