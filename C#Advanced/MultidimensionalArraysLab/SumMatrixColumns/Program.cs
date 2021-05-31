using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixFormat = ReadLineFromConsole(", ");

            int[,] matrix = new int[matrixFormat[0], matrixFormat[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = ReadLineFromConsole(" ");

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int colSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    colSum += matrix[row, col];
                }
                Console.WriteLine(colSum);
            }
            

        }

        private static int[] ReadLineFromConsole(string separator)
        {
            return Console.ReadLine()
                .Split(separator)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
