using System;
using System.Text;

namespace RepeatString
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());

            string result = RepeatingString(str, times);

            Console.WriteLine(result);
        }

        private static string RepeatingString(string str, int times)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                stringBuilder.Append(str);
            }

            return stringBuilder.ToString();
        }
    }
}
