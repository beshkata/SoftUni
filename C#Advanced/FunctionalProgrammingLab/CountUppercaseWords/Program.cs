using System;
using System.Linq;


namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
