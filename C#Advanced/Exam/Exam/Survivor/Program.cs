using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[i] = row;
            }

            string input = Console.ReadLine();
            int collectedTokens = 0;
            int opponentTokens = 0;

            while (input != "Gong")
            {
                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (!IsValid(matrix, row, col))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (command == "Find")
                {

                    if (IsValid(matrix, row, col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                }
                else if(command == "Opponent")
                {
                    string direction = tokens[3];
                    if (direction == "up")
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            if (IsValid(matrix, row, col))
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    opponentTokens++;
                                    matrix[row][col] = '-';
                                }
                            }
                            row--;
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            if (IsValid(matrix, row, col))
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    opponentTokens++;
                                    matrix[row][col] = '-';
                                }
                            }
                            row++;
                        }

                    }
                    else if (direction == "left")
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            if (IsValid(matrix, row, col))
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    opponentTokens++;
                                    matrix[row][col] = '-';
                                }
                            }
                            col--;
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i <= 3; i++)
                        {
                            if (IsValid(matrix, row, col))
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    opponentTokens++;
                                    matrix[row][col] = '-';
                                }
                            }
                            col++;
                        }
                    }
                }
                input = Console.ReadLine();
            }


            PrintMatrix(matrix);

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static bool IsValid(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
