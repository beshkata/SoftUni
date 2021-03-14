using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder(text.Length);

            foreach (char symbol in text)
            {
                result.Append((char)(symbol + 3));
            }

            Console.WriteLine(result);
        }
    }
}
