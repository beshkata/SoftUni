using System;
using System.Text;
using System.Linq;

namespace DigitsLettersOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            StringBuilder letters = new StringBuilder();
            StringBuilder digits = new StringBuilder();
            StringBuilder specChars = new StringBuilder();

            foreach (char symbol in str)
            {
                if (char.IsLetter(symbol))
                {
                    letters.Append(symbol);
                }
                else if (char.IsDigit(symbol))
                {
                    digits.Append(symbol);
                }
                else
                {
                    specChars.Append(symbol);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(specChars);
        }
    }
}
