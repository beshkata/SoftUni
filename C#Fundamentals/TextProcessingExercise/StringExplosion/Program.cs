using System;
using System.Text;

namespace StringExplosion
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            int power = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '>')
                {
                    power += line[i + 1] - '0';
                    result.Append(line[i]);
                }
                else if (power > 0)
                {
                    power--;
                }
                else
                {
                    result.Append(line[i]);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
