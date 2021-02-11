using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main()
        {
            int arraysCount = int.Parse(Console.ReadLine());
            long[][] arrays = new long[arraysCount][];

            for (int i = 1; i <= arraysCount; i++)
            {
                arrays[i-1] = new long[i];
            }

            arrays[0][0] = 1;
            for (int i = 1; i < arraysCount; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    if (j - 1 < 0)
                    {
                        arrays[i][j] = 0 + arrays[i - 1][j];
                    }
                    else if (j > arrays[i-1].Length-1)
                    {
                        arrays[i][j] = 0 + arrays[i - 1][j-1];
                    }
                    else
                    {
                        arrays[i][j] = arrays[i - 1][j] + arrays[i - 1][j - 1];
                    }
                }
            }

            for (int i = 0; i < arrays.Length; i++)
            {
                Console.WriteLine(string.Join(' ', arrays[i]));
            }
        }
    }
}
