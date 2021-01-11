using System;

namespace _05._Password_Generator
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int letter = int.Parse(Console.ReadLine());
            string password = "";

            for (int firstChar = 1; firstChar < num; firstChar++)
            {
                for (int secondChar = 1; secondChar < num; secondChar++)
                {
                    for (int thirdChar = 97; thirdChar < 97 + letter; thirdChar++)
                    {
                        for (int forth = 97; forth < 97 + letter; forth++)
                        {
                            for (int fifth = Math.Max(firstChar, secondChar) + 1; fifth <= num; fifth++)
                            {
                                password += firstChar;
                                password += secondChar;
                                password += ((char)thirdChar).ToString();
                                password += ((char)forth).ToString();
                                password += fifth.ToString();
                                Console.Write(password + " ");
                                password = "";
                            }
                        }
                    }
                }
            }
        }
    }
}
