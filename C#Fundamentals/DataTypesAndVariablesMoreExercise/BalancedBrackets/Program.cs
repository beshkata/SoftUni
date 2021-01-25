using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool isOneOpen = false;
            bool isCloseWithoutOpen = false;
            bool isTwoOrMoreOpen = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input == "(" && isOneOpen == false && isTwoOrMoreOpen == false)
                {
                    isOneOpen = true;
                }
                else if (input == "(" && isOneOpen && isTwoOrMoreOpen == false)
                {
                    isTwoOrMoreOpen = true;
                }
                else if (input == ")" && isOneOpen == false)
                {
                    isCloseWithoutOpen = true;
                }
                else if (input == ")" && isOneOpen)
                {
                    isOneOpen = false;
                }
            }
            if (isOneOpen || isCloseWithoutOpen || isTwoOrMoreOpen)
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }
        }
    }
}
