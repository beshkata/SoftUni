using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            string str = Console.ReadLine();
            int start = Math.Min(firstChar, secondChar);
            int end = Math.Max(firstChar, secondChar);

            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > start && str[i] < end)
                {
                    sum += str[i];
                }
                
            }

            Console.WriteLine(sum);
        }
    }
}
