using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int maxNum = int.MinValue;

            while (input != "Stop")
            {
                if (int.Parse(input) > maxNum)
                {
                    maxNum = int.Parse(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxNum);
        }
    }
}
