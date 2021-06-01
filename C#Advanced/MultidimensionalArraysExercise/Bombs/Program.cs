using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] bombString = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[][] bombCoordinates = new int[bombString.Length][];

            for (int row = 0; row < bombCoordinates.GetLength(0); row++)
            {
                bombCoordinates[row] = bombString[row]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < bombCoordinates.GetLength(0); i++)
            {
                int bombRow = bombCoordinates[i][0];
                int bombCol = bombCoordinates[i][1];

                matrix = BombExplosion(bombRow, bombCol, matrix);
            }

            int sum = 0;
            int aliveCells = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");

                }
                Console.WriteLine();
            }
        }

        private static int[,] BombExplosion(int row, int col, int[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix[row, col] > 0 && AreValid(row, col, n))
            {
                if (AreValid(row - 1, col, n)&&matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= matrix[row, col];
                }
                if (AreValid(row - 1, col + 1, n) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= matrix[row, col];
                }
                if (AreValid(row, col + 1, n) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= matrix[row, col];
                }
                if (AreValid(row + 1, col + 1, n) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= matrix[row, col];
                }
                if (AreValid(row + 1, col, n) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= matrix[row, col];
                }
                if (AreValid(row + 1, col - 1, n) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= matrix[row, col];
                }
                if (AreValid(row, col - 1, n) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= matrix[row, col];
                }
                if (AreValid(row - 1, col - 1, n) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= matrix[row, col];
                }

                matrix[row, col] = 0;
            }

            return matrix;
        }

        private static bool AreValid(int row, int col, int dimension)
        {
            return row >= 0 && row < dimension && col >= 0 && col < dimension;
        }

    }
}
