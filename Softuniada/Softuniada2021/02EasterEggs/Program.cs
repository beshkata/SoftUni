using System;
using System.Collections.Generic;
using System.Text;

namespace Softuniada2021
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int currentRow = 0;
            StringBuilder sb = new StringBuilder();

            while (rows > 0)
            {
                for (int i = 1; i <= rows; i++)
                {
                    sb.Append(i);
                }
                for (int i = rows - 1; i > 0; i--)
                {
                    sb.Append(i);
                }
                Console.WriteLine(sb.ToString());
                currentRow++;
                rows--;
                sb.Clear();
                sb.Append(new string(' ', currentRow));
            }
        }
    }

}
