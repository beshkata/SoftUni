using System;
using System.Linq;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];
            matrix[0] = new long []{ 1 };

            for (int row = 1; row < n; row++)
            {
                matrix[row] = new long[row+1];
                
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (col == 0)
                    {
                        matrix[row][col] = matrix[row - 1][col];
                    }
                    else if (col == matrix[row].Length-1)
                    {
                        matrix[row][col] = matrix[row - 1][col - 1];
                    }
                    else
                    {
                        matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
