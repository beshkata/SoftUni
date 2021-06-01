using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = ReadMatrix(dimensions);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);

                if (IsValid(row1, col1, dimensions) && IsValid(row2, col2, dimensions))
                {
                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                PrintMatrix(matrix);

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValid(int row, int col, int[] dimensions)
        {
            return row >= 0 && row < dimensions[0] && col >= 0 && col < dimensions[1];
        }

        static string[,] ReadMatrix(int[] dimensions)
        {
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < dimensions[0]; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < dimensions[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

    }
}
