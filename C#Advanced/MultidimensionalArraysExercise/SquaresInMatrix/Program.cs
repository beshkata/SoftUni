using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = ReadMatrix(dimensions);

            int counter = 0;

            for (int row = 0; row < dimensions[0] - 1; row++)
            {
                for (int col = 0; col < dimensions[1] - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }

        static char[,] ReadMatrix(int [] dimensions)
        {
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int row = 0; row < dimensions[0]; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
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
