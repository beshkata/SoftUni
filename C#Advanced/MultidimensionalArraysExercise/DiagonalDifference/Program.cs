using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(dimensions);

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0, j= dimensions - 1; i < dimensions; i++, j--)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, j];
            }

            int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(difference);
        }

        static int[,] ReadMatrix(int dimensions)
        {
            int[,] matrix = new int[dimensions, dimensions];

            for (int row = 0; row < dimensions; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }

}
