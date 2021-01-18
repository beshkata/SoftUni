using System;

namespace _05_Login
{
    class Program
    {
        static void Main()
        {
            string userName = Console.ReadLine();

            string password = "";

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }

            bool isLoggedIn = false;
            bool isBlocked = false;
            int attemptCounter = 0;

            while (!isLoggedIn && !isBlocked)
            {
                string input = Console.ReadLine();
                if (input == password)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    isLoggedIn = true;
                }
                else
                {
                    attemptCounter++;
                    if (attemptCounter == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        isBlocked = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                }
            }
        }
    }
}
