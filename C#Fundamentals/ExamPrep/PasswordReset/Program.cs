using System;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Done")
                {
                    break;
                }

                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "TakeOdd")
                {
                    password = TakeOdd(password);
                    Console.WriteLine(password);
                }

                else if(command == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int lenght = int.Parse(tokens[2]);

                    string substring = password.Substring(index, lenght);

                    int startIndx = password.IndexOf(substring);
                    if (startIndx >= 0)
                    {
                        password = password.Remove(startIndx, lenght);

                        Console.WriteLine(password);
                    }
                }
                else if (command == "Substitute")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];

                    if (password.Contains(oldString))
                    {
                        while (password.Contains(oldString))
                        {
                            password = password.Replace(oldString, newString);
                        }
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");

        }

        private static string TakeOdd(string password)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 1; i < password.Length; i += 2)
            {
                stringBuilder.Append(password[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
