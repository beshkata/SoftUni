using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main()
        {
            string regex = @"\b[A-Z][a-z]+\ [A-Z][a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matches = Regex.Matches(names, regex);

            foreach (Match name in matches)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
