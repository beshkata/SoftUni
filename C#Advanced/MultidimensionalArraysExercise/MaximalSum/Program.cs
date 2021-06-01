using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = ReadMatrix(dimensions);

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxRow; row <= maxRow + 2; row++)
            {
                for (int col = maxCol; col <= maxCol+2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] ReadMatrix(int[] dimensions)
        {
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < dimensions[0]; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < dimensions[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

    }
}
