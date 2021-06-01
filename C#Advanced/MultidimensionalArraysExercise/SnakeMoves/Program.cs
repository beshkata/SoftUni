using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimesions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            char[,] matrix = new char[dimesions[0], dimesions[1]];

            int lenght = dimesions[0] * dimesions[1];

            char[] snake = new char[lenght];

            for (int i = 0, j = 0; i < snake.Length; i++, j++)
            { 
                if (j == input.Length)
                {
                    j = 0;
                }

                snake[i] = input[j];
            }

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[counter];
                        counter++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0 ; col--)
                    {
                        matrix[row, col] = snake[counter];
                        counter++;
                    }
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
