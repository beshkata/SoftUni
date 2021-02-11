using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();
            bool isValid = true;

            if (!IsLenghtValid(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }

            if (!AreOnlyDigitsAndLetters(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (!AreMoreThanOneDigit(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool AreMoreThanOneDigit(string password)
        {
            int digitCount = 0;

            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitCount++;
                    if (digitCount == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool AreOnlyDigitsAndLetters(string password)
        {
            foreach (char symbol in password)
            {
                if (char.IsLetterOrDigit(symbol) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsLenghtValid(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
