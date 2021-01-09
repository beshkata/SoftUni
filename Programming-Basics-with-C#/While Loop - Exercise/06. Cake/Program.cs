using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int cakeSize = width * lenght;

            string input = string.Empty;
            int cakePiecesConter = 0;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "STOP")
                {
                    break;
                }
                else
                {
                    cakePiecesConter += int.Parse(input);
                    if (cakePiecesConter >= cakeSize)
                    {
                        break;
                    }
                }
            }
            if (cakePiecesConter >= cakeSize)
            {
                Console.WriteLine($"No more cake left! You need {cakePiecesConter - cakeSize} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cakeSize - cakePiecesConter} pieces are left.");
            }
        }
    }
}
