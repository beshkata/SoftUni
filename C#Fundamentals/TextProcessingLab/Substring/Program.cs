using System;

namespace Substring
{
    class Program
    {
        static void Main()
        {
            string key = Console.ReadLine();
            string word = Console.ReadLine();

            while (word.Contains(key))
            {
                int index = word.IndexOf(key);
                word = word.Remove(index, key.Length);
            }

            Console.WriteLine(word);
        }
    }
}
