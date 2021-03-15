using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> letterByMorseCode = new Dictionary<string, char>();
            letterByMorseCode.Add(".-", 'A');
            letterByMorseCode.Add("-...", 'B');
            letterByMorseCode.Add("-.-.", 'C');
            letterByMorseCode.Add("-..", 'D');
            letterByMorseCode.Add(".", 'E');
            letterByMorseCode.Add("..-.", 'F');
            letterByMorseCode.Add("--.", 'G');
            letterByMorseCode.Add("....", 'H');
            letterByMorseCode.Add("..", 'I');
            letterByMorseCode.Add(".---", 'J');
            letterByMorseCode.Add("-.-", 'K');
            letterByMorseCode.Add(".-..", 'L');
            letterByMorseCode.Add("--", 'M');
            letterByMorseCode.Add("-.", 'N');
            letterByMorseCode.Add("---", 'O');
            letterByMorseCode.Add(".--.", 'P');
            letterByMorseCode.Add("--.-", 'Q');
            letterByMorseCode.Add(".-.", 'R');
            letterByMorseCode.Add("...", 'S');
            letterByMorseCode.Add("-", 'T');
            letterByMorseCode.Add("..-", 'U');
            letterByMorseCode.Add("...-", 'V');
            letterByMorseCode.Add(".--", 'W');
            letterByMorseCode.Add("-..-", 'X');
            letterByMorseCode.Add("-.--", 'Y');
            letterByMorseCode.Add("--..", 'Z');
            letterByMorseCode.Add("|", ' ');

            string[] message = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                sb.Append(letterByMorseCode[message[i]]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
