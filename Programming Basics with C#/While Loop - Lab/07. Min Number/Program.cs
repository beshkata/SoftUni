using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int minNum = int.MaxValue;

            while (input != "Stop")
            {
                if (int.Parse(input) < minNum)
                {
                    minNum = int.Parse(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
