using System;

namespace _05_Messages
{
    class Program
    {
        static void Main()
        {
            int letterCount = int.Parse(Console.ReadLine());
            string output = "";

            for (int i = 0; i < letterCount; i++)
            {
                string input = Console.ReadLine();
                if (input == "0")
                {
                    output += " ";
                }
                else
                {
                    int numberOfDigits = input.Length;
                    int mainDigit = int.Parse(input[0].ToString());
                    int offset = (mainDigit - 2) * 3;
                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset++;
                    }
                    int letterIndex = offset + numberOfDigits - 1;
                    output += (char)(letterIndex + 97);
                }
            }
            Console.WriteLine(output);
        }
    }
}
