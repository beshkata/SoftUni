using System;

namespace DecryptingMessage
{
    class Program
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string result = "";

            for (int i = 0; i < n; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                char decriptedChar = (char)((int)currentChar + key);
                result += decriptedChar.ToString();
            }
            Console.WriteLine(result);
        }
    }
}
