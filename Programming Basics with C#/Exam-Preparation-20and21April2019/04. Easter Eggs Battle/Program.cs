using System;

namespace _04._Easter_Eggs_Battle
{
    class Program
    {
        static void Main()
        {
            int eggsFirstPlayer = int.Parse(Console.ReadLine());
            int eggsSecondPlayer = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();


            while (input != "End of battle")
            {
                if (input == "one")
                {
                    eggsSecondPlayer--;
                    if (eggsSecondPlayer <= 0)
                    {
                        Console.WriteLine($"Player two is out of eggs. Player one has {eggsFirstPlayer} eggs left.");
                        break;
                    }
                }
                else
                {
                    eggsFirstPlayer--;
                    if (eggsFirstPlayer <= 0)
                    {
                        Console.WriteLine($"Player one is out of eggs. Player two has {eggsSecondPlayer} eggs left.");
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            if (input == "End of battle")
            {
                Console.WriteLine($"Player one has {eggsFirstPlayer} eggs left.");
                Console.WriteLine($"Player two has {eggsSecondPlayer} eggs left.");
            }
        }
    }
}
