using System;

namespace _01._Read_Text
{
    class Program
    {
        static void Main()
        {
            string srt = Console.ReadLine();

            while (srt != "Stop")
            {
                Console.WriteLine(srt);
                srt = Console.ReadLine();

            }
        }
    }
}
