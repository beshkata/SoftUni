using System;
using System.Text;

namespace RepeatStrings
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .Split();

            StringBuilder sb = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
