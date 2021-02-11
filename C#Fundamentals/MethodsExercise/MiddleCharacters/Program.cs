using System;
using System.Text;

namespace MiddleCharacters
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();

            string result = GetMiddleChar(str);
            Console.WriteLine(result);
        }

        private static string GetMiddleChar(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (str.Length % 2 == 0)
            {
                stringBuilder.Append(str[str.Length / 2 - 1]);
                stringBuilder.Append(str[str.Length / 2]);
            }
            else
            {
                stringBuilder.Append(str[str.Length / 2]);
            }

            return stringBuilder.ToString();
        }
    }
}
